using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TACS.NET_Manager
{
    public partial class ConnectBox : Form
    {
        /// <summary>
        /// ConnectionString property.
        /// </summary>
        private System.Data.SqlClient.SqlConnectionStringBuilder _SqlConnectionStringBuilder;
        /// <summary>
        /// Flag indicating if form is in loading state.
        /// </summary>
        private bool formLoading;

        /// <summary>
        /// Initialize instance of connection editor dialog.
        /// </summary>
        public ConnectBox()
        {
            InitializeComponent();
            _SqlConnectionStringBuilder = new 
                System.Data.SqlClient.SqlConnectionStringBuilder();
        }

        /// <summary>
        /// Initialize instance of connection editor dialog.
        /// </summary>
        /// <param name="connstr">string: Connection string.</param>
        public ConnectBox(string connstr)
        {
            InitializeComponent();
            _SqlConnectionStringBuilder = new 
                System.Data.SqlClient.SqlConnectionStringBuilder(connstr);
        }

        /// <summary>
        /// Gets the connection string created by the dialog.
        /// </summary>
        public string ConnectionString
        {
            get
            {
                return _SqlConnectionStringBuilder.ConnectionString;
            }
        }

        /// <summary>
        /// Form loading event handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnectBox_Load(object sender, EventArgs e)
        {
            //  Set load flag to block operations
            formLoading = true;
            ShowConnector();

            //  Unblock operations
            formLoading = false;
        }

        /// <summary>
        /// Initialize the form and display the connection information.
        /// </summary>
        private void ShowConnector()
        {
            //  Reset the state of the form
            this.SuspendLayout();
            tbHost.Clear();
            tbPass.Clear();
            tbUser.Clear();
            chkTrustedConn.Checked = false;
            btnCancel.Enabled = true;
            btnOkay.Enabled = false;
            cbDatabase.Items.Clear();
            
            //  Now load the connection string info
            tbHost.Text = _SqlConnectionStringBuilder.DataSource;
            tbUser.Text = _SqlConnectionStringBuilder.UserID;
            tbPass.Text = _SqlConnectionStringBuilder.Password;
            cbDatabase.Text = _SqlConnectionStringBuilder.InitialCatalog;
            chkTrustedConn.Checked = _SqlConnectionStringBuilder.IntegratedSecurity;
            this.ResumeLayout();
        }

        /// <summary>
        /// Text box changed event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbHost_TextChanged(object sender, EventArgs e)
        {
            if (!formLoading)
                _SqlConnectionStringBuilder.DataSource = tbHost.Text.ToString();
        }

        /// <summary>
        /// Checkbox change event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkTrustedConn_CheckedChanged(object sender, EventArgs e)
        {
            if (!formLoading)
            {
                if (chkTrustedConn.Checked)
                {
                    tbUser.Clear();
                    tbPass.Clear();
                    tbUser.Enabled = false;
                    tbPass.Enabled = false;
                }
                else
                {
                    tbUser.Enabled = true;
                    tbPass.Enabled = true;
                }
            }
        }

        /// <summary>
        /// Text box changed event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbUser_TextChanged(object sender, EventArgs e)
        {
            if (!formLoading)
                _SqlConnectionStringBuilder.UserID = tbUser.Text.ToString();
        }

        /// <summary>
        /// Text box changed event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbPass_TextChanged(object sender, EventArgs e)
        {
            if (!formLoading)
                _SqlConnectionStringBuilder.Password = tbPass.Text.ToString();
        }

        /// <summary>
        /// Okay button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOkay_Click(object sender, EventArgs e)
        {
            _SqlConnectionStringBuilder.Pooling = true;
            _SqlConnectionStringBuilder.WorkstationID = "TACS-MANAGER";
            _SqlConnectionStringBuilder.ConnectTimeout = 60;
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Cancel button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Retrieve list of available databases from target server.
        /// </summary>
        private void GetDatabaseList(SqlConnectionStringBuilder connectionString)
        {
            Cursor.Current = Cursors.WaitCursor;

            SqlConnection sqlConn;
            SqlCommand sqlCmd;
            SqlDataReader sqlReader;

            //  We're using the master table to query what databases are available
            connectionString.InitialCatalog = "master";

            //  Initialize sql objects
            sqlConn = new SqlConnection(connectionString.ConnectionString);
            sqlCmd = new SqlCommand("select * from sysdatabases order by name",
                sqlConn);

            //  Now read the database and populate the combobox
            cbDatabase.Items.Clear();
            try
            {
                sqlConn.Open();
                sqlReader = sqlCmd.ExecuteReader();
                while (sqlReader.Read())
                {
                    cbDatabase.Items.Add(sqlReader["name"]);
                }
                sqlReader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConn.Close();
                Cursor.Current = Cursors.Default;
            }
            cbDatabase.SelectedIndex = 0;
        }

        /// <summary>
        /// Refresh button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                GetDatabaseList(_SqlConnectionStringBuilder);
                btnOkay.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database error");
            }
        }

        /// <summary>
        /// Combo box event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!formLoading && cbDatabase.Items.Count > 0)
            {
                _SqlConnectionStringBuilder.InitialCatalog = cbDatabase.SelectedItem.ToString();
                btnOkay.Enabled = true;
            }
        }
    }
}
