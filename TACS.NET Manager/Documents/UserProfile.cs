using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TACS.NET_Manager.Documents
{
    /// <summary>
    /// Represents user profile editor tabbed document object.
    /// </summary>
    public partial class UserProfile : TD.SandDock.UserTabbedDocument, ITacsDocument
    {
        #region Private fields
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

        private long acctId;
        private string username;
        private bool passwordChange;
        private bool formLoading;
        private iCampaign.TACS.Data.UserDs.UsersDataTable dataTable;
        private iCampaign.TACS.Data.UserDsTableAdapters.UsersTableAdapter tableAdapter;
        private iCampaign.TACS.Data.UserRolesDsTableAdapters.UserRoleViewTableAdapter userAdapter;
        private iCampaign.TACS.Data.UserRoleViewDs.UserRoleViewDataTable roleTable;
        private iCampaign.TACS.Data.UserRoleViewDsTableAdapters.UserRoleViewTableAdapter roleAdapter;
        private iCampaign.TACS.Data.UserProjectsDs.UserProjectsDataTable projectTable;
        private iCampaign.TACS.Data.UserProjectsDsTableAdapters.UserProjectsTableAdapter projectAdapter;
        #endregion

        #region Constructors
        /// <summary>
        /// Initialize instance of user profile tabbed document.
        /// </summary>
        /// <param name="parent">MainForm: object.</param>
        /// <param name="aid">long: Account id.</param>
        public UserProfile(MainForm parent, long aid)
        {
            //  Initialize properties
            _ParentForm = parent;
            acctId = aid;
            passwordChange = true;
            InitializeData();

            //  Initialize tabbed document controls
            InitializeComponent();
            InitializeDocument();
        }

        /// <summary>
        /// Initialize instance of user profile tabbed document.
        /// </summary>
        /// <param name="parent">MainForm: object.</param>
        /// <param name="aid">long: Account id.</param>
        /// <param name="user">string: Username.</param>
        public UserProfile(MainForm parent, long aid, string user)
        {
            //  Initialize properties
            _ParentForm = parent;
            acctId = aid;
            username = user;
            InitializeData();

            //  Initialize tabbed document controls
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
        /// Get record from the database server.
        /// </summary>
        public void GetRecord()
        {
            //  Get the user profile
            try
            {
                tableAdapter.Connection.Open();
                tableAdapter.FillByUsername(dataTable, username);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error getting user record",
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
                MessageBox.Show("The requested user record was not found. Maybe it was deleted.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }

            //  Get the user project roles
            GetRoles();

            //  Display the record
            this.SuspendLayout();
            formLoading = true;
            iCampaign.TACS.Data.UserDs.UsersRow row = dataTable[0];
            this.Text = row.Username + " [User]";
            username = row.Username;
            tbUsername.Text = row.Username;
            tbUsername.ReadOnly = true;
            tbFullName.Text = row.FullName;
            tbEmail.Text = row.Email;
            if (row.ExpireOn.ToString() != "12/31/2199 12:00:00 AM")
            {
                chkExpire.Checked = true;
                dateExpire.Value = row.ExpireOn;
            }
            else
            {
                chkExpire.Checked = false;
            }
            chkDisable.Checked = row.UserDisabled;
            chkOwner.Checked = row.AccountOwner;
            chkSuper.Checked = row.SuperAdministrator;

            _NewRecord = false;
            _FormChanged = false;
            btnSave.Enabled = true;
            btnDelete.Enabled = true;
            btnClearSession.Enabled = true;
            formLoading = false;
            passwordChange = false;
            this.ResumeLayout();
        }

        /// <summary>
        /// Save record to the database server.
        /// </summary>
        public void SaveRecord()
        {
            bool errorStatus = false;

            //  Check required fields
            if (passwordChange || this.NewRecord)
            {
                if (!CheckPassword())
                {
                    MessageBox.Show("Your passwords do not match.  Please enter them again.",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbPass1.Clear();
                    tbPass2.Clear();
                    tbPass1.Focus();
                    errorStatus = true;
                }
            }
            if (!errorStatus)
            {
                if (tbUsername.Text.Length == 0)
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
                    this.ApplicationForm.ShowUsers();
                }
            }
        }

        public void PrintForm()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete the user profile record.
        /// </summary>
        public void DeleteRecord()
        {
            bool errorStatus = false;

            // Remove user project roles first
            try
            {
                projectAdapter.Connection.Open();
                projectAdapter.DeleteByUser(username);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error deleting user project roles.  Unable to delete profile.",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorStatus = true;
            }
            finally
            {
                projectAdapter.Connection.Close();
            }

            //  Now delete the user profile
            if (!errorStatus) 
            {
                try
                {
                    tableAdapter.Connection.Open();
                    tableAdapter.DeleteAccountUser(username, acctId);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error deleting user profile.",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errorStatus = true;
                }
                finally
                {
                    tableAdapter.Connection.Close();
                }
            }

            if (!errorStatus)
            {
                this.ApplicationForm.ShowUsers();
                this.Close();
                MessageBox.Show("User profile has been deleted.");
            }
        }

        /// <summary>
        /// Initialize the form controls to a default state.
        /// </summary>
        public void InitializeDocument()
        {
            this.SuspendLayout();
            formLoading = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            btnClearSession.Enabled = false;
            tabControl1.TabIndex = 1;

            //  Reset the form controls
            tbUsername.ReadOnly = false;
            tbUsername.Clear();
            tbFullName.Clear();
            tbPass1.Clear();
            tbPass2.Clear();
            tbEmail.Clear();
            chkExpire.Checked = false;
            dateExpire.Value = System.DateTime.Now;
            chkDisable.Checked = false;
            chkOwner.Checked = false;
            chkSuper.Checked = false;

            //  Clear the data tables
            dataTable.Clear();

            formLoading = false;
            _FormChanged = false;
            _NewRecord = true;
            this.Text = "New User";
            this.ResumeLayout();
        }
        #endregion

        /// <summary>
        /// Initialize all the ADO.NET objects.
        /// </summary>
        private void InitializeData()
        {
            dataTable = new iCampaign.TACS.Data.UserDs.UsersDataTable();
            tableAdapter = new iCampaign.TACS.Data.UserDsTableAdapters.UsersTableAdapter();
            tableAdapter.Connection = new System.Data.SqlClient.SqlConnection(TacsSession.ConnectionString);
            userAdapter = new iCampaign.TACS.Data.UserRolesDsTableAdapters.UserRoleViewTableAdapter();
            userAdapter.Connection = new System.Data.SqlClient.SqlConnection(TacsSession.ConnectionString);
            roleTable = new iCampaign.TACS.Data.UserRoleViewDs.UserRoleViewDataTable();
            roleAdapter = new iCampaign.TACS.Data.UserRoleViewDsTableAdapters.UserRoleViewTableAdapter();
            roleAdapter.Connection = new SqlConnection(TacsSession.ConnectionString);
            projectTable = new iCampaign.TACS.Data.UserProjectsDs.UserProjectsDataTable();
            projectAdapter = new iCampaign.TACS.Data.UserProjectsDsTableAdapters.UserProjectsTableAdapter();
            projectAdapter.Connection = new SqlConnection(TacsSession.ConnectionString);
        }

        /// <summary>
        /// Perform insert command against database.
        /// </summary>
        private void AddRecord()
        {
            iCampaign.TACS.Data.UserDs.UsersRow row = dataTable.NewUsersRow();
            row.Username = tbUsername.Text;
            row.FullName = tbFullName.Text;
            row.Password = iCampaign.TACS.Security.CreateHash(tbPass1.Text);
            row.Email = tbEmail.Text;
            if (chkExpire.Checked)
                row.ExpireOn = dateExpire.Value;
            else
                row.ExpireOn = Convert.ToDateTime("12/31/2199 12:00:00 AM");
            row.UserDisabled = chkDisable.Checked;
            row.AccountOwner = chkOwner.Checked;
            row.SuperAdministrator = chkSuper.Checked;
            row.CreatedOn = System.DateTime.Now;
            row.AcctId = acctId;
            dataTable.AddUsersRow(row);

            //  Send update to the database
            try
            {
                tableAdapter.Connection.Open();
                tableAdapter.Update(dataTable);
                _NewRecord = false;
                _FormChanged = false;
                passwordChange = false;
                this.Text = row.Username + " [User]";
                username = row.Username;
                tbUsername.ReadOnly = true;
                btnSave.Enabled = true;
                btnDelete.Enabled = true;
                btnClearSession.Enabled = true;
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
        /// Perform update command against database.
        /// </summary>
        private void UpdateRecord()
        {
            iCampaign.TACS.Data.UserDs.UsersRow row = dataTable[0];
            row.FullName = tbFullName.Text;
            if (passwordChange)
                row.Password = iCampaign.TACS.Security.CreateHash(tbPass1.Text);
            row.Email = tbEmail.Text;
            if (chkExpire.Checked)
                row.ExpireOn = dateExpire.Value;
            else
                row.ExpireOn = Convert.ToDateTime("12/31/2199 12:00:00 AM");
            row.UserDisabled = chkDisable.Checked;
            row.AccountOwner = chkOwner.Checked;
            row.SuperAdministrator = chkSuper.Checked;
            row.CreatedOn = System.DateTime.Now;

            //  Send update to the database
            try
            {
                tableAdapter.Connection.Open();
                tableAdapter.Update(dataTable);
                _NewRecord = false;
                _FormChanged = false;
                passwordChange = false;
                tbUsername.ReadOnly = true;
                btnSave.Enabled = true;
                btnDelete.Enabled = true;
                btnClearSession.Enabled = true;
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
        /// Expire checkbox click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkExpire_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExpire.Checked)
                dateExpire.Enabled = true;
            else
                dateExpire.Enabled = false;
            CheckFields();
            _FormChanged = true;
        }

        private void tbPass1_TextChanged(object sender, EventArgs e)
        {
            CheckFields();
            _FormChanged = true;
            passwordChange = true;
        }

        private void tbPass2_TextChanged(object sender, EventArgs e)
        {
            CheckFields();
            _FormChanged = true;
            passwordChange = true;
        }

        /// <summary>
        /// See if password fields match.
        /// </summary>
        /// <returns>bool</returns>
        private bool CheckPassword()
        {
            bool status = false;
            if (tbPass1.Text == tbPass2.Text)
                status = true;
            return status;
        }

        /// <summary>
        /// Perform field check and update control state.
        /// </summary>
        private void CheckFields()
        {
            if (tbUsername.Text.Length != 0)
                btnSave.Enabled = true;
            else
                btnSave.Enabled = false;
        }

        private void tbUsername_TextChanged(object sender, EventArgs e)
        {
            CheckFields();
            _FormChanged = true;
        }

        private void tbFullName_TextChanged(object sender, EventArgs e)
        {
            CheckFields();
            _FormChanged = true;
        }

        private void tbEmail_TextChanged(object sender, EventArgs e)
        {
            CheckFields();
            _FormChanged = true;
        }

        private void dateExpire_ValueChanged(object sender, EventArgs e)
        {
            CheckFields();
            _FormChanged = true;
        }

        private void chkDisable_CheckedChanged(object sender, EventArgs e)
        {
            CheckFields();
            _FormChanged = true;
        }

        private void chkOwner_CheckedChanged(object sender, EventArgs e)
        {
            CheckFields();
            _FormChanged = true;
        }

        private void chkSuper_CheckedChanged(object sender, EventArgs e)
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

        /// <summary>
        /// Delete button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Activate(object sender, EventArgs e)
        {
            if (MessageBox.Show("You are about to delete a user profile.  Do you wish to continue?",
                "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                DeleteRecord();
            }

        }

        /// <summary>
        /// Clear Session button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearSession_Activate(object sender, EventArgs e)
        {
            if (MessageBox.Show("You are about to clear the session token for this user.  Do you wish to continue?",
                "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                iCampaign.TACS.Data.UserDs.UsersRow row = dataTable[0];
                row.SessionToken = String.Empty;
                UpdateRecord();
            }
        }

        /// <summary>
        /// Add button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddProject_Activate(object sender, EventArgs e)
        {
            UserRoleEditor roleEditor = new UserRoleEditor(acctId, username);
            if (roleEditor.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    projectAdapter.Connection.Open();
                    projectAdapter.Insert(System.DateTime.Now, roleEditor.RoleId,
                        roleEditor.Project, username);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error inserting user role",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    projectAdapter.Connection.Close();
                }
                GetRoles();
            }
            roleEditor.Close();
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            btnAddProject.Enabled = false;
            btnDeleteProject.Enabled = false;
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            if (!this.NewRecord)
            {
                btnAddProject.Enabled = true;
                btnDeleteProject.Enabled = false;
            }
            else
            {
                btnAddProject.Enabled = false;
                btnDeleteProject.Enabled = false;
            }
        }

        /// <summary>
        /// Get the user role records and display.
        /// </summary>
        /// <param name="username">string: Username to get.</param>
        private void GetRoles()
        {
            //  Get the user roles
            try
            {
                roleAdapter.Connection.Open();
                roleAdapter.FillByUsername(roleTable, username);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error getting user roles",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                roleAdapter.Connection.Close();
            }

            //  Display the results
            projectView.Items.Clear();
            foreach (iCampaign.TACS.Data.UserRoleViewDs.UserRoleViewRow row in roleTable)
            {
                ListViewItem item = new ListViewItem();
                item.Name = row.RoleId.ToString();
                item.Text = row.Project;
                ListViewItem.ListViewSubItem roleItem = new ListViewItem.ListViewSubItem();
                roleItem.Text = row.RoleName;
                ListViewItem.ListViewSubItem accItem = new ListViewItem.ListViewSubItem();
                accItem.Text = TacsSession.GetAccessLevel((iCampaign.TACS.AccessLevelEnum)row.AccessLevel);
                item.SubItems.Add(roleItem);
                item.SubItems.Add(accItem);
                projectView.Items.Add(item);
            }
        }

        /// <summary>
        /// Project view selected index change.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void projectView_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAddProject.Enabled = true;
            btnDeleteProject.Enabled = true;
        }

        /// <summary>
        /// Delete button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteProject_Activate(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete user's access to this project?",
                "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) ==
                DialogResult.Yes)
            {
                //  Get the list item and determine record to edit
                ListViewItem item = projectView.SelectedItems[0];
                long roleId = Convert.ToInt64(item.Name);
                //  Find the record in the data table
                for (int x = 0; x < roleTable.Rows.Count; ++x)
                {
                    iCampaign.TACS.Data.UserRoleViewDs.UserRoleViewRow row = roleTable[x];
                    if (row.RoleId == roleId)
                    {
                        try
                        {
                            projectAdapter.Connection.Open();
                            projectAdapter.DeleteUserRole(roleId, username);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error deleting project from user",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            projectAdapter.Connection.Close();
                        }
                    }
                }
                GetRoles();
            }
        }
    }
}
