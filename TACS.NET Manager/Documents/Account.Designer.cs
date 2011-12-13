namespace TACS.NET_Manager.Documents
{
    partial class Account
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbPhone = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbZip = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbState = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbCity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbAddress2 = new System.Windows.Forms.TextBox();
            this.tbAddress1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbContact = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbAccount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolBar1
            // 
            this.toolBar1.Guid = new System.Guid("e77aaf9a-cade-40bd-8820-862268759e79");
            this.toolBar1.Items.AddRange(new TD.SandBar.ToolbarItemBase[] {
            this.btnSave});
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.Size = new System.Drawing.Size(550, 24);
            this.toolBar1.TabIndex = 1;
            this.toolBar1.Text = "toolBar1";
            // 
            // btnSave
            // 
            this.btnSave.Image = global::TACS.NET_Manager.Properties.Resources.disk_blue;
            this.btnSave.ToolTipText = "Save application";
            this.btnSave.Activate += new System.EventHandler(this.btnSave_Activate);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbPhone);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tbEmail);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tbZip);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbState);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbCity);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbAddress2);
            this.groupBox1.Controls.Add(this.tbAddress1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbContact);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbAccount);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(544, 208);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Account Information";
            // 
            // tbPhone
            // 
            this.tbPhone.Location = new System.Drawing.Point(113, 175);
            this.tbPhone.Name = "tbPhone";
            this.tbPhone.Size = new System.Drawing.Size(175, 20);
            this.tbPhone.TabIndex = 17;
            this.tbPhone.TextChanged += new System.EventHandler(this.tbPhone_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(57, 178);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Phone:";
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(113, 149);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(425, 20);
            this.tbEmail.TabIndex = 15;
            this.tbEmail.TextChanged += new System.EventHandler(this.tbEmail_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(69, 152);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "E-mail:";
            // 
            // tbZip
            // 
            this.tbZip.Location = new System.Drawing.Point(411, 123);
            this.tbZip.Name = "tbZip";
            this.tbZip.Size = new System.Drawing.Size(127, 20);
            this.tbZip.TabIndex = 13;
            this.tbZip.TextChanged += new System.EventHandler(this.tbZip_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(352, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Zip Code:";
            // 
            // tbState
            // 
            this.tbState.Location = new System.Drawing.Point(294, 123);
            this.tbState.Name = "tbState";
            this.tbState.Size = new System.Drawing.Size(52, 20);
            this.tbState.TabIndex = 11;
            this.tbState.TextChanged += new System.EventHandler(this.tbState_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(253, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "State:";
            // 
            // tbCity
            // 
            this.tbCity.Location = new System.Drawing.Point(113, 123);
            this.tbCity.Name = "tbCity";
            this.tbCity.Size = new System.Drawing.Size(134, 20);
            this.tbCity.TabIndex = 9;
            this.tbCity.TextChanged += new System.EventHandler(this.tbCity_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(80, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "City:";
            // 
            // tbAddress2
            // 
            this.tbAddress2.Location = new System.Drawing.Point(113, 97);
            this.tbAddress2.Name = "tbAddress2";
            this.tbAddress2.Size = new System.Drawing.Size(425, 20);
            this.tbAddress2.TabIndex = 7;
            this.tbAddress2.TextChanged += new System.EventHandler(this.tbAddress2_TextChanged);
            // 
            // tbAddress1
            // 
            this.tbAddress1.Location = new System.Drawing.Point(113, 71);
            this.tbAddress1.Name = "tbAddress1";
            this.tbAddress1.Size = new System.Drawing.Size(425, 20);
            this.tbAddress1.TabIndex = 5;
            this.tbAddress1.TextChanged += new System.EventHandler(this.tbAddress1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mailing address:";
            // 
            // tbContact
            // 
            this.tbContact.Location = new System.Drawing.Point(113, 45);
            this.tbContact.Name = "tbContact";
            this.tbContact.Size = new System.Drawing.Size(425, 20);
            this.tbContact.TabIndex = 3;
            this.tbContact.TextChanged += new System.EventHandler(this.tbContact_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Contact name:";
            // 
            // tbAccount
            // 
            this.tbAccount.Location = new System.Drawing.Point(113, 19);
            this.tbAccount.Name = "tbAccount";
            this.tbAccount.Size = new System.Drawing.Size(425, 20);
            this.tbAccount.TabIndex = 1;
            this.tbAccount.TextChanged += new System.EventHandler(this.tbAccount_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(57, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Account:";
            // 
            // Account
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolBar1);
            this.Name = "Account";
            this.Text = "Account";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TD.SandBar.ToolBar toolBar1;
        private TD.SandBar.ButtonItem btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbAccount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbAddress2;
        private System.Windows.Forms.TextBox tbAddress1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbContact;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPhone;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbZip;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbState;
        private System.Windows.Forms.Label label5;
    }
}