using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Diagnostics;
using System.Threading;

namespace AK_KANBAN_Config
{
    public partial class frmMain : Form
    {
        System.Timers.Timer timer = new System.Timers.Timer();

        private string connectionString = ConfigurationManager.AppSettings["dbConnString"].ToString();

        private delegate void SafeCallDelegate();
        private SqlDataAdapter dataAdapterConfig;
        Stopwatch sw = new Stopwatch();

        bool isRunning = true, isPaused = true;
        private string orderID = "-1";
        private int reqLamps = 0;
        private string bs;
        private int lampsMade = 0;
        private Thread t;

        private float simSpeed;
        private float secPerLamp;
        private float realSpeed;
        private int workstationID = -1;
       

        public frmMain()
        {
            InitializeComponent();

            t = new Thread(runTimer);
            dataAdapterConfig = new SqlDataAdapter("Select * FROM tblConfig", connectionString);

            foreach (DataRow dr in GetData("SELECT ID, [WorkSpeed], [EmployeeCategory] FROM tblSkillLevels", dataAdapterConfig).Rows)
            {
                SkillLevel s = new SkillLevel();
                s.ID = Int32.Parse(dr[0].ToString());
                s.workerSpeed = float.Parse(dr[1].ToString());
                s.employeeCategory = dr[2].ToString();
                cbWorkers.Items.Add(s);
            }
        }

        private DataTable GetData(string selectCommand, SqlDataAdapter sda)
        {
            DataTable table = new DataTable
            {
                Locale = CultureInfo.InvariantCulture
            };
            try
            {
                // Create a new data adapter based on the specified query.
                sda = new SqlDataAdapter(selectCommand, connectionString);

                // Create a command builder to generate SQL update, insert, and
                // delete commands based on selectCommand. 
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(sda);

                // Populate a new data table and bind it to the BindingSource.

                sda.Fill(table);

            }
            catch (SqlException)
            {
                MessageBox.Show("To run this example, replace the value of the " +
                    "connectionString variable with a connection string that is " +
                    "valid for your system.");
            }
            return table;
        }

        private void runTimer()
        {
            timer.Start();
            sw.Start();
            while (isRunning)
            {
                if (isPaused) { timer.Stop(); sw.Stop(); }
                else if (!sw.IsRunning)
                {
                    timer.Start();
                    sw.Restart();
                }
                try
                {
                    bs = string.Format("{0:F2} Seconds Remaining", Math.Max((timer.Interval - sw.Elapsed.TotalMilliseconds) / 1000, 0));
                    Invoke(new SafeCallDelegate(refreshTimerString));
                }
                catch { }                
            }
        }
        void refreshTimerString()
        {
            lblTimeBeforeRefresh.Text = bs;
            lblLampsMade.Text = string.Format("{0} Lamps Made", lampsMade);
        }

        private void btnBegin_Click(object sender, EventArgs e)
        {
            if (cbWorkers.SelectedIndex >= 0 && cbWorkstation.SelectedIndex >= 0)
            {
                btnCancel.Enabled = true;
                if (workstationID == -1)
                {
                    isPaused = false;
                    btnBegin.Enabled = false;
                    cbWorkers.Enabled = false;
                    cbWorkstation.Enabled = false;

                    DataTable temp;
                    SkillLevel tempSkillLevel = (SkillLevel)cbWorkers.SelectedItem;

                    temp = GetData("EXEC GetOpenOrder", dataAdapterConfig);
                    if (temp.Rows.Count > 0)
                    {
                        orderID = temp.Rows[0][0].ToString();
                        reqLamps = int.Parse(temp.Rows[0][1].ToString());
                        temp.Clear();
                    }

                    temp = GetData("EXEC GetSimSpeed", dataAdapterConfig);
                    simSpeed = float.Parse(temp.Rows[0][0].ToString());
                    temp.Clear();

                    temp = GetData("EXEC GetSecondsPerLamp", dataAdapterConfig);
                    secPerLamp = float.Parse(temp.Rows[0][0].ToString());
                    temp.Clear();

                    realSpeed = (tempSkillLevel.workerSpeed * secPerLamp) / simSpeed;

                    setTimer();
                    timer.Elapsed += createLamp;

                    timer.AutoReset = true;

                    if (cbWorkstation.SelectedIndex == 0)
                    {
                        temp = GetData("EXEC CreateNewWorkStation " + (tempSkillLevel.ID).ToString(), dataAdapterConfig);
                        workstationID = int.Parse(temp.Rows[0][0].ToString());
                    }
                    else
                    {
                        workstationID = int.Parse(cbWorkstation.SelectedItem.ToString());
                    }
                    GetData(string.Format("UPDATE tblWorkstations SET IsActive = 1, WorkerID = {0} WHERE ID = {1}", tempSkillLevel.ID, workstationID), dataAdapterConfig);

                    lblWorkstationID.Text = string.Format("Workstation: {0}", workstationID);                    
                    t.Start();
                }
                else
                {
                    btnBegin.Enabled = false;
                    isPaused = false;
                    timer.Start();
                }
            }            
        }

        void setTimer()
        {
            float sp = (1 - ((SkillLevel)cbWorkers.SelectedItem).workerSpeed) * realSpeed * 1000;
            Random r = new Random();
            timer.Interval = (realSpeed * 1000) + ((r.Next(0, 100) * (sp * 2) / 100)) - sp;
        }

        private void createLamp(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (isRunning)
            {
                try
                {
                    Invoke(new SafeCallDelegate(setTimer));
                    sw.Restart();
                    timer.Start();
                }
                catch
                {

                }
            }

            DataTable temp = GetData("EXEC GetOpenOrder", dataAdapterConfig);

            if (temp.Rows.Count == 1)
            {
                orderID = temp.Rows[0][0].ToString();
                temp.Clear();

                temp = GetData("EXEC GetTestTrayID", dataAdapterConfig);

                int testTrayID, lampID;

                testTrayID = int.Parse(temp.Rows[0][0].ToString());
                lampID = int.Parse(temp.Rows[0][1].ToString());

                temp.Clear();

                temp = GetData("EXEC CreateLamp " + workstationID.ToString() + ", " + orderID.ToString() + ", " +
                    testTrayID.ToString() + ", " + lampID.ToString(), dataAdapterConfig);

                if (temp.Rows.Count == 0)
                {
                    lampsMade++;
                }
                else { }
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            isRunning = false;
            if (workstationID != -1) { GetData(string.Format("UPDATE tblWorkstations SET IsActive = 0, WorkerID =  1 WHERE ID = {0}", workstationID), dataAdapterConfig); }
        }

        private void CbWorkstation_Click(object sender, EventArgs e)
        {
            cbWorkstation.Items.Clear();
            cbWorkstation.Items.Add("New Workstation");
            foreach (DataRow dr in GetData("SELECT ID FROM tblWorkStations WHERE IsActive = 0", dataAdapterConfig).Rows)
            {
                cbWorkstation.Items.Add(dr[0]);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            timer.Stop();
            btnBegin.Enabled = true;
            btnCancel.Enabled = false;
        }
    }

    public class SkillLevel
    {
        public int ID;
        public string employeeCategory;
        public float workerSpeed;

        public override string ToString()
        {
            return employeeCategory;
        }
    }
}
