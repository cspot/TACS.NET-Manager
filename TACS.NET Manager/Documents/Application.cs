using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TACS.NET_Manager.Documents
{
    /// <summary>
    /// Represents application editor tabbed document object.
    /// </summary>
    public partial class Application : TD.SandDock.UserTabbedDocument, ITacsDocument
    {
        /// <summary>
        /// ParentForm property.
        /// </summary>
        private MainForm _ParentForm;
        /// <summary>
        /// FormChanged property.
        /// </summary>
        private bool _FormChanged;
        /// <summary>
        /// NewRecord property.
        /// </summary>
        private bool _NewRecord;

        private string applicationCode;
        private iCampaign.TACS.Data.ApplicationsDs.ApplicationsDataTable dataTable;
        private iCampaign.TACS.Data.ApplicationsDsTableAdapters.ApplicationsTableAdapter tableAdapter;

        #region Constructors

        /// <summary>
        /// Initialize instance of application tabbed document.
        /// </summary>
        /// <param name="parent">MainForm: object.</param>
        public Application(MainForm parent)
        {
            //  Initialize properties
            _ParentForm = parent;
            dataTable = new iCampaign.TACS.Data.ApplicationsDs.ApplicationsDataTable();
            tableAdapter = new iCampaign.TACS.Data.ApplicationsDsTableAdapters.ApplicationsTableAdapter();
            tableAdapter.Connection = new System.Data.SqlClient.SqlConnection(TacsSession.ConnectionString);

            //  Initialize the tabbed document
            InitializeComponent();
            InitializeDocument();
        }

        /// <summary>
        /// Initialize instance of application tabbed document.
        /// </summary>
        /// <param name="parent">MainForm: object.</param>
        /// <param name="appcode">string: Application code.</param>
        public Application(MainForm parent, string appcode)
        {
            //  Check the arguments
            if (appcode.Length == 0)
                throw new System.ArgumentException("You must provide an application code value.");
            else
                applicationCode = appcode;

            //  Initialize properties
            _ParentForm = parent;
            dataTable = new iCampaign.TACS.Data.ApplicationsDs.ApplicationsDataTable();
            tableAdapter = new iCampaign.TACS.Data.ApplicationsDsTableAdapters.ApplicationsTableAdapter();
            tableAdapter.Connection = new System.Data.SqlClient.SqlConnection(TacsSession.ConnectionString);

            //  Initialize the tabbed document
            InitializeComponent();
            InitializeDocument();
            GetRecord();
        }

        #endregion

        #region ITacsDocument Members

        /// <summary>
        /// Gets the parent form object reference.
        /// </summary>
        public MainForm ApplicationForm
        {
            get { return _ParentForm; }
        }

        /// <summary>
        /// Gets the form changed flag.
        /// </summary>
        public bool FormChanged
        {
            get { return _FormChanged; }
        }

        /// <summary>
        /// Gets the new record flag.
        /// </summary>
        public bool NewRecord
        {
            get { return _NewRecord; }
        }

        /// <summary>
        /// Get requested record from the database server.
        /// </summary>
        public void GetRecord()
        {
            try
            {
                tableAdapter.Connection.Open();
                tableAdapter.FillByAppCode(dataTable, applicationCode);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error getting application record",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            finally
            {
                tableAdapter.Connection.Close();
            }

            //  Check to see if a record was retrieved
            if (dataTable.Rows.Count == 0)
            {
                MessageBox.Show("The requested application record was not found. Maybe it was deleted.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }

            //  Update the form controls
            this.SuspendLayout();
            iCampaign.TACS.Data.ApplicationsDs.ApplicationsRow row = dataTable[0];
            tbAppCode.Text = row.AppCode;
            tbAppCode.ReadOnly = true;
            this.Text = row.AppCode + " [Application]";
            tbAppName.Text = row.AppName;
            tbContact.Text = row.Contact;
            tbDesc.Text = row.Description;
            tbEmail.Text = row.Email;
            tbGUID.Text = row.AppGuid;
            tbPhone.Text = row.Phone;
            tbURL.Text = row.DownloadURL;

            _NewRecord = false;
            _FormChanged = false;
            btnSave.Enabled = true;
            btnDelete.Enabled = true;
            this.ResumeLayout();
        }

        /// <summary>
        /// Save the application record to the database server.
        /// </summary>
        public void SaveRecord()
        {
            //  Check required fields
            if (tbAppCode.Text.Length == 0 || tbAppName.Text.Length == 0)
            {
                MessageBox.Show("All fields marked in red must be filled out!",
                    "Unable to save", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else 
            {
                //  Now determine what to do
                if (this.NewRecord)
                    AddRecord();
                else
                    UpdateRecord();
                this.ApplicationForm.ShowApplications();
            }
        }

        public void PrintForm()
        {
            throw new NotImplementedException();
        }

        public void DeleteRecord()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Initialize the document controls to a default state.
        /// </summary>
        public void InitializeDocument()
        {
            this.SuspendLayout();
            btnSave.Enabled = false;
            btnDelete.Enabled = false;

            this.Text = "New Application";

            //  Initialize fields
            tbAppCode.Clear();
            tbAppCode.ReadOnly = false;
            tbAppName.Clear();
            tbContact.Clear();
            tbDesc.Clear();
            tbEmail.Clear();
            tbGUID.Clear();
            tbPhone.Clear();
            tbURL.Clear();

            //  Update properties
            _NewRecord = true;
            _FormChanged = false;
            this.ResumeLayout();
        }

        #endregion

        /// <summary>
        /// Perform a database update command.
        /// </summary>
        private void UpdateRecord()
        {
            //  Update the data table
            iCampaign.TACS.Data.ApplicationsDs.ApplicationsRow row = dataTable[0];
            row.AppGuid = tbGUID.Text;
            row.AppName = tbAppName.Text;
            row.Contact = tbContact.Text;
            row.Description = tbDesc.Text;
            row.DownloadURL = tbURL.Text;
            row.Email = tbEmail.Text;
            row.Phone = tbPhone.Text;
            
            //  Send update to the database
            try
            {
                tableAdapter.Connection.Open();
                tableAdapter.Update(dataTable);
                _NewRecord = false;
                _FormChanged = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error saving record", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                tableAdapter.Connection.Close();
            }
        }

        /// <summary>
        /// Perform a database insert command.
        /// </summary>
        private void AddRecord()
        {
            //  Update the data table
            iCampaign.TACS.Data.ApplicationsDs.ApplicationsRow row =
                dataTable.NewApplicationsRow();
            row.AppCode = tbAppCode.Text;
            row.AppGuid = tbGUID.Text;
            row.AppName = tbAppName.Text;
            row.Contact = tbContact.Text;
            row.Description = tbDesc.Text;
            row.DownloadURL = tbURL.Text;
            row.Email = tbEmail.Text;
            row.Phone = tbPhone.Text;
            dataTable.AddApplicationsRow(row);

            //  Send update to the database
            try
            {
                tableAdapter.Connection.Open();
                tableAdapter.Update(dataTable);
                _NewRecord = false;
                _FormChanged = false;
                this.Text = row.AppCode + " [Application]";
                tbAppCode.ReadOnly = true;
                btnSave.Enabled = true;
                btnDelete.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error saving record", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                tableAdapter.Connection.Close();
            }
        }

        /// <summary>
        /// Perform field check and update control state.
        /// </summary>
        private void CheckFields()
        {
            if (tbAppCode.Text.Length != 0 || tbAppName.Text.Length != 0)
                btnSave.Enabled = true;
            else
                btnSave.Enabled = false;
        }

        private void tbAppCode_TextChanged(object sender, EventArgs e)
        {
            CheckFields();
            _FormChanged = true;
        }

        private void tbAppName_TextChanged(object sender, EventArgs e)
        {
            CheckFields();
            _FormChanged = true;
        }

        private void tbDesc_TextChanged(object sender, EventArgs e)
        {
            CheckFields();
            _FormChanged = true;
        }

        private void tbGUID_TextChanged(object sender, EventArgs e)
        {
            CheckFields();
            _FormChanged = true;
        }

        private void tbURL_TextChanged(object sender, EventArgs e)
        {
            CheckFields();
            _FormChanged = true;
        }

        private void tbContact_TextChanged(object sender, EventArgs e)
        {
            CheckFields();
            _FormChanged = true;
        }

        private void tbEmail_TextChanged(object sender, EventArgs e)
        {
            CheckFields();
            _FormChanged = true;
        }

        private void tbPhone_TextChanged(object sender, EventArgs e)
        {
            CheckFields();
            _FormChanged = true;
        }

        private void btnSave_Activate(object sender, EventArgs e)
        {
            SaveRecord();
        }

        private void btnDelete_Activate(object sender, EventArgs e)
        {
            MessageBox.Show("Feature not implemented.");
        }

        /// <summary>
        /// Form is closing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Application_Closing(object sender, TD.SandDock.DockControlClosingEventArgs e)
        {
            if (this.FormChanged)
            {
                if (MessageBox.Show("Do you wish to save your changes first?",
                    "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SaveRecord();
                }
            }
        }
    }
}
