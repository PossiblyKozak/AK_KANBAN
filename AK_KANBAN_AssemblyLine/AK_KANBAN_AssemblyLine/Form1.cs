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
using System.Threading;
using System.Diagnostics;

namespace AK_KANBAN_Config
{
    public partial class frmMain : Form
    {
        private string connectionString = ConfigurationManager.AppSettings["dbConnString"].ToString();

        private delegate void SafeCallDelegate();
        private string bs;
        private BindingSource bindingConfig = new BindingSource();

        private BindingSource LampCount = new BindingSource();

        int RequiredLamps, CompletedLamps, ActiveWorkstations, FailedLamps, PassedLamps, AllLamps;

        private SqlDataAdapter dataAdapterConfig;
        private Thread t;
        int simSpeed, minutesPerRefill;
        Stopwatch sw = new Stopwatch();
        System.Timers.Timer timer = new System.Timers.Timer();
        System.Timers.Timer timerStatsRefresh = new System.Timers.Timer();

        bool isRunning = true, isPaused = true;
        int runs = 0;

        public frmMain()
        {
            InitializeComponent();
            lblTimeBeforeRefresh.Text = bs;
            lblNumIterations.Text = runs.ToString();
            btnStartStop.Enabled = false;

            chartLamps.Series.Clear();
            chartLamps.Series.Add("All Lamps");
            chartLamps.Series.Add("Passed Lamps");
            chartLamps.Series.Add("Failed Lamps");
            //chartLamps.ChartAreas[0].AxisX.la

            chartLamps.Series[0].IsValueShownAsLabel = true;
            chartLamps.Series[1].IsValueShownAsLabel = true;
            chartLamps.Series[2].IsValueShownAsLabel = true;

            chartLamps.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            chartLamps.ChartAreas[0].AxisY.Title = "Number of Lamps";
            chartLamps.Titles.Add("Lamp Statistics");

            chartOrder.Series.Clear();
            chartOrder.Series.Add("Ordered Lamps");
            chartOrder.Series.Add("Completed Lamps");

            chartOrder.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            chartOrder.ChartAreas[0].AxisY.Title = "Number of Lamps";
            chartOrder.Titles.Add("Order Statistics");

            chartOrder.Series[0].IsValueShownAsLabel = true;
            chartOrder.Series[1].IsValueShownAsLabel = true;
        }

        void refreshTimerString()
        {
            lblTimeBeforeRefresh.Text = bs;
            lblNumIterations.Text = runs.ToString();
        }

        private void runTimer()
        {
            timerStatsRefresh.Interval = 1000;
            timerStatsRefresh.AutoReset = true;
            timerStatsRefresh.Elapsed += TimerStatsRefresh_Elapsed;
            timerStatsRefresh.Start();
            timer.Interval = (minutesPerRefill * 60000) / simSpeed;
            timer.AutoReset = false;
            timer.Elapsed += RefreshBins;
            timer.Start();
            sw.Start();
            while (isRunning)
            {
                if (isPaused) { timer.Stop(); sw.Stop(); }
                else if (!sw.IsRunning) { timer.Start(); sw.Restart(); }
                try
                {
                    Invoke(new SafeCallDelegate(refreshTimerString));
                    bs = string.Format("{0:F2} Seconds Remaining", Math.Max((timer.Interval - sw.Elapsed.TotalMilliseconds)/1000, 0));                    
                }
                catch { }
                Thread.Sleep(10);
            }
        }

        private void TimerStatsRefresh_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            DataTable OrderStats = GetData("SELECT SUM(ReqLamp) AS RL, SUM(CompLamps) AS CL FROM tblOrders;", dataAdapterConfig);
            DataTable ActiveWorkStations = GetData("SELECT COUNT(*) AS 'Active Workstations' FROM tblWorkStations WHERE IsActive = 1;", dataAdapterConfig);
            DataTable LampStats = GetData("SELECT COUNT(*) AS 'Total Lamps' FROM tblLamps WHERE TestPassed = 1 UNION SELECT COUNT(*) FROM tblLamps UNION SELECT COUNT(*) FROM tblLamps WHERE TestPassed = 0;", dataAdapterConfig);

            RequiredLamps = (int)OrderStats.Rows[0][0];
            CompletedLamps = (int)OrderStats.Rows[0][1];

            ActiveWorkstations = (int)ActiveWorkStations.Rows[0][0];

            FailedLamps = (int)LampStats.Rows[0][0];
            PassedLamps = (int)LampStats.Rows[1][0];
            AllLamps = (int)LampStats.Rows[2][0];

            try
            {
                Invoke(new SafeCallDelegate(RefreshCharts));
            }
            catch { }
        }

        private void RefreshCharts()
        {
            chartOrder.Series[0].Points.Clear();
            chartOrder.Series[1].Points.Clear();

            chartLamps.Series[0].Points.Clear();
            chartLamps.Series[1].Points.Clear();
            chartLamps.Series[2].Points.Clear();
            
            chartOrder.Series[0].Points.AddY(RequiredLamps);
            chartOrder.Series[1].Points.AddY(CompletedLamps);

            chartLamps.Series[0].Points.AddY(AllLamps);
            chartLamps.Series[1].Points.AddY(PassedLamps);
            chartLamps.Series[2].Points.AddY(FailedLamps);

            lblActiveWorkstations.Text = string.Format("Active Workstations: {0}", ActiveWorkstations);
        }

        private void RefreshBins(object sender, System.Timers.ElapsedEventArgs e)
        {
            sw.Restart();
            timer.Start();
            GetData("EXEC FillBins", dataAdapterConfig);
            runs++;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            simSpeed = Int32.Parse(GetData("Select Value FROM tblConfig WHERE [Option] = 'SimulationSpeed'", dataAdapterConfig).Rows[0][0].ToString());
            minutesPerRefill = Int32.Parse(GetData("Select Value FROM tblConfig WHERE [Option] = 'MinutesPerRefill'", dataAdapterConfig).Rows[0][0].ToString());
            t = new Thread(runTimer);
            t.Start();
            btnStartStop.Enabled = true;
            btnConnect.Enabled = false;
        }

        private DataTable GetData(string selectCommand, SqlDataAdapter sda)
        {
            DataTable table = new DataTable { Locale = CultureInfo.InvariantCulture };
            try
            {
                // Create a new data adapter based on the specified query.
                sda = new SqlDataAdapter(selectCommand, connectionString);

                // Create a command builder to generate SQL update, insert, and
                // delete commands based on selectCommand. 
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(sda);

                // Populate a new data table and bind it to the BindingSource.                
                sda.Fill(table);
                //bs.DataSource = table;
            }
            catch (SqlException)
            {
                MessageBox.Show("Error in the SQL connection");
            }
            return table;
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            isRunning = false;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            isRunning = false;
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            isPaused = !isPaused;
            if (isPaused) { btnStartStop.Text = "Start";}
            else { btnStartStop.Text = "Stop"; }
        }
    }
}
