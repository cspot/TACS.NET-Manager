namespace TACS.NET_Manager.Documents
{
    partial class UserProfile
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
            this.btnClearSession = new TD.SandBar.ButtonItem();
            this.btnAddProject = new TD.SandBar.ButtonItem();
            this.btnDeleteProject = new TD.SandBar.ButtonItem();
            this.tabControl1 = new TD.SandDock.TabControl();
            this.tabPage1 = new TD.SandDock.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkExpire = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.chkSuper = new System.Windows.Forms.CheckBox();
            this.chkOwner = new System.Windows.Forms.CheckBox();
            this.chkDisable = new System.Windows.Forms.CheckBox();
            this.dateExpire = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPass2 = new System.Windows.Forms.TextBox();
            this.tbPass1 = new System.Windows.Forms.TextBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.tbFullName = new System.Windows.Forms.TextBox();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.tabPage2 = new TD.SandDock.TabPage();
            this.projectView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolBar1
            // 
            this.toolBar1.Guid = new System.Guid("36898205-2d42-4d55-8e59-25a0254204e3");
            this.toolBar1.Items.AddRange(new TD.SandBar.ToolbarItemBase[] {
            this.btnSave,
            this.btnDelete,
            this.btnClearSession,
            this.btnAddProject,
            this.btnDeleteProject});
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.Size = new System.Drawing.Size(550, 24);
            this.toolBar1.TabIndex = 0;
            this.toolBar1.Text = "toolBar1";
            // 
            // btnSave
            // 
            this.btnSave.Image = global::TACS.NET_Manager.Properties.Resources.disk_blue;
            this.btnSave.Activate += new System.EventHandler(this.btnSave_Activate);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::TACS.NET_Manager.Properties.Resources.delete2;
            this.btnDelete.Activate += new System.EventHandler(this.btnDelete_Activate);
            // 
            // btnClearSession
            // 
            this.btnClearSession.Image = global::TACS.NET_Manager.Properties.Resources.clock_reset;
            this.btnClearSession.ToolTipText = "Clear session token";
            this.btnClearSession.Activate += new System.EventHandler(this.btnClearSession_Activate);
            // 
            // btnAddProject
            // 
            this.btnAddProject.BeginGroup = true;
            this.btnAddProject.Enabled = false;
            this.btnAddProject.Image = global::TACS.NET_Manager.Properties.Resources.element_add;
            this.btnAddProject.ToolTipText = "Add a project role to user";
            this.btnAddProject.Activate += new System.EventHandler(this.btnAddProject_Activate);
            // 
            // btnDeleteProject
            // 
            this.btnDeleteProject.Enabled = false;
            this.btnDeleteProject.Image = global::TACS.NET_Manager.Properties.Resources.element_delete;
            this.btnDeleteProject.ToolTipText = "Delete selected project role";
            this.btnDeleteProject.Activate += new System.EventHandler(this.btnDeleteProject_Activate);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Renderer = new TD.SandDock.Rendering.WhidbeyRenderer();
            this.tabControl1.Size = new System.Drawing.Size(550, 376);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(542, 347);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "User Profile";
            this.tabPage1.Enter += new System.EventHandler(this.tabPage1_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkExpire);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.chkSuper);
            this.groupBox2.Controls.Add(this.chkOwner);
            this.groupBox2.Controls.Add(this.chkDisable);
            this.groupBox2.Controls.Add(this.dateExpire);
            this.groupBox2.Location = new System.Drawing.Point(3, 166);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(536, 76);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Attributes";
            // 
            // chkExpire
            // 
            this.chkExpire.AutoSize = true;
            this.chkExpire.Location = new System.Drawing.Point(108, 21);
            this.chkExpire.Name = "chkExpire";
            this.chkExpire.Size = new System.Drawing.Size(112, 17);
            this.chkExpire.TabIndex = 11;
            this.chkExpire.Text = "Expire account on";
            this.chkExpire.UseVisualStyleBackColor = true;
            this.chkExpire.CheckedChanged += new System.EventHandler(this.chkExpire_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(54, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Security:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Account Expiration:";
            // 
            // chkSuper
            // 
            this.chkSuper.AutoSize = true;
            this.chkSuper.Location = new System.Drawing.Point(312, 47);
            this.chkSuper.Name = "chkSuper";
            this.chkSuper.Size = new System.Drawing.Size(117, 17);
            this.chkSuper.TabIndex = 3;
            this.chkSuper.Text = "Super Administrator";
            this.chkSuper.UseVisualStyleBackColor = true;
            this.chkSuper.CheckedChanged += new System.EventHandler(this.chkSuper_CheckedChanged);
            // 
            // chkOwner
            // 
            this.chkOwner.AutoSize = true;
            this.chkOwner.Location = new System.Drawing.Point(206, 47);
            this.chkOwner.Name = "chkOwner";
            this.chkOwner.Size = new System.Drawing.Size(100, 17);
            this.chkOwner.TabIndex = 2;
            this.chkOwner.Text = "Account Owner";
            this.chkOwner.UseVisualStyleBackColor = true;
            this.chkOwner.CheckedChanged += new System.EventHandler(this.chkOwner_CheckedChanged);
            // 
            // chkDisable
            // 
            this.chkDisable.AutoSize = true;
            this.chkDisable.Location = new System.Drawing.Point(108, 47);
            this.chkDisable.Name = "chkDisable";
            this.chkDisable.Size = new System.Drawing.Size(92, 17);
            this.chkDisable.TabIndex = 1;
            this.chkDisable.Text = "User Disabled";
            this.chkDisable.UseVisualStyleBackColor = true;
            this.chkDisable.CheckedChanged += new System.EventHandler(this.chkDisable_CheckedChanged);
            // 
            // dateExpire
            // 
            this.dateExpire.Location = new System.Drawing.Point(229, 20);
            this.dateExpire.Name = "dateExpire";
            this.dateExpire.Size = new System.Drawing.Size(200, 20);
            this.dateExpire.TabIndex = 0;
            this.dateExpire.ValueChanged += new System.EventHandler(this.dateExpire_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbPass2);
            this.groupBox1.Controls.Add(this.tbPass1);
            this.groupBox1.Controls.Add(this.tbEmail);
            this.groupBox1.Controls.Add(this.tbFullName);
            this.groupBox1.Controls.Add(this.tbUsername);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(536, 157);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User Information";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "E-mail Address:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Password Again:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Full name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(44, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Username:";
            // 
            // tbPass2
            // 
            this.tbPass2.Location = new System.Drawing.Point(108, 123);
            this.tbPass2.Name = "tbPass2";
            this.tbPass2.PasswordChar = '*';
            this.tbPass2.Size = new System.Drawing.Size(422, 20);
            this.tbPass2.TabIndex = 7;
            this.tbPass2.TextChanged += new System.EventHandler(this.tbPass2_TextChanged);
            // 
            // tbPass1
            // 
            this.tbPass1.Location = new System.Drawing.Point(108, 97);
            this.tbPass1.Name = "tbPass1";
            this.tbPass1.PasswordChar = '*';
            this.tbPass1.Size = new System.Drawing.Size(422, 20);
            this.tbPass1.TabIndex = 6;
            this.tbPass1.TextChanged += new System.EventHandler(this.tbPass1_TextChanged);
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(108, 71);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(422, 20);
            this.tbEmail.TabIndex = 5;
            this.tbEmail.TextChanged += new System.EventHandler(this.tbEmail_TextChanged);
            // 
            // tbFullName
            // 
            this.tbFullName.Location = new System.Drawing.Point(108, 45);
            this.tbFullName.Name = "tbFullName";
            this.tbFullName.Size = new System.Drawing.Size(422, 20);
            this.tbFullName.TabIndex = 4;
            this.tbFullName.TextChanged += new System.EventHandler(this.tbFullName_TextChanged);
            // 
            // tbUsername
            // 
            this.tbUsername.Location = new System.Drawing.Point(108, 19);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(422, 20);
            this.tbUsername.TabIndex = 3;
            this.tbUsername.TextChanged += new System.EventHandler(this.tbUsername_TextChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.projectView);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(542, 347);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Projects";
            this.tabPage2.Enter += new System.EventHandler(this.tabPage2_Enter);
            // 
            // projectView
            // 
            this.projectView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.projectView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.projectView.GridLines = true;
            this.projectView.Location = new System.Drawing.Point(0, 0);
            this.projectView.MultiSelect = false;
            this.projectView.Name = "projectView";
            this.projectView.Size = new System.Drawing.Size(542, 347);
            this.projectView.TabIndex = 0;
            this.projectView.UseCompatibleStateImageBehavior = false;
            this.projectView.View = System.Windows.Forms.View.Details;
            this.projectView.SelectedIndexChanged += new System.EventHandler(this.projectView_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Project";
            this.columnHeader1.Width = 209;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Project Role";
            this.columnHeader2.Width = 194;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Access Level";
            this.columnHeader3.Width = 134;
            // 
            // UserProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolBar1);
            this.Name = "UserProfile";
            this.TabImage = global::TACS.NET_Manager.Properties.Resources.businessman;
            this.Text = "UserProfile";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TD.SandBar.ToolBar toolBar1;
        private TD.SandBar.ButtonItem btnSave;
        private TD.SandBar.ButtonItem btnDelete;
        private TD.SandDock.TabControl tabControl1;
        private TD.SandDock.TabPage tabPage1;
        private TD.SandDock.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private TD.SandBar.ButtonItem btnClearSession;
        private System.Windows.Forms.TextBox tbPass2;
        private System.Windows.Forms.TextBox tbPass1;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.TextBox tbFullName;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.DateTimePicker dateExpire;
        private System.Windows.Forms.CheckBox chkSuper;
        private System.Windows.Forms.CheckBox chkOwner;
        private System.Windows.Forms.CheckBox chkDisable;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkExpire;
        private TD.SandBar.ButtonItem btnAddProject;
        private TD.SandBar.ButtonItem btnDeleteProject;
        private System.Windows.Forms.ListView projectView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}