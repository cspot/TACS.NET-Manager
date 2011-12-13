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
    public partial class Account : TD.SandDock.UserTabbedDocument, ITacsDocument
    {
        /// <summary>
        /// ApplicationForm property.
        /// </summary>
        private MainForm _ApplicationForm;
        /// <summary>
        /// NewRecord property.
        /// </summary>
        private bool _NewRecord;
        /// <summary>
        /// FormChanged property.
        /// </summary>
        private bool _FormChanged;
        /// <summary>
        /// AccountId property.
        /// </summary>
        private long _AccountId = -1;
        iCampaign.TACS.Data.AccountsDs.AccountsDataTable dataTable;
        iCampaign.TACS.Data.AccountsDsTableAdapters.AccountsTableAdapter tableAdapter;

        /// <summary>
        /// Initialize instance of account editor.
        /// </summary>
        /// <param name="parent"></param>
        public Account(MainForm parent)
        {
            //  Initialize properties and other objects
            _ApplicationForm = parent;
            dataTable = new iCampaign.TACS.Data.AccountsDs.AccountsDataTable();
            tableAdapter = new iCampaign.TACS.Data.AccountsDsTableAdapters.AccountsTableAdapter();
            tableAdapter.Connection = new System.Data.SqlClient.SqlConnection(TacsSession.ConnectionString);

            //  Initialize form components
            InitializeComponent();
            InitializeDocument();
        }

        /// <summary>
        /// Initialize instance of account editor.
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="acct"></param>
        public Account(MainForm parent, long acct)
        {
            //  Initialize properties and other objects
            _ApplicationForm = parent;
            _AccountId = acct;
            dataTable = new iCampaign.TACS.Data.AccountsDs.AccountsDataTable();
            tableAdapter = new iCampaign.TACS.Data.AccountsDsTableAdapters.AccountsTableAdapter();
            tableAdapter.Connection = new System.Data.SqlClient.SqlConnection(TacsSession.ConnectionString);

            //  Initialize form components
            InitializeComponent();
            InitializeDocument();
            GetRecord();
        }

        #region ITacsDocument Members

        /// <summary>
        /// Gets the main application form object.
        /// </summary>
        public MainForm ApplicationForm
        {
            get { return _ApplicationForm; }
        }

        /// <summary>
        /// Gets the flag indicating if form has changed.
        /// </summary>
        public bool FormChanged
        {
            get { return _FormChanged; }
        }

        /// <summary>
        /// Gets the flag indicating if this is a new record.
        /// </summary>
        public bool NewRecord
        {
            get { return _NewRecord; }
        }

        /// <summary>
        /// Get the requested record from the database.
        /// </summary>
        public void GetRecord()
        {
            try
            {
                tableAdapter.Connection.Open();
                tableAdapter.FillByAcctId(dataTable, this.AccountId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error getting account record",
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
                MessageBox.Show("The requested account record was not found. Maybe it was deleted.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }

            //  Now populate the form
            iCampaign.TACS.Data.AccountsDs.AccountsRow row = dataTable[0];
            this.SuspendLayout();
            tbAccount.Text = row.AcctName;
            tbAddress1.Text = row.Address1;
            tbAddress2.Text = row.Address2;
            tbCity.Text = row.City;
            tbContact.Text = row.Contact;
            tbEmail.Text = row.Email;
            tbPhone.Text = row.Phone;
            tbState.Text = row.State;
            tbZip.Text = row.ZipCode;
            this.ResumeLayout();

            _NewRecord = false;
            _FormChanged = false;
            btnSave.Enabled = true;
            this.Text = row.AcctName + " - [Account]";
        }

        /// <summary>
        /// Save record changes to the database.
        /// </summary>
        public void SaveRecord()
        {
            //  Check required fields
            if (tbAccount.Text.Length == 0)
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
        /// Initializes the state of the document.
        /// </summary>
        public void InitializeDocument()
        {
            this.SuspendLayout();
            btnSave.Enabled = false;
            this.Text = "New Account";

            tbAccount.Clear();
            tbAddress1.Clear();
            tbAddress2.Clear();
            tbCity.Clear();
            tbContact.Clear();
            tbEmail.Clear();
            tbPhone.Clear();
            tbState.Clear();
            tbZip.Clear();

            _NewRecord = true;
            _FormChanged = false;
            this.ResumeLayout();
        }

        #endregion

        /// <summary>
        /// Gets the id of the account currently being edited.
        /// </summary>
        public long AccountId
        {
            get { return _AccountId; }
        }

        /// <summary>
        /// Send the updated record to the database server.
        /// </summary>
        private void UpdateRecord()
        {
            iCampaign.TACS.Data.AccountsDs.AccountsRow row = dataTable[0];
            row.AcctName = tbAccount.Text;
            row.Address1 = tbAddress1.Text;
            row.Address2 = tbAddress2.Text;
            row.City = tbCity.Text;
            row.Contact = tbContact.Text;
            row.Email = tbEmail.Text;
            row.State = tbState.Text;
            row.ZipCode = tbZip.Text;
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
        /// Send the new record to the database.
        /// </summary>
        private void AddRecord()
        {
            iCampaign.TACS.Data.AccountsDs.AccountsRow row = dataTable.NewAccountsRow();
            row.AcctName = tbAccount.Text;
            row.Address1 = tbAddress1.Text;
            row.Address2 = tbAddress2.Text;
            row.City = tbCity.Text;
            row.Contact = tbContact.Text;
            row.Email = tbEmail.Text;
            row.State = tbState.Text;
            row.ZipCode = tbZip.Text;
            row.Phone = tbPhone.Text;
            row.CreatedOn = DateTime.Now;
            row.ExpireOn = Convert.ToDateTime("12/31/2099 12:00:00");
            dataTable.AddAccountsRow(row);

            //  Send update to the database
            try
            {
                tableAdapter.Connection.Open();
                tableAdapter.Update(dataTable);
                this.Text = row.AcctName + " - [Account]";
                btnSave.Enabled = true;
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
        /// Check fields and update form controls.
        /// </summary>
        private void CheckFields()
        {
            if (tbAccount.Text.Length != 0)
                btnSave.Enabled = true;
            else
                btnSave.Enabled = false;
        }

        /// <summary>
        /// Text box changed event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbAccount_TextChanged(object sender, EventArgs e)
        {
            CheckFields();
            _FormChanged = true;
        }

        /// <summary>
        /// Text box changed event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbContact_TextChanged(object sender, EventArgs e)
        {
            CheckFields();
            _FormChanged = true;
        }

        /// <summary>
        /// Text box changed event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbAddress1_TextChanged(object sender, EventArgs e)
        {
            CheckFields();
            _FormChanged = true;
        }

        /// <summary>
        /// Text box changed event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbAddress2_TextChanged(object sender, EventArgs e)
        {
            CheckFields();
            _FormChanged = true;
        }

        /// <summary>
        /// Text box changed event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbCity_TextChanged(object sender, EventArgs e)
        {
            CheckFields();
            _FormChanged = true;
        }

        /// <summary>
        /// Text box changed event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbState_TextChanged(object sender, EventArgs e)
        {
            CheckFields();
            _FormChanged = true;
        }

        /// <summary>
        /// Text box changed event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbZip_TextChanged(object sender, EventArgs e)
        {
            CheckFields();
            _FormChanged = true;
        }

        /// <summary>
        /// Text box changed event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbEmail_TextChanged(object sender, EventArgs e)
        {
            CheckFields();
            _FormChanged = true;
        }

        /// <summary>
        /// Text box changed event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbPhone_TextChanged(object sender, EventArgs e)
        {
            CheckFields();
            _FormChanged = true;
        }

        /// <summary>
        /// Save button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Activate(object sender, EventArgs e)
        {
            SaveRecord();
        }
    }
}
