using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.Win32;
//using VoterMart.ETL.Connector;

namespace TACS.NET_Manager
{
    /// <summary>
    /// Represents the graphical user interface for TACS.NET Manager application.
    /// </summary>
    public partial class MainForm : Form
    {
        #region Fields

        Documents.Events eventViewer;
        Documents.GettingStarted gettingStarted;
        Documents.GettingStarted onlineHelp;

        /// <summary>
        /// CurrentAccountId property.
        /// </summary>
        private long _CurrentAccountId = -1;
        /// <summary>
        /// CurrentAccount property.
        /// </summary>
        private string _CurrentAccount = String.Empty;
        /// <summary>
        /// Flag indicating form is loading.
        /// </summary>
        private bool formLoading;
        /// <summary>
        /// Flag indicating database connection string was changed.
        /// </summary>
        private bool databaseChanged;

        #endregion

        #region Constructor

        /// <summary>
        /// Initialize instance of TACS.NET Manager user interface.
        /// </summary>
        public MainForm()
        {
            //  Check for database connection string
            if (GetRegistryKey().Length == 0)
            {
                ChangeDbSettings();
            }

            //  Now initialize form
            InitializeComponent();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the current account id.
        /// </summary>
        public long CurrentAccountId
        {
            get { return _CurrentAccountId; }
        }

        /// <summary>
        /// Gets the current account name.
        /// </summary>
        public string CurrentAccount
        {
            get { return _CurrentAccount; }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Display the available TACS.NET applications registered in the database.
        /// </summary>
        public void ShowApplications()
        {
            bool errorStatus = false;

            this.SuspendLayout();
            Cursor.Current = Cursors.WaitCursor;
            treeApps.Nodes.Clear();

            //  Get the applications from the database
            ProjectService projService = new ProjectService();
            iCampaign.TACS.Data.ApplicationsDs.ApplicationsDataTable dataTable;
            try
            {
                dataTable = projService.GetApplications();
                RefreshAppNodes(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unable to display applications", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                errorStatus = true;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                this.ResumeLayout();
            }

            //  If there's no connection string, exit the application
            if (formLoading && errorStatus)
                Application.Exit();
        }

        /// <summary>
        /// Display the projects registered under the open account.
        /// </summary>
        public void ShowProjects()
        {
            this.SuspendLayout();
            Cursor.Current = Cursors.WaitCursor;
            treeProj.Nodes.Clear();

            //  Get the applications from the database
            ProjectService projService = new ProjectService();
            iCampaign.TACS.Data.ProjectsDs.ProjectsDataTable dataTable;
            try
            {
                dataTable = projService.GetProjects(this.CurrentAccountId);
                RefreshProjNodes(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unable to display projects", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                this.ResumeLayout();
            }
        }

        /// <summary>
        /// Display the users registered under the open account.
        /// </summary>
        public void ShowUsers()
        {
            this.SuspendLayout();
            Cursor.Current = Cursors.WaitCursor;
            treeUser.Nodes.Clear();

            //  Get the applications from the database
            AccessService accessService = new AccessService();
            iCampaign.TACS.Data.UserDs.UsersDataTable dataTable;
            try
            {
                dataTable = accessService.GetUsers(this.CurrentAccountId);
                RefreshUserNodes(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unable to display users", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                this.ResumeLayout();
            }
        }

        /// <summary>
        /// Close the event viewer.
        /// </summary>
        public void CloseEventViewer()
        {
            if (mnuEvents.Checked)
            {
                eventViewer = null;
                mnuEvents.Checked = false;
            }
        }

        /// <summary>
        /// Close getting started document.
        /// </summary>
        public void CloseGettingStarted()
        {
            if (mnuGettingStarted.Checked)
            {
                gettingStarted = null;
                mnuGettingStarted.Checked = false;
            }
        }

        /// <summary>
        /// Edit the database connection settings.
        /// </summary>
        public void ChangeDbSettings()
        {
            //  Get the connection string from registry
            string connstr = GetRegistryKey();

            //  Instantiate edit form
            ConnectBox connForm;
            if (connstr.Length == 0)
            {
                connForm = new ConnectBox();
            }
            else
            {
                connForm = new ConnectBox(connstr);
            }

            //  Allow user to edit the connection string and update registry key
            if (connForm.ShowDialog() == DialogResult.OK)
            {
                SetRegistryKey(connForm.ConnectionString);
                databaseChanged = true;
            }

            connForm.Close();
        }
        #endregion

        #region Private methods

        /// <summary>
        /// Display the contents of the data table in the applications dockable window.
        /// </summary>
        /// <param name="dataTable">iCampaign.TACS.Data.ApplicationsDs.ApplicationsDataTable</param>
        private void RefreshAppNodes(iCampaign.TACS.Data.ApplicationsDs.ApplicationsDataTable dataTable)
        {
            foreach (iCampaign.TACS.Data.ApplicationsDs.ApplicationsRow row in dataTable)
            {
                TreeNode node = new TreeNode();
                node.Name = row.AppCode;
                node.Text = row.AppName;
                node.SelectedImageIndex = 0;
                node.ImageIndex = 0;
                treeApps.Nodes.Add(node);
            }
        }

        /// <summary>
        /// Main user interface load event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            //  Show the applications dock
            formLoading = true;
            ShowApplications();
            AccountIsClosed();
            mnuGettingStarted_Activate(this, EventArgs.Empty);
        }

        /// <summary>
        /// About menu command event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuAbout_Activate(object sender, EventArgs e)
        {
            AboutBox aboutDlog = new AboutBox();
            aboutDlog.ShowDialog();
        }

        /// <summary>
        /// Display the contents of the data table in the projects dockable window.
        /// </summary>
        /// <param name="dataTable">iCampaign.TACS.Data.ProjectsDs.ProjectsDataTable</param>
        private void RefreshProjNodes(iCampaign.TACS.Data.ProjectsDs.ProjectsDataTable dataTable)
        {
            foreach (iCampaign.TACS.Data.ProjectsDs.ProjectsRow row in dataTable)
            {
                TreeNode node = new TreeNode();
                node.Name = row.Project;
                node.Text = row.Project;
                node.SelectedImageIndex = 3;
                node.ImageIndex = 3;
                treeProj.Nodes.Add(node);
            }
        }

        /// <summary>
        /// Display the contents of the data table in the users dockable window.
        /// </summary>
        /// <param name="dataTable"></param>
        private void RefreshUserNodes(iCampaign.TACS.Data.UserDs.UsersDataTable dataTable)
        {
            foreach (iCampaign.TACS.Data.UserDs.UsersRow row in dataTable)
            {
                TreeNode node = new TreeNode();
                node.Name = row.Username;
                node.Text = row.Username + " (" + row.FullName + ")";
                node.SelectedImageIndex = 2;
                node.ImageIndex = 2;
                treeUser.Nodes.Add(node);
            }
        }

        /// <summary>
        /// Open Account menu command event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuOpenAcct_Activate(object sender, EventArgs e)
        {
            bool errorStatus = false;

            Cursor.Current = Cursors.WaitCursor;
            iCampaign.TACS.Data.AccountsDs.AccountsDataTable dataTable = null;
            ProjectService projService = new ProjectService();
            try
            {
                dataTable = projService.GetAccounts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unable to get accounts", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorStatus = true;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

            if (!errorStatus)
            {
                AccountsBox accountsDlog = new AccountsBox(dataTable);
                if (accountsDlog.ShowDialog() == DialogResult.OK)
                {
                    _CurrentAccountId = accountsDlog.SelectedAccountId;
                    _CurrentAccount = accountsDlog.SelectedAccount;
                    LoadAccount(this.CurrentAccountId);
                }
            }
        }

        /// <summary>
        /// Update the user interface with the selected account id.
        /// </summary>
        /// <param name="p">long: Account id.</param>
        private void LoadAccount(long p)
        {
            ShowProjects();
            ShowUsers();
            AccountIsOpen();
        }

        /// <summary>
        /// Refresh button in Application Explorer command event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefreshApp_Activate(object sender, EventArgs e)
        {
            ShowApplications();
        }

        /// <summary>
        /// Add button in Application Explorer command event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddApp_Activate(object sender, EventArgs e)
        {
            mnuNewApp_Activate(this, EventArgs.Empty);
        }

        /// <summary>
        /// Delete button in Application Explorer command event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelApp_Activate(object sender, EventArgs e)
        {
            MessageBox.Show("This feature has not been implemented.");
        }

        /// <summary>
        /// Refresh button in Project Explorer command event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefreshProj_Activate(object sender, EventArgs e)
        {
            ShowProjects();
        }

        /// <summary>
        /// Add button in Project Explorer command event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddProj_Activate(object sender, EventArgs e)
        {
            mnuAddProject_Activate(this, EventArgs.Empty);
        }

        /// <summary>
        /// Delete button in Project Explorer command event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelProj_Activate(object sender, EventArgs e)
        {
            Documents.Project projectDoc = new TACS.NET_Manager.Documents.Project(this, this.CurrentAccountId,
                treeProj.SelectedNode.Name);
            if (MessageBox.Show("You are about to delete this project and all of its roles!  Are you sure?", "Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                projectDoc.DeleteRecord();
                ShowProjects();
            }
        }

        /// <summary>
        /// Refresh button in User Explorer command event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefreshUser_Activate(object sender, EventArgs e)
        {
            ShowUsers();
        }

        /// <summary>
        /// Add button in User Explorer command event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddUser_Activate(object sender, EventArgs e)
        {
            Documents.UserProfile userDoc = new TACS.NET_Manager.Documents.UserProfile(this,
                this.CurrentAccountId);
            userDoc.Manager = sandDockManager1;
            userDoc.OpenDocked(TD.SandDock.ContainerDockLocation.Center);
        }

        /// <summary>
        /// Delete button in User Explorer command event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelUser_Activate(object sender, EventArgs e)
        {
            Documents.UserProfile userDoc = new TACS.NET_Manager.Documents.UserProfile(this,
                this.CurrentAccountId, treeUser.SelectedNode.Name);
            if (MessageBox.Show("You are about to delete a user profile.  Do you wish to continue?",
                "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
               userDoc.DeleteRecord();
               ShowUsers();
            }
        }

        /// <summary>
        /// Close Account menu command event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuCloseAcct_Activate(object sender, EventArgs e)
        {
            AccountIsClosed();
        }

        /// <summary>
        /// Update user interface if account is open.
        /// </summary>
        private void AccountIsOpen()
        {
            this.SuspendLayout();
            this.Text = this.CurrentAccount + " - TACS.NET Manager";

            //  Update menu items
            mnuAdd.Enabled = true;
            mnuCloseAcct.Enabled = true;
            mnuAcctSettings.Enabled = true;
            mnuUndo.Enabled = true;
            mnuCut.Enabled = true;
            mnuCopy.Enabled = true;
            mnuPaste.Enabled = true;
            mnuDelete.Enabled = true;

            //  Update tool bars
            toolProj.Enabled = true;
            toolUser.Enabled = true;
            this.ResumeLayout();
        }

        /// <summary>
        /// Update user interface if account is closed.
        /// </summary>
        private void AccountIsClosed()
        {
            this.SuspendLayout();
            this.Text = "TACS.NET Manager";

            //  Update menu items
            mnuAdd.Enabled = false;
            mnuCloseAcct.Enabled = false;
            mnuAcctSettings.Enabled = false;
            mnuUndo.Enabled = false;
            mnuCut.Enabled = false;
            mnuCopy.Enabled = false;
            mnuPaste.Enabled = false;
            mnuDelete.Enabled = false;
            mnuDbSettings.Enabled = true;

            //  Update tool bars
            toolProj.Enabled = false;
            toolUser.Enabled = false;

            //  Update the tree view controls
            treeProj.Nodes.Clear();
            treeUser.Nodes.Clear();
            this.ResumeLayout();
        }

        /// <summary>
        /// Application Explorer menu item event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuViewApps_Activate(object sender, EventArgs e)
        {
            if (dockApplications.DockSituation == TD.SandDock.DockSituation.None)
                dockApplications.Open();
            else
                dockApplications.Close();
        }

        /// <summary>
        /// Application Explorer dock event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dockApplications_DockSituationChanged(object sender, EventArgs e)
        {
            if (dockApplications.DockSituation == TD.SandDock.DockSituation.None)
                mnuViewApps.Checked = false;
            else
                mnuViewApps.Checked = true;
        }

        /// <summary>
        /// Project Explorer dock event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dockProjects_DockSituationChanged(object sender, EventArgs e)
        {
            if (dockProjects.DockSituation == TD.SandDock.DockSituation.None)
                mnuViewProjects.Checked = false;
            else
                mnuViewProjects.Checked = true;
        }

        /// <summary>
        /// User Explorer dock event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dockUsers_DockSituationChanged(object sender, EventArgs e)
        {
            if (dockUsers.DockSituation == TD.SandDock.DockSituation.None)
                mnuViewUsers.Checked = false;
            else
                mnuViewUsers.Checked = true;
        }

        /// <summary>
        /// Project Explorer menu item event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuViewProjects_Activate(object sender, EventArgs e)
        {
            if (dockProjects.DockSituation == TD.SandDock.DockSituation.None)
                dockProjects.Open();
            else
                dockProjects.Close();
        }

        /// <summary>
        /// User Explorer menu item event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuViewUsers_Activate(object sender, EventArgs e)
        {
            if (dockUsers.DockSituation == TD.SandDock.DockSituation.None)
                dockUsers.Open();
            else
                dockUsers.Close();
        }

        /// <summary>
        /// New application menu item event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuNewApp_Activate(object sender, EventArgs e)
        {
            Documents.Application appDoc = new TACS.NET_Manager.Documents.Application(this);
            appDoc.Manager = sandDockManager1;
            appDoc.OpenDocked(TD.SandDock.ContainerDockLocation.Center);
        }

        /// <summary>
        /// Application Explorer double-click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeApps_DoubleClick(object sender, EventArgs e)
        {
            string appcode = treeApps.SelectedNode.Name;
            Documents.Application appDoc = new TACS.NET_Manager.Documents.Application(this, appcode);
            appDoc.Manager = sandDockManager1;
            appDoc.OpenDocked(TD.SandDock.ContainerDockLocation.Center);
        }

        /// <summary>
        /// Getting Started menu item event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuGettingStarted_Activate(object sender, EventArgs e)
        {
            if (mnuGettingStarted.Checked == false)
            {
                if (gettingStarted == null)
                    gettingStarted = new TACS.NET_Manager.Documents.GettingStarted(this);
                gettingStarted.Manager = sandDockManager1;
                gettingStarted.OpenDocked(TD.SandDock.ContainerDockLocation.Center);
                mnuGettingStarted.Checked = true;
            }
            else
            {
                gettingStarted.Close();
                gettingStarted = null;
                mnuGettingStarted.Checked = false;
            }
        }

        /// <summary>
        /// Add Project menu item event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuAddProject_Activate(object sender, EventArgs e)
        {
            Documents.Project projectDoc = new TACS.NET_Manager.Documents.Project(this, this.CurrentAccountId);
            projectDoc.Manager = sandDockManager1;
            projectDoc.OpenDocked(TD.SandDock.ContainerDockLocation.Center);
        }

        /// <summary>
        /// Open selected project.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeProj_DoubleClick(object sender, EventArgs e)
        {
            Documents.Project projectDoc = new TACS.NET_Manager.Documents.Project(this, this.CurrentAccountId,
                treeProj.SelectedNode.Name);
            projectDoc.Manager = sandDockManager1;
            projectDoc.OpenDocked(TD.SandDock.ContainerDockLocation.Center);
        }

        /// <summary>
        /// Event viewer menu item event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuEvents_Activate(object sender, EventArgs e)
        {
            if (mnuEvents.Checked == false)
            {
                if (eventViewer == null)
                    eventViewer = new TACS.NET_Manager.Documents.Events(this);
                eventViewer.Manager = sandDockManager1;
                eventViewer.OpenDocked(TD.SandDock.ContainerDockLocation.Center);
                mnuEvents.Checked = true;
            }
            else
            {
                eventViewer.Close();
                eventViewer = null;
                mnuEvents.Checked = false;
            }
        }

        /// <summary>
        /// Open selected user profile.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeUser_DoubleClick(object sender, EventArgs e)
        {
            Documents.UserProfile userDoc = new TACS.NET_Manager.Documents.UserProfile(this, 
                this.CurrentAccountId, treeUser.SelectedNode.Name);
            userDoc.Manager = sandDockManager1;
            userDoc.OpenDocked(TD.SandDock.ContainerDockLocation.Center);
        }

        /// <summary>
        /// Exit menu item event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuExit_Activate(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Open roles menu item event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuOpenRoles_Activate(object sender, EventArgs e)
        {
            ProjectsBox projectBox = new ProjectsBox(this.CurrentAccountId);
            if (projectBox.ShowDialog() == DialogResult.OK)
            {
                Documents.Roles rolesDoc = new TACS.NET_Manager.Documents.Roles(this, projectBox.SelectedProject);
                rolesDoc.Manager = sandDockManager1;
                rolesDoc.OpenDocked(TD.SandDock.ContainerDockLocation.Center);
            }
            projectBox.Close();
        }

        /// <summary>
        /// Role button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRoles_Activate(object sender, EventArgs e)
        {
            Documents.Roles rolesDoc = 
                new TACS.NET_Manager.Documents.Roles(this, treeProj.SelectedNode.Name);
            rolesDoc.Manager = sandDockManager1;
            rolesDoc.OpenDocked(TD.SandDock.ContainerDockLocation.Center);
        }

        /// <summary>
        /// Window...Close All Documents
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuCloseAll_Activate(object sender, EventArgs e)
        {
            foreach (TD.SandDock.DockControl control in sandDockManager1.GetDockControls())
            {
                if (control.DockSituation == TD.SandDock.DockSituation.Document)
                {
                    control.Close();
                }
            }
        }

        /// <summary>
        /// File...New...Account menu command.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuNewAcct_Activate(object sender, EventArgs e)
        {
            Documents.Account acctDoc = new TACS.NET_Manager.Documents.Account(this);
            acctDoc.Manager = sandDockManager1;
            acctDoc.OpenDocked(TD.SandDock.ContainerDockLocation.Center);
        }

        /// <summary>
        /// Edit...Account Settings menu command.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuAcctSettings_Activate(object sender, EventArgs e)
        {
            Documents.Account acctDoc = new TACS.NET_Manager.Documents.Account(this, this.CurrentAccountId);
            acctDoc.Manager = sandDockManager1;
            acctDoc.OpenDocked(TD.SandDock.ContainerDockLocation.Center);
        }

        /// <summary>
        /// Edit...Undo menu command.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuUndo_Activate(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Edit...Cut menu command.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuCut_Activate(object sender, EventArgs e)
        {
           
        }

        /// <summary>
        /// Edit...Copy menu command.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuCopy_Activate(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Edit...Paste menu command.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuPaste_Activate(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Edit...Delete menu command.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuDelete_Activate(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Edit...Database settings command.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuDbSettings_Activate(object sender, EventArgs e)
        {
            //  Display the database connection dialog
            ChangeDbSettings();

            //  Check to see if things have changed
            if (databaseChanged)
            {
                if (MessageBox.Show("You must now restart the application.",
                    "Database Connection Changed", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    Application.Restart();
                }
            }
            else
            {
                databaseChanged = false;
            }
        }

        /// <summary>
        /// Check the registry key for the database connection string.
        /// </summary>
        /// <returns>string</returns>
        private string GetRegistryKey()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\cSpot InterWorks\\TACS\\TacsDbConnect");
            if (key == null)
            {
                key = Registry.CurrentUser.CreateSubKey("Software\\cSpot InterWorks\\TACS\\TacsDbConnect");
                key.SetValue("ConnectionString", String.Empty);
            }
            string dbstr = key.GetValue("ConnectionString").ToString();
            key.Close();
            return dbstr;
        }

        /// <summary>
        /// Set the registry key for the database connection string.
        /// </summary>
        /// <param name="connstr">string: Database connection.</param>
        private void SetRegistryKey(string connstr)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\cSpot InterWorks\\TACS\\TacsDbConnect", true);
            if (connstr.Length != 0)
            {
                key.SetValue("ConnectionString", connstr);
            }
            key.Close();
        }
 
        /// <summary>
        /// Help menu command.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuHelp_Activate(object sender, EventArgs e)
        {
            if (onlineHelp == null)
            {
                onlineHelp = new TACS.NET_Manager.Documents.GettingStarted(this, "\\Help.htm", "Help");
                onlineHelp.Manager = sandDockManager1;
                onlineHelp.OpenDocked(TD.SandDock.ContainerDockLocation.Center);
            }
            else
            {
                onlineHelp.Close();
                onlineHelp = null;
            }
        }
        #endregion
    }
}
