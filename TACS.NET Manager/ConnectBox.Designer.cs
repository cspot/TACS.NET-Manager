namespace TACS.NET_Manager
{
    partial class ConnectBox
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
            this.groupDatabase = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cbDatabase = new System.Windows.Forms.ComboBox();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.groupAccess = new System.Windows.Forms.GroupBox();
            this.tbPass = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.chkTrustedConn = new System.Windows.Forms.CheckBox();
            this.groupDbServer = new System.Windows.Forms.GroupBox();
            this.tbHost = new System.Windows.Forms.TextBox();
            this.lblHost = new System.Windows.Forms.Label();
            this.btnOkay = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupDatabase.SuspendLayout();
            this.groupAccess.SuspendLayout();
            this.groupDbServer.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupDatabase
            // 
            this.groupDatabase.Controls.Add(this.btnRefresh);
            this.groupDatabase.Controls.Add(this.cbDatabase);
            this.groupDatabase.Controls.Add(this.lblDatabase);
            this.groupDatabase.Location = new System.Drawing.Point(12, 165);
            this.groupDatabase.Name = "groupDatabase";
            this.groupDatabase.Size = new System.Drawing.Size(437, 60);
            this.groupDatabase.TabIndex = 10;
            this.groupDatabase.TabStop = false;
            this.groupDatabase.Text = "TACS.NET Database";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(356, 18);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cbDatabase
            // 
            this.cbDatabase.FormattingEnabled = true;
            this.cbDatabase.Location = new System.Drawing.Point(72, 20);
            this.cbDatabase.Name = "cbDatabase";
            this.cbDatabase.Size = new System.Drawing.Size(278, 21);
            this.cbDatabase.TabIndex = 1;
            this.cbDatabase.SelectedIndexChanged += new System.EventHandler(this.cbDatabase_SelectedIndexChanged);
            // 
            // lblDatabase
            // 
            this.lblDatabase.AutoSize = true;
            this.lblDatabase.Location = new System.Drawing.Point(9, 23);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(56, 13);
            this.lblDatabase.TabIndex = 0;
            this.lblDatabase.Text = "Database:";
            // 
            // groupAccess
            // 
            this.groupAccess.Controls.Add(this.tbPass);
            this.groupAccess.Controls.Add(this.lblPass);
            this.groupAccess.Controls.Add(this.tbUser);
            this.groupAccess.Controls.Add(this.lblUser);
            this.groupAccess.Controls.Add(this.chkTrustedConn);
            this.groupAccess.Location = new System.Drawing.Point(12, 85);
            this.groupAccess.Name = "groupAccess";
            this.groupAccess.Size = new System.Drawing.Size(437, 74);
            this.groupAccess.TabIndex = 9;
            this.groupAccess.TabStop = false;
            this.groupAccess.Text = "Server Credentials";
            // 
            // tbPass
            // 
            this.tbPass.Location = new System.Drawing.Point(281, 43);
            this.tbPass.Name = "tbPass";
            this.tbPass.PasswordChar = '*';
            this.tbPass.Size = new System.Drawing.Size(150, 20);
            this.tbPass.TabIndex = 4;
            this.tbPass.TextChanged += new System.EventHandler(this.tbPass_TextChanged);
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(219, 46);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(56, 13);
            this.lblPass.TabIndex = 3;
            this.lblPass.Text = "Password:";
            // 
            // tbUser
            // 
            this.tbUser.Location = new System.Drawing.Point(71, 43);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(142, 20);
            this.tbUser.TabIndex = 2;
            this.tbUser.TextChanged += new System.EventHandler(this.tbUser_TextChanged);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(9, 46);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(56, 13);
            this.lblUser.TabIndex = 1;
            this.lblUser.Text = "SQL User:";
            // 
            // chkTrustedConn
            // 
            this.chkTrustedConn.AutoSize = true;
            this.chkTrustedConn.Location = new System.Drawing.Point(12, 20);
            this.chkTrustedConn.Name = "chkTrustedConn";
            this.chkTrustedConn.Size = new System.Drawing.Size(136, 17);
            this.chkTrustedConn.TabIndex = 0;
            this.chkTrustedConn.Text = "Use trusted connection";
            this.chkTrustedConn.UseVisualStyleBackColor = true;
            this.chkTrustedConn.CheckedChanged += new System.EventHandler(this.chkTrustedConn_CheckedChanged);
            // 
            // groupDbServer
            // 
            this.groupDbServer.Controls.Add(this.tbHost);
            this.groupDbServer.Controls.Add(this.lblHost);
            this.groupDbServer.Location = new System.Drawing.Point(12, 12);
            this.groupDbServer.Name = "groupDbServer";
            this.groupDbServer.Size = new System.Drawing.Size(437, 67);
            this.groupDbServer.TabIndex = 8;
            this.groupDbServer.TabStop = false;
            this.groupDbServer.Text = "Database Server";
            // 
            // tbHost
            // 
            this.tbHost.Location = new System.Drawing.Point(9, 32);
            this.tbHost.Name = "tbHost";
            this.tbHost.Size = new System.Drawing.Size(422, 20);
            this.tbHost.TabIndex = 1;
            this.tbHost.TextChanged += new System.EventHandler(this.tbHost_TextChanged);
            // 
            // lblHost
            // 
            this.lblHost.AutoSize = true;
            this.lblHost.Location = new System.Drawing.Point(6, 16);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(157, 13);
            this.lblHost.TabIndex = 0;
            this.lblHost.Text = "Enter host name of SQL Server:";
            // 
            // btnOkay
            // 
            this.btnOkay.Location = new System.Drawing.Point(293, 231);
            this.btnOkay.Name = "btnOkay";
            this.btnOkay.Size = new System.Drawing.Size(75, 23);
            this.btnOkay.TabIndex = 11;
            this.btnOkay.Text = "OK";
            this.btnOkay.UseVisualStyleBackColor = true;
            this.btnOkay.Click += new System.EventHandler(this.btnOkay_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(374, 231);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ConnectBox
            // 
            this.AcceptButton = this.btnOkay;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(461, 262);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOkay);
            this.Controls.Add(this.groupDatabase);
            this.Controls.Add(this.groupAccess);
            this.Controls.Add(this.groupDbServer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnectBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Database Connection";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ConnectBox_Load);
            this.groupDatabase.ResumeLayout(false);
            this.groupDatabase.PerformLayout();
            this.groupAccess.ResumeLayout(false);
            this.groupAccess.PerformLayout();
            this.groupDbServer.ResumeLayout(false);
            this.groupDbServer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupDatabase;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox cbDatabase;
        private System.Windows.Forms.Label lblDatabase;
        private System.Windows.Forms.GroupBox groupAccess;
        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.CheckBox chkTrustedConn;
        private System.Windows.Forms.GroupBox groupDbServer;
        private System.Windows.Forms.TextBox tbHost;
        private System.Windows.Forms.Label lblHost;
        private System.Windows.Forms.Button btnOkay;
        private System.Windows.Forms.Button btnCancel;
    }
}