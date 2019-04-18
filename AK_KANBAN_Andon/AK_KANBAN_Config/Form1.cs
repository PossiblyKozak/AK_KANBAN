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

namespace AK_KANBAN_Config
{
    public partial class frmMain : Form
    {
        System.Timers.Timer timer = new System.Timers.Timer();
        private delegate void ThreadSafeDelegate();

        private string connectionString = ConfigurationManager.AppSettings["dbConnString"].ToString();

        private BindingSource bindingConfig = new BindingSource();
        private SqlDataAdapter dataAdapterConfig;

        public frmMain()
        {
            InitializeComponent();
            timer.Elapsed += refreshBins;
            timer.Interval = 1000;
            timer.Start();
            dgvConfig.DataSource = bindingConfig;

            dataAdapterConfig = new SqlDataAdapter("Select * FROM tblConfig", connectionString);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            refreshBins();
        }

        void refreshBins()
        {
            GetData(string.Format("Select PartName, BinSize, BinLevel FROM tblPartBins WHERE WorkStationID = {0}", cbWorkstation.SelectedItem.ToString()), dataAdapterConfig, bindingConfig);
        }

        private void refreshBins(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                if (cbAutoRefresh.Checked)
                {
                    Invoke(new ThreadSafeDelegate(refreshBins));
                }
            }
            catch { }
        }

        private void GetData(string selectCommand, SqlDataAdapter sda, BindingSource bs)
        {
            try
            {
                // Create a new data adapter based on the specified query.
                sda = new SqlDataAdapter(selectCommand, connectionString);

                // Create a command builder to generate SQL update, insert, and
                // delete commands based on selectCommand. 
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(sda);

                // Populate a new data table and bind it to the BindingSource.
                DataTable table = new DataTable
                {
                    Locale = CultureInfo.InvariantCulture
                };
                sda.Fill(table);
                bs.DataSource = table;
            }
            catch (SqlException)
            {
                MessageBox.Show("To run this example, replace the value of the " +
                    "connectionString variable with a connection string that is " +
                    "valid for your system.");
            }
        }

        private void CbWorkstation_Click(object sender, EventArgs e)
        {
            cbWorkstation.Items.Clear();
            foreach (DataRow dr in GetData("SELECT ID FROM tblWorkStations WHERE IsActive = 1", dataAdapterConfig).Rows)
            {
                cbWorkstation.Items.Add(dr[0]);
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

        private void CbWorkstation_SelectedValueChanged(object sender, EventArgs e)
        {
            btnConnect.Enabled = cbWorkstation.SelectedItem != null;
            cbAutoRefresh.Enabled = cbWorkstation.SelectedItem != null;
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
        }
    }
}
