namespace TACS.NET_Manager
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.sandBarManager1 = new TD.SandBar.SandBarManager(this.components);
            this.leftSandBarDock = new TD.SandBar.ToolBarContainer();
            this.rightSandBarDock = new TD.SandBar.ToolBarContainer();
            this.bottomSandBarDock = new TD.SandBar.ToolBarContainer();
            this.topSandBarDock = new TD.SandBar.ToolBarContainer();
            this.menuBar1 = new TD.SandBar.MenuBar();
            this.menuBarItem1 = new TD.SandBar.MenuBarItem();
            this.mnuNew = new TD.SandBar.MenuButtonItem();
            this.mnuNewApp = new TD.SandBar.MenuButtonItem();
            this.mnuNewAcct = new TD.SandBar.MenuButtonItem();
            this.mnuOpen = new TD.SandBar.MenuButtonItem();
            this.mnuOpenAcct = new TD.SandBar.MenuButtonItem();
            this.mnuAdd = new TD.SandBar.MenuButtonItem();
            this.mnuAddProject = new TD.SandBar.MenuButtonItem();
            this.mnuAddUser = new TD.SandBar.MenuButtonItem();
            this.mnuClose = new TD.SandBar.MenuButtonItem();
            this.mnuCloseAcct = new TD.SandBar.MenuButtonItem();
            this.mnuExit = new TD.SandBar.MenuButtonItem();
            this.menuBarItem2 = new TD.SandBar.MenuBarItem();
            this.mnuUndo = new TD.SandBar.MenuButtonItem();
            this.mnuCut = new TD.SandBar.MenuButtonItem();
            this.mnuCopy = new TD.SandBar.MenuButtonItem();
            this.mnuPaste = new TD.SandBar.MenuButtonItem();
            this.mnuDelete = new TD.SandBar.MenuButtonItem();
            this.mnuAcctSettings = new TD.SandBar.MenuButtonItem();
            this.mnuDbSettings = new TD.SandBar.MenuButtonItem();
            this.menuBarItem3 = new TD.SandBar.MenuBarItem();
            this.mnuViewApps = new TD.SandBar.MenuButtonItem();
            this.mnuViewProjects = new TD.SandBar.MenuButtonItem();
            this.mnuViewUsers = new TD.SandBar.MenuButtonItem();
            this.mnuEvents = new TD.SandBar.MenuButtonItem();
            this.mnuGettingStarted = new TD.SandBar.MenuButtonItem();
            this.menuBarItem4 = new TD.SandBar.MenuBarItem();
            this.mnuCloseAll = new TD.SandBar.MenuButtonItem();
            this.menuBarItem5 = new TD.SandBar.MenuBarItem();
            this.mnuAbout = new TD.SandBar.MenuButtonItem();
            this.statusBar1 = new TD.SandBar.StatusBar();
            this.statusBarItem1 = new TD.SandBar.StatusBarItem();
            this.sandDockManager1 = new TD.SandDock.SandDockManager();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dockContainer2 = new TD.SandDock.DockContainer();
            this.dockProjects = new TD.SandDock.DockableWindow();
            this.treeProj = new System.Windows.Forms.TreeView();
            this.toolProj = new TD.SandBar.ToolBar();
            this.btnRefreshProj = new TD.SandBar.ButtonItem();
            this.btnAddProj = new TD.SandBar.ButtonItem();
            this.btnDelProj = new TD.SandBar.ButtonItem();
            this.dockUsers = new TD.SandDock.DockableWindow();
            this.treeUser = new System.Windows.Forms.TreeView();
            this.toolUser = new TD.SandBar.ToolBar();
            this.btnRefreshUser = new TD.SandBar.ButtonItem();
            this.btnAddUser = new TD.SandBar.ButtonItem();
            this.btnDelUser = new TD.SandBar.ButtonItem();
            this.dockContainer1 = new TD.SandDock.DockContainer();
            this.dockApplications = new TD.SandDock.DockableWindow();
            this.treeApps = new System.Windows.Forms.TreeView();
            this.toolApps = new TD.SandBar.ToolBar();
            this.btnRefreshApp = new TD.SandBar.ButtonItem();
            this.btnAddApp = new TD.SandBar.ButtonItem();
            this.btnDelApp = new TD.SandBar.ButtonItem();
            this.topSandBarDock.SuspendLayout();
            this.dockContainer2.SuspendLayout();
            this.dockProjects.SuspendLayout();
            this.dockUsers.SuspendLayout();
            this.dockContainer1.SuspendLayout();
            this.dockApplications.SuspendLayout();
            this.SuspendLayout();
            // 
            // sandBarManager1
            // 
            this.sandBarManager1.OwnerForm = this;
            this.sandBarManager1.Renderer = new TD.SandBar.WhidbeyRenderer();
            // 
            // leftSandBarDock
            // 
            this.leftSandBarDock.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftSandBarDock.Guid = new System.Guid("ab1abf78-0bff-4d6e-80a9-e7c57b9965b2");
            this.leftSandBarDock.Location = new System.Drawing.Point(0, 23);
            this.leftSandBarDock.Manager = this.sandBarManager1;
            this.leftSandBarDock.Name = "leftSandBarDock";
            this.leftSandBarDock.Size = new System.Drawing.Size(0, 522);
            this.leftSandBarDock.TabIndex = 0;
            // 
            // rightSandBarDock
            // 
            this.rightSandBarDock.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightSandBarDock.Guid = new System.Guid("9813b56c-cde2-4585-9de2-5717bf321628");
            this.rightSandBarDock.Location = new System.Drawing.Point(784, 23);
            this.rightSandBarDock.Manager = this.sandBarManager1;
            this.rightSandBarDock.Name = "rightSandBarDock";
            this.rightSandBarDock.Size = new System.Drawing.Size(0, 522);
            this.rightSandBarDock.TabIndex = 1;
            // 
            // bottomSandBarDock
            // 
            this.bottomSandBarDock.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomSandBarDock.Guid = new System.Guid("ea048b95-7db0-4b39-9436-1d0e699a4f6c");
            this.bottomSandBarDock.Location = new System.Drawing.Point(0, 545);
            this.bottomSandBarDock.Manager = this.sandBarManager1;
            this.bottomSandBarDock.Name = "bottomSandBarDock";
            this.bottomSandBarDock.Size = new System.Drawing.Size(784, 0);
            this.bottomSandBarDock.TabIndex = 2;
            // 
            // topSandBarDock
            // 
            this.topSandBarDock.Controls.Add(this.menuBar1);
            this.topSandBarDock.Dock = System.Windows.Forms.DockStyle.Top;
            this.topSandBarDock.Guid = new System.Guid("5d565c6c-ced5-4be1-b9c2-3c2262779fb9");
            this.topSandBarDock.Location = new System.Drawing.Point(0, 0);
            this.topSandBarDock.Manager = this.sandBarManager1;
            this.topSandBarDock.Name = "topSandBarDock";
            this.topSandBarDock.Size = new System.Drawing.Size(784, 23);
            this.topSandBarDock.TabIndex = 3;
            // 
            // menuBar1
            // 
            this.menuBar1.Guid = new System.Guid("bc7c411a-5f74-44f6-b798-bb784c6d652b");
            this.menuBar1.Items.AddRange(new TD.SandBar.ToolbarItemBase[] {
            this.menuBarItem1,
            this.menuBarItem2,
            this.menuBarItem3,
            this.menuBarItem4,
            this.menuBarItem5});
            this.menuBar1.Location = new System.Drawing.Point(2, 0);
            this.menuBar1.Name = "menuBar1";
            this.menuBar1.OwnerForm = this;
            this.menuBar1.Renderer = new TD.SandBar.WhidbeyRenderer();
            this.menuBar1.Size = new System.Drawing.Size(782, 23);
            this.menuBar1.TabIndex = 0;
            this.menuBar1.Text = "menuBar1";
            // 
            // menuBarItem1
            // 
            this.menuBarItem1.Items.AddRange(new TD.SandBar.ToolbarItemBase[] {
            this.mnuNew,
            this.mnuOpen,
            this.mnuAdd,
            this.mnuClose,
            this.mnuCloseAcct,
            this.mnuExit});
            this.menuBarItem1.Text = "&File";
            // 
            // mnuNew
            // 
            this.mnuNew.Items.AddRange(new TD.SandBar.ToolbarItemBase[] {
            this.mnuNewApp,
            this.mnuNewAcct});
            this.mnuNew.Text = "New";
            // 
            // mnuNewApp
            // 
            this.mnuNewApp.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
            this.mnuNewApp.Text = "Application...";
            this.mnuNewApp.Activate += new System.EventHandler(this.mnuNewApp_Activate);
            // 
            // mnuNewAcct
            // 
            this.mnuNewAcct.BeginGroup = true;
            this.mnuNewAcct.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftN;
            this.mnuNewAcct.Text = "Account...";
            this.mnuNewAcct.Activate += new System.EventHandler(this.mnuNewAcct_Activate);
            // 
            // mnuOpen
            // 
            this.mnuOpen.BeginGroup = true;
            this.mnuOpen.Items.AddRange(new TD.SandBar.ToolbarItemBase[] {
            this.mnuOpenAcct});
            this.mnuOpen.Text = "Open";
            // 
            // mnuOpenAcct
            // 
            this.mnuOpenAcct.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.mnuOpenAcct.Text = "Account...";
            this.mnuOpenAcct.Activate += new System.EventHandler(this.mnuOpenAcct_Activate);
            // 
            // mnuAdd
            // 
            this.mnuAdd.Items.AddRange(new TD.SandBar.ToolbarItemBase[] {
            this.mnuAddProject,
            this.mnuAddUser});
            this.mnuAdd.Text = "Add";
            // 
            // mnuAddProject
            // 
            this.mnuAddProject.Text = "Project...";
            this.mnuAddProject.Activate += new System.EventHandler(this.mnuAddProject_Activate);
            // 
            // mnuAddUser
            // 
            this.mnuAddUser.Text = "User Profile...";
            // 
            // mnuClose
            // 
            this.mnuClose.BeginGroup = true;
            this.mnuClose.Shortcut = System.Windows.Forms.Shortcut.CtrlW;
            this.mnuClose.Text = "Close";
            // 
            // mnuCloseAcct
            // 
            this.mnuCloseAcct.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftW;
            this.mnuCloseAcct.Text = "Close Account";
            this.mnuCloseAcct.Activate += new System.EventHandler(this.mnuCloseAcct_Activate);
            // 
            // mnuExit
            // 
            this.mnuExit.BeginGroup = true;
            this.mnuExit.Shortcut = System.Windows.Forms.Shortcut.F4;
            this.mnuExit.Text = "Exit";
            this.mnuExit.Activate += new System.EventHandler(this.mnuExit_Activate);
            // 
            // menuBarItem2
            // 
            this.menuBarItem2.Items.AddRange(new TD.SandBar.ToolbarItemBase[] {
            this.mnuUndo,
            this.mnuCut,
            this.mnuCopy,
            this.mnuPaste,
            this.mnuDelete,
            this.mnuAcctSettings,
            this.mnuDbSettings});
            this.menuBarItem2.Text = "&Edit";
            // 
            // mnuUndo
            // 
            this.mnuUndo.Shortcut = System.Windows.Forms.Shortcut.CtrlZ;
            this.mnuUndo.Text = "Undo";
            this.mnuUndo.Activate += new System.EventHandler(this.mnuUndo_Activate);
            // 
            // mnuCut
            // 
            this.mnuCut.BeginGroup = true;
            this.mnuCut.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
            this.mnuCut.Text = "Cut";
            this.mnuCut.Activate += new System.EventHandler(this.mnuCut_Activate);
            // 
            // mnuCopy
            // 
            this.mnuCopy.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
            this.mnuCopy.Text = "Copy";
            this.mnuCopy.Activate += new System.EventHandler(this.mnuCopy_Activate);
            // 
            // mnuPaste
            // 
            this.mnuPaste.Shortcut = System.Windows.Forms.Shortcut.CtrlV;
            this.mnuPaste.Text = "Paste";
            this.mnuPaste.Activate += new System.EventHandler(this.mnuPaste_Activate);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Shortcut = System.Windows.Forms.Shortcut.Del;
            this.mnuDelete.Text = "Delete";
            this.mnuDelete.Activate += new System.EventHandler(this.mnuDelete_Activate);
            // 
            // mnuAcctSettings
            // 
            this.mnuAcctSettings.BeginGroup = true;
            this.mnuAcctSettings.Text = "Account Settings...";
            this.mnuAcctSettings.Activate += new System.EventHandler(this.mnuAcctSettings_Activate);
            // 
            // mnuDbSettings
            // 
            this.mnuDbSettings.Text = "Database Settings...";
            this.mnuDbSettings.Activate += new System.EventHandler(this.mnuDbSettings_Activate);
            // 
            // menuBarItem3
            // 
            this.menuBarItem3.Items.AddRange(new TD.SandBar.ToolbarItemBase[] {
            this.mnuViewApps,
            this.mnuViewProjects,
            this.mnuViewUsers,
            this.mnuEvents,
            this.mnuGettingStarted});
            this.menuBarItem3.Text = "&View";
            // 
            // mnuViewApps
            // 
            this.mnuViewApps.Checked = true;
            this.mnuViewApps.Shortcut = System.Windows.Forms.Shortcut.F5;
            this.mnuViewApps.Text = "Applications Explorer";
            this.mnuViewApps.Activate += new System.EventHandler(this.mnuViewApps_Activate);
            // 
            // mnuViewProjects
            // 
            this.mnuViewProjects.Checked = true;
            this.mnuViewProjects.Shortcut = System.Windows.Forms.Shortcut.F6;
            this.mnuViewProjects.Text = "Projects Explorer";
            this.mnuViewProjects.Activate += new System.EventHandler(this.mnuViewProjects_Activate);
            // 
            // mnuViewUsers
            // 
            this.mnuViewUsers.Checked = true;
            this.mnuViewUsers.Shortcut = System.Windows.Forms.Shortcut.F7;
            this.mnuViewUsers.Text = "User Profiles";
            this.mnuViewUsers.Activate += new System.EventHandler(this.mnuViewUsers_Activate);
            // 
            // mnuEvents
            // 
            this.mnuEvents.BeginGroup = true;
            this.mnuEvents.Shortcut = System.Windows.Forms.Shortcut.F9;
            this.mnuEvents.Text = "Event Viewer";
            this.mnuEvents.Activate += new System.EventHandler(this.mnuEvents_Activate);
            // 
            // mnuGettingStarted
            // 
            this.mnuGettingStarted.BeginGroup = true;
            this.mnuGettingStarted.Text = "Getting Started";
            this.mnuGettingStarted.Activate += new System.EventHandler(this.mnuGettingStarted_Activate);
            // 
            // menuBarItem4
            // 
            this.menuBarItem4.Items.AddRange(new TD.SandBar.ToolbarItemBase[] {
            this.mnuCloseAll});
            this.menuBarItem4.MdiWindowList = true;
            this.menuBarItem4.Text = "&Window";
            // 
            // mnuCloseAll
            // 
            this.mnuCloseAll.Text = "Close All Documents";
            this.mnuCloseAll.Activate += new System.EventHandler(this.mnuCloseAll_Activate);
            // 
            // menuBarItem5
            // 
            this.menuBarItem5.Items.AddRange(new TD.SandBar.ToolbarItemBase[] {
            this.mnuAbout});
            this.menuBarItem5.Text = "&Help";
            // 
            // mnuAbout
            // 
            this.mnuAbout.Text = "About TACS.NET Manager";
            this.mnuAbout.Activate += new System.EventHandler(this.mnuAbout_Activate);
            // 
            // statusBar1
            // 
            this.statusBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusBar1.Guid = new System.Guid("4c110bda-e545-4fee-bfa2-f47ca2797c31");
            this.statusBar1.Items.AddRange(new TD.SandBar.ToolbarItemBase[] {
            this.statusBarItem1});
            this.statusBar1.Location = new System.Drawing.Point(0, 545);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.OwnerForm = this;
            this.statusBar1.Size = new System.Drawing.Size(784, 19);
            this.statusBar1.TabIndex = 4;
            this.statusBar1.Text = "statusBar1";
            // 
            // statusBarItem1
            // 
            this.statusBarItem1.Stretch = true;
            // 
            // sandDockManager1
            // 
            this.sandDockManager1.DockSystemContainer = this;
            this.sandDockManager1.OwnerForm = this;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "application_enterprise.png");
            this.imageList1.Images.SetKeyName(1, "application_server.png");
            this.imageList1.Images.SetKeyName(2, "businessman.png");
            this.imageList1.Images.SetKeyName(3, "data_connection.png");
            // 
            // dockContainer2
            // 
            this.dockContainer2.ContentSize = 200;
            this.dockContainer2.Controls.Add(this.dockProjects);
            this.dockContainer2.Controls.Add(this.dockUsers);
            this.dockContainer2.Dock = System.Windows.Forms.DockStyle.Right;
            this.dockContainer2.LayoutSystem = new TD.SandDock.SplitLayoutSystem(new System.Drawing.SizeF(250F, 400F), System.Windows.Forms.Orientation.Horizontal, new TD.SandDock.LayoutSystemBase[] {
            ((TD.SandDock.LayoutSystemBase)(new TD.SandDock.ControlLayoutSystem(new System.Drawing.SizeF(250F, 400F), new TD.SandDock.DockControl[] {
                        ((TD.SandDock.DockControl)(this.dockProjects))}, this.dockProjects))),
            ((TD.SandDock.LayoutSystemBase)(new TD.SandDock.ControlLayoutSystem(new System.Drawing.SizeF(250F, 400F), new TD.SandDock.DockControl[] {
                        ((TD.SandDock.DockControl)(this.dockUsers))}, this.dockUsers)))});
            this.dockContainer2.Location = new System.Drawing.Point(580, 23);
            this.dockContainer2.Manager = this.sandDockManager1;
            this.dockContainer2.Name = "dockContainer2";
            this.dockContainer2.Size = new System.Drawing.Size(204, 522);
            this.dockContainer2.TabIndex = 6;
            // 
            // dockProjects
            // 
            this.dockProjects.Controls.Add(this.treeProj);
            this.dockProjects.Controls.Add(this.toolProj);
            this.dockProjects.Guid = new System.Guid("8623f630-380f-45a6-9e26-e78a680a6a1b");
            this.dockProjects.Location = new System.Drawing.Point(4, 18);
            this.dockProjects.Name = "dockProjects";
            this.dockProjects.Size = new System.Drawing.Size(200, 217);
            this.dockProjects.TabImage = global::TACS.NET_Manager.Properties.Resources.data_find;
            this.dockProjects.TabIndex = 0;
            this.dockProjects.Text = "Projects";
            this.dockProjects.DockSituationChanged += new System.EventHandler(this.dockProjects_DockSituationChanged);
            // 
            // treeProj
            // 
            this.treeProj.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeProj.ImageIndex = 3;
            this.treeProj.ImageList = this.imageList1;
            this.treeProj.Location = new System.Drawing.Point(0, 24);
            this.treeProj.Name = "treeProj";
            this.treeProj.SelectedImageIndex = 3;
            this.treeProj.Size = new System.Drawing.Size(200, 193);
            this.treeProj.TabIndex = 1;
            this.treeProj.DoubleClick += new System.EventHandler(this.treeProj_DoubleClick);
            // 
            // toolProj
            // 
            this.toolProj.Guid = new System.Guid("d085119a-1961-4c3d-a361-a32122a146b8");
            this.toolProj.Items.AddRange(new TD.SandBar.ToolbarItemBase[] {
            this.btnRefreshProj,
            this.btnAddProj,
            this.btnDelProj});
            this.toolProj.Location = new System.Drawing.Point(0, 0);
            this.toolProj.Name = "toolProj";
            this.toolProj.Size = new System.Drawing.Size(200, 24);
            this.toolProj.TabIndex = 0;
            this.toolProj.Text = "";
            // 
            // btnRefreshProj
            // 
            this.btnRefreshProj.Image = global::TACS.NET_Manager.Properties.Resources.refresh;
            this.btnRefreshProj.ToolTipText = "Refresh project explorer";
            this.btnRefreshProj.Activate += new System.EventHandler(this.btnRefreshProj_Activate);
            // 
            // btnAddProj
            // 
            this.btnAddProj.BeginGroup = true;
            this.btnAddProj.Image = global::TACS.NET_Manager.Properties.Resources.data_add;
            this.btnAddProj.ToolTipText = "Add project";
            this.btnAddProj.Activate += new System.EventHandler(this.btnAddProj_Activate);
            // 
            // btnDelProj
            // 
            this.btnDelProj.Image = global::TACS.NET_Manager.Properties.Resources.data_delete;
            this.btnDelProj.ToolTipText = "Delete project";
            this.btnDelProj.Activate += new System.EventHandler(this.btnDelProj_Activate);
            // 
            // dockUsers
            // 
            this.dockUsers.Controls.Add(this.treeUser);
            this.dockUsers.Controls.Add(this.toolUser);
            this.dockUsers.Guid = new System.Guid("6970d646-8dd2-4e69-a2af-278865147a87");
            this.dockUsers.Location = new System.Drawing.Point(4, 281);
            this.dockUsers.Name = "dockUsers";
            this.dockUsers.Size = new System.Drawing.Size(200, 217);
            this.dockUsers.TabImage = global::TACS.NET_Manager.Properties.Resources.businessman_view;
            this.dockUsers.TabIndex = 1;
            this.dockUsers.Text = "Users";
            this.dockUsers.DockSituationChanged += new System.EventHandler(this.dockUsers_DockSituationChanged);
            // 
            // treeUser
            // 
            this.treeUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeUser.ImageIndex = 2;
            this.treeUser.ImageList = this.imageList1;
            this.treeUser.Location = new System.Drawing.Point(0, 24);
            this.treeUser.Name = "treeUser";
            this.treeUser.SelectedImageIndex = 2;
            this.treeUser.Size = new System.Drawing.Size(200, 193);
            this.treeUser.TabIndex = 1;
            this.treeUser.DoubleClick += new System.EventHandler(this.treeUser_DoubleClick);
            // 
            // toolUser
            // 
            this.toolUser.Guid = new System.Guid("2ead3d0b-0112-4775-8723-21ab96824ff8");
            this.toolUser.Items.AddRange(new TD.SandBar.ToolbarItemBase[] {
            this.btnRefreshUser,
            this.btnAddUser,
            this.btnDelUser});
            this.toolUser.Location = new System.Drawing.Point(0, 0);
            this.toolUser.Name = "toolUser";
            this.toolUser.Size = new System.Drawing.Size(200, 24);
            this.toolUser.TabIndex = 0;
            this.toolUser.Text = "";
            // 
            // btnRefreshUser
            // 
            this.btnRefreshUser.Image = global::TACS.NET_Manager.Properties.Resources.refresh;
            this.btnRefreshUser.ToolTipText = "Refresh user explorer";
            this.btnRefreshUser.Activate += new System.EventHandler(this.btnRefreshUser_Activate);
            // 
            // btnAddUser
            // 
            this.btnAddUser.BeginGroup = true;
            this.btnAddUser.Image = global::TACS.NET_Manager.Properties.Resources.businessman_add;
            this.btnAddUser.ToolTipText = "Add user";
            this.btnAddUser.Activate += new System.EventHandler(this.btnAddUser_Activate);
            // 
            // btnDelUser
            // 
            this.btnDelUser.Image = global::TACS.NET_Manager.Properties.Resources.businessman_delete;
            this.btnDelUser.ToolTipText = "Delete user";
            this.btnDelUser.Activate += new System.EventHandler(this.btnDelUser_Activate);
            // 
            // dockContainer1
            // 
            this.dockContainer1.ContentSize = 200;
            this.dockContainer1.Controls.Add(this.dockApplications);
            this.dockContainer1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dockContainer1.LayoutSystem = new TD.SandDock.SplitLayoutSystem(new System.Drawing.SizeF(250F, 400F), System.Windows.Forms.Orientation.Horizontal, new TD.SandDock.LayoutSystemBase[] {
            ((TD.SandDock.LayoutSystemBase)(new TD.SandDock.ControlLayoutSystem(new System.Drawing.SizeF(250F, 400F), new TD.SandDock.DockControl[] {
                        ((TD.SandDock.DockControl)(this.dockApplications))}, this.dockApplications)))});
            this.dockContainer1.Location = new System.Drawing.Point(0, 23);
            this.dockContainer1.Manager = this.sandDockManager1;
            this.dockContainer1.Name = "dockContainer1";
            this.dockContainer1.Size = new System.Drawing.Size(204, 522);
            this.dockContainer1.TabIndex = 5;
            // 
            // dockApplications
            // 
            this.dockApplications.Controls.Add(this.treeApps);
            this.dockApplications.Controls.Add(this.toolApps);
            this.dockApplications.Guid = new System.Guid("c2ec5911-2e61-43b8-a435-3a0124496969");
            this.dockApplications.Location = new System.Drawing.Point(0, 18);
            this.dockApplications.Name = "dockApplications";
            this.dockApplications.Size = new System.Drawing.Size(200, 480);
            this.dockApplications.TabImage = global::TACS.NET_Manager.Properties.Resources.application_enterprise_view;
            this.dockApplications.TabIndex = 0;
            this.dockApplications.Text = "Applications";
            this.dockApplications.DockSituationChanged += new System.EventHandler(this.dockApplications_DockSituationChanged);
            // 
            // treeApps
            // 
            this.treeApps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeApps.ImageIndex = 0;
            this.treeApps.ImageList = this.imageList1;
            this.treeApps.Location = new System.Drawing.Point(0, 24);
            this.treeApps.Name = "treeApps";
            this.treeApps.SelectedImageIndex = 0;
            this.treeApps.Size = new System.Drawing.Size(200, 456);
            this.treeApps.TabIndex = 1;
            this.treeApps.DoubleClick += new System.EventHandler(this.treeApps_DoubleClick);
            // 
            // toolApps
            // 
            this.toolApps.Guid = new System.Guid("b01a0b00-e08b-46b8-afca-0e2cc258d2e3");
            this.toolApps.Items.AddRange(new TD.SandBar.ToolbarItemBase[] {
            this.btnRefreshApp,
            this.btnAddApp,
            this.btnDelApp});
            this.toolApps.Location = new System.Drawing.Point(0, 0);
            this.toolApps.Name = "toolApps";
            this.toolApps.Renderer = new TD.SandBar.WhidbeyRenderer();
            this.toolApps.Size = new System.Drawing.Size(200, 24);
            this.toolApps.TabIndex = 0;
            this.toolApps.Text = "toolApps";
            // 
            // btnRefreshApp
            // 
            this.btnRefreshApp.Image = global::TACS.NET_Manager.Properties.Resources.refresh;
            this.btnRefreshApp.Activate += new System.EventHandler(this.btnRefreshApp_Activate);
            // 
            // btnAddApp
            // 
            this.btnAddApp.BeginGroup = true;
            this.btnAddApp.Image = global::TACS.NET_Manager.Properties.Resources.application_enterprise_add;
            this.btnAddApp.Activate += new System.EventHandler(this.btnAddApp_Activate);
            // 
            // btnDelApp
            // 
            this.btnDelApp.Image = global::TACS.NET_Manager.Properties.Resources.application_enterprise_delete;
            this.btnDelApp.Activate += new System.EventHandler(this.btnDelApp_Activate);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 564);
            this.Controls.Add(this.dockContainer2);
            this.Controls.Add(this.dockContainer1);
            this.Controls.Add(this.leftSandBarDock);
            this.Controls.Add(this.rightSandBarDock);
            this.Controls.Add(this.bottomSandBarDock);
            this.Controls.Add(this.topSandBarDock);
            this.Controls.Add(this.statusBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "TACS.NET Manager";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.topSandBarDock.ResumeLayout(false);
            this.dockContainer2.ResumeLayout(false);
            this.dockProjects.ResumeLayout(false);
            this.dockUsers.ResumeLayout(false);
            this.dockContainer1.ResumeLayout(false);
            this.dockApplications.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TD.SandBar.SandBarManager sandBarManager1;
        private TD.SandDock.DockableWindow dockApplications;
        private TD.SandDock.SandDockManager sandDockManager1;
        private TD.SandBar.ToolBarContainer leftSandBarDock;
        private TD.SandBar.ToolBarContainer rightSandBarDock;
        private TD.SandBar.ToolBarContainer bottomSandBarDock;
        private TD.SandBar.ToolBarContainer topSandBarDock;
        private TD.SandBar.MenuBar menuBar1;
        private TD.SandBar.MenuBarItem menuBarItem1;
        private TD.SandBar.MenuBarItem menuBarItem2;
        private TD.SandBar.MenuBarItem menuBarItem3;
        private TD.SandBar.MenuBarItem menuBarItem4;
        private TD.SandBar.MenuBarItem menuBarItem5;
        private TD.SandBar.StatusBar statusBar1;
        private TD.SandBar.StatusBarItem statusBarItem1;
        private TD.SandDock.DockContainer dockContainer1;
        private TD.SandBar.MenuButtonItem mnuNew;
        private TD.SandBar.MenuButtonItem mnuNewApp;
        private TD.SandBar.MenuButtonItem mnuNewAcct;
        private TD.SandBar.MenuButtonItem mnuOpen;
        private TD.SandBar.MenuButtonItem mnuOpenAcct;
        private TD.SandBar.MenuButtonItem mnuAdd;
        private TD.SandBar.MenuButtonItem mnuAddProject;
        private TD.SandBar.MenuButtonItem mnuAddUser;
        private TD.SandBar.MenuButtonItem mnuClose;
        private TD.SandBar.MenuButtonItem mnuCloseAcct;
        private TD.SandBar.MenuButtonItem mnuExit;
        private TD.SandDock.DockContainer dockContainer2;
        private TD.SandDock.DockableWindow dockProjects;
        private TD.SandDock.DockableWindow dockUsers;
        private TD.SandBar.MenuButtonItem mnuViewApps;
        private TD.SandBar.MenuButtonItem mnuViewProjects;
        private TD.SandBar.MenuButtonItem mnuViewUsers;
        private System.Windows.Forms.TreeView treeApps;
        private TD.SandBar.ToolBar toolApps;
        private System.Windows.Forms.ImageList imageList1;
        private TD.SandBar.MenuButtonItem mnuAbout;
        private TD.SandBar.ButtonItem btnRefreshApp;
        private TD.SandBar.ButtonItem btnAddApp;
        private TD.SandBar.ButtonItem btnDelApp;
        private System.Windows.Forms.TreeView treeProj;
        private TD.SandBar.ToolBar toolProj;
        private TD.SandBar.ButtonItem btnRefreshProj;
        private TD.SandBar.ButtonItem btnAddProj;
        private TD.SandBar.ButtonItem btnDelProj;
        private System.Windows.Forms.TreeView treeUser;
        private TD.SandBar.ToolBar toolUser;
        private TD.SandBar.ButtonItem btnRefreshUser;
        private TD.SandBar.ButtonItem btnAddUser;
        private TD.SandBar.ButtonItem btnDelUser;
        private TD.SandBar.MenuButtonItem mnuCloseAll;
        private TD.SandBar.MenuButtonItem mnuGettingStarted;
        private TD.SandBar.MenuButtonItem mnuEvents;
        private TD.SandBar.MenuButtonItem mnuAcctSettings;
        private TD.SandBar.MenuButtonItem mnuUndo;
        private TD.SandBar.MenuButtonItem mnuCut;
        private TD.SandBar.MenuButtonItem mnuCopy;
        private TD.SandBar.MenuButtonItem mnuPaste;
        private TD.SandBar.MenuButtonItem mnuDelete;
        private TD.SandBar.MenuButtonItem mnuDbSettings;
    }
}

