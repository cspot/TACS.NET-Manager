namespace TACS.NET_Manager
{
    partial class AccountsBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountsBox));
            this.btnOkay = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.listAcct = new System.Windows.Forms.ListView();
            this.colAccount = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // btnOkay
            // 
            this.btnOkay.Location = new System.Drawing.Point(216, 229);
            this.btnOkay.Name = "btnOkay";
            this.btnOkay.Size = new System.Drawing.Size(75, 23);
            this.btnOkay.TabIndex = 1;
            this.btnOkay.Text = "OK";
            this.btnOkay.UseVisualStyleBackColor = true;
            this.btnOkay.Click += new System.EventHandler(this.btnOkay_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(297, 229);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // listAcct
            // 
            this.listAcct.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colAccount});
            this.listAcct.Location = new System.Drawing.Point(12, 12);
            this.listAcct.MultiSelect = false;
            this.listAcct.Name = "listAcct";
            this.listAcct.Size = new System.Drawing.Size(360, 211);
            this.listAcct.TabIndex = 3;
            this.listAcct.UseCompatibleStateImageBehavior = false;
            this.listAcct.View = System.Windows.Forms.View.Details;
            this.listAcct.SelectedIndexChanged += new System.EventHandler(this.listAcct_SelectedIndexChanged);
            this.listAcct.DoubleClick += new System.EventHandler(this.listAcct_DoubleClick);
            // 
            // colAccount
            // 
            this.colAccount.Text = "Account Name";
            this.colAccount.Width = 356;
            // 
            // AccountsBox
            // 
            this.AcceptButton = this.btnOkay;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(384, 264);
            this.Controls.Add(this.listAcct);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOkay);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AccountsBox";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Open Account";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.AccountsBox_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOkay;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListView listAcct;
        private System.Windows.Forms.ColumnHeader colAccount;
    }
}