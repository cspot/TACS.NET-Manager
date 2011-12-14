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
    public partial class Project : TD.SandDock.UserTabbedDocument, ITacsDocument
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

        private string project;
        private long acctId;
        private iCampaign.TACS.Data.ProjectsDs.ProjectsDataTable dataTable;
        private iCampaign.TACS.Data.ProjectsDsTableAdapters.ProjectsTableAdapter tableAdapter;
        private iCampaign.TACS.Data.ApplicationsDs.ApplicationsDataTable appTable;
        private iCampaign.TACS.Data.ApplicationsDsTableAdapters.ApplicationsTableAdapter appTableAdapter;
        private iCampaign.TACS.Data.RolesDs.RolesDataTable roleTable;
        private iCampaign.TACS.Data.RolesDsTableAdapters.RolesTableAdapter roleAdapter;
        #endregion

        #region Constructors

        /// <summary>
        /// Initialize instance of the project tabbed document.
        /// </summary>
        /// <param name="parent">MainForm: object.</param>
        /// <param name="aid">long: Account id.</param>
        public Project(MainForm parent, long aid)
        {
            //  Initialize properties
            acctId = aid;
            _ParentForm = parent;
            dataTable = new iCampaign.TACS.Data.ProjectsDs.ProjectsDataTable();
            tableAdapter = new iCampaign.TACS.Data.ProjectsDsTableAdapters.ProjectsTableAdapter();
            tableAdapter.Connection = new System.Data.SqlClient.SqlConnection(TacsSession.ConnectionString);
            appTable = new iCampaign.TACS.Data.ApplicationsDs.ApplicationsDataTable();
            appTableAdapter = new iCampaign.TACS.Data.ApplicationsDsTableAdapters.ApplicationsTableAdapter();
            appTableAdapter.Connection = new System.Data.SqlClient.SqlConnection(TacsSession.ConnectionString);
            roleTable = new iCampaign.TACS.Data.RolesDs.RolesDataTable();
            roleAdapter = new iCampaign.TACS.Data.RolesDsTableAdapters.RolesTableAdapter();
            roleAdapter.Connection = new System.Data.SqlClient.SqlConnection(TacsSession.ConnectionString);

            //  Initialize tabbed document controls
            InitializeComponent();
            InitializeDocument();
        }

        /// <summary>
        /// Initialize instance of the project tabbed document.
        /// </summary>
        /// <param name="parent">MainForm: object.</param>
        /// <param name="proj">string: Project name.</param>
        public Project(MainForm parent, long aid, string proj)
        {
            //  Check the arguments
            if (proj.Length == 0)
            {
                throw new System.ArgumentException("You must provide an project name value.");
            }
            else
            {
                project = proj;
                acctId = aid;
            }

            //  Initialize properties
            _ParentForm = parent;
            dataTable = new iCampaign.TACS.Data.ProjectsDs.ProjectsDataTable();
            tableAdapter = new iCampaign.TACS.Data.ProjectsDsTableAdapters.ProjectsTableAdapter();
            tableAdapter.Connection = new System.Data.SqlClient.SqlConnection(TacsSession.ConnectionString);
            appTable = new iCampaign.TACS.Data.ApplicationsDs.ApplicationsDataTable();
            appTableAdapter = new iCampaign.TACS.Data.ApplicationsDsTableAdapters.ApplicationsTableAdapter();
            appTableAdapter.Connection = new System.Data.SqlClient.SqlConnection(TacsSession.ConnectionString);
            roleTable = new iCampaign.TACS.Data.RolesDs.RolesDataTable();
            roleAdapter = new iCampaign.TACS.Data.RolesDsTableAdapters.RolesTableAdapter();
            roleAdapter.Connection = new System.Data.SqlClient.SqlConnection(TacsSession.ConnectionString);

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
        /// Get requested record from the database server.
        /// </summary>
        public void GetRecord()
        {
            try
            {
                tableAdapter.Connection.Open();
                tableAdapter.FillByProject(dataTable, project);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error getting project record",
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
                MessageBox.Show("The requested project record was not found. Maybe it was deleted.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }

            //  Update the form controls
            this.SuspendLayout();
            iCampaign.TACS.Data.ProjectsDs.ProjectsRow row = dataTable[0];
            cbApp.SelectedIndex = GetAppIndex(row.AppCode);
            tbDatabase.Text = row.Database;
            tbDataSource.Text = row.DataSource;
            tbPass.Text = row.Password;
            tbProject.Text = row.Project;
            tbProject.ReadOnly = true;
            tbUser.Text = row.Username;
            cbConnector.SelectedIndex = (int)TacsSession.GetConnectorType(row.ConnectorType);

            _NewRecord = false;
            _FormChanged = false;
            btnSave.Enabled = true;
            btnDelete.Enabled = true;
            this.Text = row.Project + " [Project]";

            GetRoles();
            this.ResumeLayout();
        }

        /// <summary>
        /// Save the project record to the database server.
        /// </summary>
        public void SaveRecord()
        {
            //  Check required fields
            if (tbProject.Text.Length == 0)
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
                this.ApplicationForm.ShowProjects();
            }
        }

        public void PrintForm()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete the project from the database.
        /// </summary>
        public void DeleteRecord()
        {
            // First verify there are no users assigned to this project.
            if (CheckForUsers(project))
            {
                MessageBox.Show("You must first remove all users from this project before deleting it!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                this.ApplicationForm.ShowProjects();
            }
            else
            {
                if (RemoveProject(project, this.ApplicationForm.CurrentAccountId))
                {
                    this.ApplicationForm.ShowProjects();
                    MessageBox.Show("Project successfully deleted.");
                    this.Close();
                }
            }
        }

        /// <summary>
        /// Initialize the document controls to a default state.
        /// </summary>
        public void InitializeDocument()
        {
            this.SuspendLayout();
            btnSave.Enabled = false;
            btnDelete.Enabled = false;

            this.Text = "New Project";

            //  Initialize fields
            cbApp.Items.Clear();
            GetApplications();
            tbProject.Clear();
            tbProject.ReadOnly = false;
            cbConnector.SelectedIndex = 0;
            tbDataSource.Clear();
            tbDatabase.Clear();
            tbUser.Clear();
            tbPass.Clear();

            //  Initialize properties
            _NewRecord = true;
            _FormChanged = false;
            this.ResumeLayout();
        }

        #endregion

        /// <summary>
        /// Get list of current applications and bind to combobox control.
        /// </summary>
        private void GetApplications()
        {
            try
            {
                appTableAdapter.Connection.Open();
                appTableAdapter.Fill(appTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error getting application records",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ResumeLayout();
                this.Close();
            }
            finally
            {
                appTableAdapter.Connection.Close();
            }

            //  Bind the data table to the control
            for (int x = 0; x < appTable.Rows.Count; ++x)
            {
                StringBuilder item = new StringBuilder();
                item.Append("[" + appTable[x]["AppCode"].ToString() + "]");
                item.Append(" " + appTable[x]["AppName"].ToString());
                cbApp.Items.Add(item.ToString());
            }
            cbApp.Refresh();
        }

        /// <summary>
        /// Perform database update command.
        /// </summary>
        private void UpdateRecord()
        {
            iCampaign.TACS.Data.ProjectsDs.ProjectsRow row = dataTable[0];
            row.AppCode = GetAppName(cbApp.SelectedIndex);
            row.ConnectorType = ((iCampaign.TACS.ConnectorEnum)cbConnector.SelectedIndex).ToString();
            row.Database = tbDatabase.Text;
            row.DataSource = tbDataSource.Text;
            row.Password = tbPass.Text;
            row.Username = tbUser.Text;

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
        /// Perform database insert command.
        /// </summary>
        private void AddRecord()
        {
            iCampaign.TACS.Data.ProjectsDs.ProjectsRow row = dataTable.NewProjectsRow();
            row.Project = tbProject.Text;
            row.AppCode = GetAppName(cbApp.SelectedIndex);
            row.ConnectorType = ((iCampaign.TACS.ConnectorEnum)cbConnector.SelectedIndex).ToString();
            row.Database = tbDatabase.Text;
            row.DataSource = tbDataSource.Text;
            row.Password = tbPass.Text;
            row.Username = tbUser.Text;
            row.CreatedOn = System.DateTime.Now;
            row.AcctId = acctId;
            dataTable.AddProjectsRow(row);

            //  Send update to the database
            try
            {
                tableAdapter.Connection.Open();
                tableAdapter.Update(dataTable);
                _NewRecord = false;
                _FormChanged = false;
                this.Text = row.Project + " [Project]";
                project = row.Project;
                tbProject.ReadOnly = true;
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
        /// Return connector type string from integral value.
        /// </summary>
        /// <param name="i">int: Selected index value.</param>
        /// <returns>string</returns>
        private string GetConnector(int i)
        {
            string result = String.Empty;
            switch (i)
            {
                case 0:
                    result = iCampaign.TACS.ConnectorEnum.SQL_SERVER.ToString();
                    break;
                case 1:
                    result = iCampaign.TACS.ConnectorEnum.MYSQL.ToString();
                    break;
            }
            return result;
        }

        /// <summary>
        /// Perform field check and update control state.
        /// </summary>
        private void CheckFields()
        {
            if (tbProject.Text.Length != 0)
                btnSave.Enabled = true;
            else
                btnSave.Enabled = false;
        }

        private void cbApp_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckFields();
            _FormChanged = true;
        }

        private void tbProject_TextChanged(object sender, EventArgs e)
        {
            CheckFields();
            _FormChanged = true;
        }

        private void cbConnector_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckFields();
            _FormChanged = true;
        }

        private void tbDataSource_TextChanged(object sender, EventArgs e)
        {
            CheckFields();
            _FormChanged = true;
        }

        private void tbDatabase_TextChanged(object sender, EventArgs e)
        {
            CheckFields();
            _FormChanged = true;
        }

        private void tbUser_TextChanged(object sender, EventArgs e)
        {
            CheckFields();
            _FormChanged = true;
        }

        private void tbPass_TextChanged(object sender, EventArgs e)
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
            if (MessageBox.Show("You are about to delete this project and all of its roles!  Are you sure?", "Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                DeleteRecord();
            }
        }

        /// <summary>
        /// Build a connection string based on the form items.
        /// </summary>
        /// <returns>string</returns>
        private string BuildConnectionString()
        {
            string connStr = String.Empty;
            switch ((iCampaign.TACS.ConnectorEnum)cbConnector.SelectedIndex)
            {
                case iCampaign.TACS.ConnectorEnum.SQL_SERVER:
                    //  Build a connection string for MS SQL Server
                    SqlConnectionStringBuilder connBuilder = new SqlConnectionStringBuilder();
                    connBuilder.ApplicationName = tbProject.Text;
                    connBuilder.ConnectTimeout = 120;
                    connBuilder.DataSource = tbDataSource.Text;
                    connBuilder.InitialCatalog = tbDatabase.Text;
                    connBuilder.IntegratedSecurity = false;
                    connBuilder.Password = tbPass.Text;
                    connBuilder.Pooling = true;
                    connBuilder.UserID = tbUser.Text;
                    connStr = connBuilder.ToString();
                    break;
                case iCampaign.TACS.ConnectorEnum.MYSQL:
                    break;
            }
            return connStr;
        }

        /// <summary>
        /// Show Connection String button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShow_Click(object sender, EventArgs e)
        {
            MessageBox.Show(BuildConnectionString(), "Connection string",
                MessageBoxButtons.OK);
        }

        /// <summary>
        /// Test Connection button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTest_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = BuildConnectionString();
            try
            {
                sqlConnection.Open();
                MessageBox.Show("Connection test successful!", "Test Connection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Connection test failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        /// <summary>
        /// Document closing event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Project_Closing(object sender, TD.SandDock.DockControlClosingEventArgs e)
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

        /// <summary>
        /// Locate the application code in a data table.
        /// </summary>
        /// <param name="app">string: Application code.</param>
        /// <returns>int: ordinal</returns>
        private int GetAppIndex(string app)
        {
            int i = -1;
            for (int x = 0; x < appTable.Rows.Count; ++x)
            {
                if (appTable[x]["AppCode"].ToString() == app)
                    i = x;
            }
            return i;
        }

        /// <summary>
        /// Get the application code at the index position in the data table.
        /// </summary>
        /// <param name="i">int: ordinal</param>
        /// <returns>string</returns>
        private string GetAppName(int i)
        {
            return appTable[i]["AppCode"].ToString();
        }

        /// <summary>
        /// Project tab entered event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabPage1_Enter(object sender, EventArgs e)
        {
            btnAddRole.Enabled = false;
            btnDeleteRole.Enabled = false;
            btnEditRole.Enabled = false;
        }

        /// <summary>
        /// Role table entered event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabPage2_Enter(object sender, EventArgs e)
        {
            btnAddRole.Enabled = true;
            btnDeleteRole.Enabled = false;
            btnEditRole.Enabled = false;
        }

        /// <summary>
        /// Get the project roles from the database.
        /// </summary>
        private void GetRoles()
        {
            //  Get role records from the database
            try
            {
                roleAdapter.Connection.Open();
                roleAdapter.FillByProject(roleTable, project);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error getting roles",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ResumeLayout();
                this.Close();
            }
            finally
            {
                roleAdapter.Connection.Close();
            }

            //  Display the records
            roleView.Items.Clear();
            foreach (iCampaign.TACS.Data.RolesDs.RolesRow row in roleTable)
            {
                ListViewItem item = new ListViewItem();
                item.Name = row.RoleId.ToString();
                item.Text = row.RoleName;
                ListViewItem.ListViewSubItem accessItem = new ListViewItem.ListViewSubItem();
                accessItem.Text = TacsSession.GetAccessLevel((iCampaign.TACS.AccessLevelEnum)row.AccessLevel);
                item.SubItems.Add(accessItem);
                roleView.Items.Add(item);
            }
        }

        private void roleView_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAddRole.Enabled = true;
            btnEditRole.Enabled = true;
            btnDeleteRole.Enabled = true;
        }

        /// <summary>
        /// Open role in editor.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void roleView_DoubleClick(object sender, EventArgs e)
        {
            //  Get the list item and determine record to edit
            ListViewItem item = roleView.SelectedItems[0];
            long roleId = Convert.ToInt64(item.Name);
            iCampaign.TACS.Role role = new iCampaign.TACS.Role();
            int rowNum = -1;

            //  Find the record in the data table
            for (int x = 0; x < roleTable.Rows.Count; ++x)
            {
                iCampaign.TACS.Data.RolesDs.RolesRow row = roleTable[x];
                if (row.RoleId == roleId)
                {
                    role.Name = row.RoleName;
                    role.AccessLevel = (iCampaign.TACS.AccessLevelEnum)row.AccessLevel;
                    rowNum = x;
                }
            }

            //  Edit the role record
            RoleEditor roleEditor = new RoleEditor(project, role);
            if (roleEditor.ShowDialog() == DialogResult.OK)
            {
                iCampaign.TACS.Data.RolesDs.RolesRow row = roleTable[rowNum];
                row.RoleName = roleEditor.Role.Name;
                row.AccessLevel = (int)roleEditor.Role.AccessLevel;

                //  Save the changes and refresh the list view control
                UpdateRoles();
                GetRoles();
            }
            roleEditor.Close();
        }

        /// <summary>
        /// Add button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddRole_Activate(object sender, EventArgs e)
        {
            RoleEditor roleEditor = new RoleEditor(project);
            if (roleEditor.ShowDialog() == DialogResult.OK)
            {
                iCampaign.TACS.Data.RolesDs.RolesRow row =
                    roleTable.NewRolesRow();
                row.AccessLevel = (int)roleEditor.Role.AccessLevel;
                row.RoleName = roleEditor.Role.Name;
                row.Project = project;
                roleTable.AddRolesRow(row);
                UpdateRoles();
                GetRoles();
            }
            roleEditor.Close();
        }

        /// <summary>
        /// Edit button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditRole_Activate(object sender, EventArgs e)
        {
            roleView_DoubleClick(this, EventArgs.Empty);
        }

        /// <summary>
        /// Delete button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteRole_Activate(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this role?",
                "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) ==
                DialogResult.Yes)
            {
                //  Get the list item and determine record to edit
                ListViewItem item = roleView.SelectedItems[0];
                long roleId = Convert.ToInt64(item.Name);
                //  Find the record in the data table
                for (int x = 0; x < roleTable.Rows.Count; ++x)
                {
                    iCampaign.TACS.Data.RolesDs.RolesRow row = roleTable[x];
                    if (row.RoleId == roleId)
                    {
                        try
                        {
                            roleAdapter.Connection.Open();
                            roleAdapter.DeleteByRole(row.RoleId, row.RoleName);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error deleting role",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            roleAdapter.Connection.Close();
                        }
                    }
                }
                GetRoles();
            }
        }

        /// <summary>
        /// Save the role data table changes.
        /// </summary>
        private void UpdateRoles()
        {
            try
            {
                roleAdapter.Connection.Open();
                roleAdapter.Update(roleTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error saving roles", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                roleAdapter.Connection.Close();
            }
        }

        /// <summary>
        /// Check to see if there are any users assigned to specified project.
        /// </summary>
        /// <param name="project">string: Project name.</param>
        /// <returns>bool: Result.</returns>
        private bool CheckForUsers(string project)
        {
            bool usersExist = true;
            int recordCount = 0;
            
            //  Initialize data objects
            iCampaign.TACS.Data.UserRoleViewDsTableAdapters.UserRoleViewTableAdapter userTableAdapter =
                new iCampaign.TACS.Data.UserRoleViewDsTableAdapters.UserRoleViewTableAdapter();
            userTableAdapter.Connection.ConnectionString = TacsSession.ConnectionString;

            //  Get the record count
            try
            {
                userTableAdapter.Connection.Open();
                recordCount = (int)userTableAdapter.CountProjectUsers(project);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An error occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                userTableAdapter.Connection.Close();
            }

            if (recordCount > 0)
                usersExist = true;
            else
                usersExist = false;
            
            return usersExist;
        }

        /// <summary>
        /// Delete the project and role records from the database.
        /// </summary>
        /// <param name="whichProject">string: Project name.</param>
        /// <returns>bool: Success status.</returns>
        private bool RemoveProject(string whichProject, long acctId)
        {
            bool returnStatus = false;

            if (DeleteRoles(whichProject))
            {
                returnStatus = DeleteProject(whichProject, acctId);
            }

            return returnStatus;
        }

        /// <summary>
        /// Delete the roles for this project.
        /// </summary>
        /// <param name="whichProject">string: Project name.</param>
        /// <returns>bool: Success status.</returns>
        private bool DeleteRoles(string whichProject)
        {
            bool returnStatus = false;

            try
            {
                roleAdapter.Connection.Open();
                roleAdapter.DeleteByProject(whichProject);
                returnStatus = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error deleting project roles", MessageBoxButtons.OK, MessageBoxIcon.Error);
                returnStatus = false;
            }
            finally
            {
                roleAdapter.Connection.Close();
            }

            return returnStatus;
        }

        /// <summary>
        /// Delete the specificed project from the database.
        /// </summary>
        /// <param name="whichProject">string: Project name.</param>
        /// <param name="acctId">long: Account id.</param>
        /// <returns>bool: Success status.</returns>
        private bool DeleteProject(string whichProject, long acctId)
        {
            bool returnStatus = false;

            try
            {
                tableAdapter.Connection.Open();
                tableAdapter.DeleteProject(whichProject, acctId);
                returnStatus = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An error occurred deleting project", MessageBoxButtons.OK, MessageBoxIcon.Error);
                returnStatus = false;
            }
            finally
            {
                tableAdapter.Connection.Close();
            }

            return returnStatus;
        }
    }
}
