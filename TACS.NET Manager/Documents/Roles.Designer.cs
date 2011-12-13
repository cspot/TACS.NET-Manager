namespace TACS.NET_Manager.Documents
{
    partial class Roles
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
            this.rolesDs1 = new iCampaign.TACS.Data.RolesDs();
            this.listRoles = new System.Windows.Forms.ListView();
            this.colRole = new System.Windows.Forms.ColumnHeader();
            this.colAccessLevel = new System.Windows.Forms.ColumnHeader();
            ((System.ComponentModel.ISupportInitialize)(this.rolesDs1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolBar1
            // 
            this.toolBar1.Guid = new System.Guid("483ce0b1-5668-489b-8335-f6117db828cf");
            this.toolBar1.Items.AddRange(new TD.SandBar.ToolbarItemBase[] {
            this.btnSave});
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
            // rolesDs1
            // 
            this.rolesDs1.DataSetName = "RolesDs";
            this.rolesDs1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // listRoles
            // 
            this.listRoles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colRole,
            this.colAccessLevel});
            this.listRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listRoles.Location = new System.Drawing.Point(0, 24);
            this.listRoles.Name = "listRoles";
            this.listRoles.Size = new System.Drawing.Size(550, 376);
            this.listRoles.TabIndex = 1;
            this.listRoles.UseCompatibleStateImageBehavior = false;
            this.listRoles.View = System.Windows.Forms.View.Details;
            // 
            // colRole
            // 
            this.colRole.Text = "Project Role";
            this.colRole.Width = 373;
            // 
            // colAccessLevel
            // 
            this.colAccessLevel.Text = "Access Level";
            this.colAccessLevel.Width = 173;
            // 
            // Roles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listRoles);
            this.Controls.Add(this.toolBar1);
            this.Name = "Roles";
            this.Text = "Roles";
            this.Closing += new TD.SandDock.DockControlClosingEventHandler(this.Roles_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.rolesDs1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TD.SandBar.ToolBar toolBar1;
        private TD.SandBar.ButtonItem btnSave;
        private iCampaign.TACS.Data.RolesDs rolesDs1;
        private System.Windows.Forms.ListView listRoles;
        private System.Windows.Forms.ColumnHeader colRole;
        private System.Windows.Forms.ColumnHeader colAccessLevel;
    }
}