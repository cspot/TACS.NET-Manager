namespace TACS.NET_Manager.Documents
{
    partial class Project
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
            this.toolBar1 = new TD.SandBar.ToolBar();
            this.btnSave = new TD.SandBar.ButtonItem();
            this.btnDelete = new TD.SandBar.ButtonItem();
            this.btnAddRole = new TD.SandBar.ButtonItem();
            this.btnEditRole = new TD.SandBar.ButtonItem();
            this.btnDeleteRole = new TD.SandBar.ButtonItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbProject = new System.Windows.Forms.TextBox();
            this.cbApp = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPass = new System.Windows.Forms.TextBox();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.tbDatabase = new System.Windows.Forms.TextBox();
            this.tbDataSource = new System.Windows.Forms.TextBox();
            this.cbConnector = new System.Windows.Forms.ComboBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.tabControl1 = new TD.SandDock.TabControl();
            this.tabPage1 = new TD.SandDock.TabPage();
            this.tabPage2 = new TD.SandDock.TabPage();
            this.roleView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolBar1
            // 
            this.toolBar1.Guid = new System.Guid("98889ed0-b198-439a-aa0e-8344282f07f7");
            this.toolBar1.Items.AddRange(new TD.SandBar.ToolbarItemBase[] {
            this.btnSave,
            this.btnDelete,
            this.btnAddRole,
            this.btnEditRole,
            this.btnDeleteRole});
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.Size = new System.Drawing.Size(563, 24);
            this.toolBar1.TabIndex = 0;
            this.toolBar1.Text = "toolBar1";
            // 
            // btnSave
            // 
            this.btnSave.Image = global::TACS.NET_Manager.Properties.Resources.disk_blue;
            this.btnSave.ToolTipText = "Save project";
            this.btnSave.Activate += new System.EventHandler(this.btnSave_Activate);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::TACS.NET_Manager.Properties.Resources.delete2;
            this.btnDelete.ToolTipText = "Delete project";
            this.btnDelete.Activate += new System.EventHandler(this.btnDelete_Activate);
            // 
            // btnAddRole
            // 
            this.btnAddRole.BeginGroup = true;
            this.btnAddRole.Enabled = false;
            this.btnAddRole.Image = global::TACS.NET_Manager.Properties.Resources.element_add;
            this.btnAddRole.ToolTipText = "Add new role";
            this.btnAddRole.Activate += new System.EventHandler(this.btnAddRole_Activate);
            // 
            // btnEditRole
            // 
            this.btnEditRole.Enabled = false;
            this.btnEditRole.Image = global::TACS.NET_Manager.Properties.Resources.element_view;
            this.btnEditRole.ToolTipText = "Edit selected role";
            this.btnEditRole.Activate += new System.EventHandler(this.btnEditRole_Activate);
            // 
            // btnDeleteRole
            // 
            this.btnDeleteRole.Enabled = false;
            this.btnDeleteRole.Image = global::TACS.NET_Manager.Properties.Resources.element_delete;
            this.btnDeleteRole.ToolTipText = "Delete selected role";
            this.btnDeleteRole.Activate += new System.EventHandler(this.btnDeleteRole_Activate);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbProject);
            this.groupBox1.Controls.Add(this.cbApp);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(544, 76);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Project";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(36, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Project Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(48, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Application:";
            // 
            // tbProject
            // 
            this.tbProject.Location = new System.Drawing.Point(116, 46);
            this.tbProject.Name = "tbProject";
            this.tbProject.Size = new System.Drawing.Size(422, 20);
            this.tbProject.TabIndex = 3;
            this.tbProject.TextChanged += new System.EventHandler(this.tbProject_TextChanged);
            // 
            // cbApp
            // 
            this.cbApp.FormattingEnabled = true;
            this.cbApp.Location = new System.Drawing.Point(116, 19);
            this.cbApp.Name = "cbApp";
            this.cbApp.Size = new System.Drawing.Size(422, 21);
            this.cbApp.TabIndex = 0;
            this.cbApp.SelectedIndexChanged += new System.EventHandler(this.cbApp_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.tbPass);
            this.groupBox2.Controls.Add(this.tbUser);
            this.groupBox2.Controls.Add(this.tbDatabase);
            this.groupBox2.Controls.Add(this.tbDataSource);
            this.groupBox2.Controls.Add(this.cbConnector);
            this.groupBox2.Location = new System.Drawing.Point(3, 85);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(544, 157);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Database Settings";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Database Password:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Database User:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(54, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Database:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Server Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Connector Type:";
            // 
            // tbPass
            // 
            this.tbPass.Location = new System.Drawing.Point(116, 124);
            this.tbPass.Name = "tbPass";
            this.tbPass.Size = new System.Drawing.Size(422, 20);
            this.tbPass.TabIndex = 7;
            this.tbPass.TextChanged += new System.EventHandler(this.tbPass_TextChanged);
            // 
            // tbUser
            // 
            this.tbUser.Location = new System.Drawing.Point(116, 98);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(422, 20);
            this.tbUser.TabIndex = 6;
            this.tbUser.TextChanged += new System.EventHandler(this.tbUser_TextChanged);
            // 
            // tbDatabase
            // 
            this.tbDatabase.Location = new System.Drawing.Point(116, 72);
            this.tbDatabase.Name = "tbDatabase";
            this.tbDatabase.Size = new System.Drawing.Size(422, 20);
            this.tbDatabase.TabIndex = 5;
            this.tbDatabase.TextChanged += new System.EventHandler(this.tbDatabase_TextChanged);
            // 
            // tbDataSource
            // 
            this.tbDataSource.Location = new System.Drawing.Point(116, 46);
            this.tbDataSource.Name = "tbDataSource";
            this.tbDataSource.Size = new System.Drawing.Size(422, 20);
            this.tbDataSource.TabIndex = 4;
            this.tbDataSource.TextChanged += new System.EventHandler(this.tbDataSource_TextChanged);
            // 
            // cbConnector
            // 
            this.cbConnector.FormattingEnabled = true;
            this.cbConnector.Items.AddRange(new object[] {
            "MySQL Server",
            "Microsoft SQL Server"});
            this.cbConnector.Location = new System.Drawing.Point(116, 19);
            this.cbConnector.Name = "cbConnector";
            this.cbConnector.Size = new System.Drawing.Size(202, 21);
            this.cbConnector.TabIndex = 1;
            this.cbConnector.SelectedIndexChanged += new System.EventHandler(this.cbConnector_SelectedIndexChanged);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(401, 248);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(146, 23);
            this.btnTest.TabIndex = 3;
            this.btnTest.Text = "Test Connection";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(241, 248);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(154, 23);
            this.btnShow.TabIndex = 4;
            this.btnShow.Text = "Show Connection String";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Renderer = new TD.SandDock.Rendering.WhidbeyRenderer();
            this.tabControl1.Size = new System.Drawing.Size(563, 399);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.btnShow);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.btnTest);
            this.tabPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(555, 370);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Project";
            this.tabPage1.Enter += new System.EventHandler(this.tabPage1_Enter);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.roleView);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(555, 370);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Roles";
            this.tabPage2.Enter += new System.EventHandler(this.tabPage2_Enter);
            // 
            // roleView
            // 
            this.roleView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.roleView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.roleView.GridLines = true;
            this.roleView.Location = new System.Drawing.Point(0, 0);
            this.roleView.MultiSelect = false;
            this.roleView.Name = "roleView";
            this.roleView.Size = new System.Drawing.Size(555, 370);
            this.roleView.TabIndex = 0;
            this.roleView.UseCompatibleStateImageBehavior = false;
            this.roleView.View = System.Windows.Forms.View.Details;
            this.roleView.SelectedIndexChanged += new System.EventHandler(this.roleView_SelectedIndexChanged);
            this.roleView.DoubleClick += new System.EventHandler(this.roleView_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Project Role";
            this.columnHeader1.Width = 300;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Access Level";
            this.columnHeader2.Width = 250;
            // 
            // Project
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolBar1);
            this.Name = "Project";
            this.Size = new System.Drawing.Size(563, 423);
            this.TabImage = global::TACS.NET_Manager.Properties.Resources.data;
            this.Text = "Project";
            this.Closing += new TD.SandDock.DockControlClosingEventHandler(this.Project_Closing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TD.SandBar.ToolBar toolBar1;
        private TD.SandBar.ButtonItem btnSave;
        private TD.SandBar.ButtonItem btnDelete;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbProject;
        private System.Windows.Forms.ComboBox cbApp;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.TextBox tbDatabase;
        private System.Windows.Forms.TextBox tbDataSource;
        private System.Windows.Forms.ComboBox cbConnector;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnShow;
        private TD.SandDock.TabControl tabControl1;
        private TD.SandDock.TabPage tabPage1;
        private TD.SandDock.TabPage tabPage2;
        private System.Windows.Forms.ListView roleView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private TD.SandBar.ButtonItem btnAddRole;
        private TD.SandBar.ButtonItem btnEditRole;
        private TD.SandBar.ButtonItem btnDeleteRole;
    }
}