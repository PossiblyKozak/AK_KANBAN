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
        private string connectionString = ConfigurationManager.AppSettings["dbConnString"].ToString();

        private BindingSource bindingConfig = new BindingSource();
        private SqlDataAdapter dataAdapterConfig;

        public frmMain()
        {
            InitializeComponent();
            dgvConfig.DataSource = bindingConfig;

            dataAdapterConfig = new SqlDataAdapter("Select * FROM tblConfig", connectionString);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            GetData("Select * FROM tblConfig", dataAdapterConfig, bindingConfig);
            dgvConfig.Columns[0].ReadOnly = true;
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

        private void tbConnString_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dgvConfig.Columns[0].ReadOnly = false;
            dgvConfig.Columns[1].ReadOnly = false;
            dataAdapterConfig.UpdateCommand = new SqlCommandBuilder(dataAdapterConfig).GetUpdateCommand();
            dataAdapterConfig.Update((DataTable)bindingConfig.DataSource);
            dgvConfig.Columns[0].ReadOnly = true;
            dgvConfig.Columns[1].ReadOnly = true;
        }
    }
}
