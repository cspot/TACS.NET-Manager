using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using iCampaign.TACS;

namespace TACS.NET_Manager
{
    public partial class AccountsBox : Form
    {
        /// <summary>
        /// Data table for accounts.
        /// </summary>
        private iCampaign.TACS.Data.AccountsDs.AccountsDataTable accountsTable;

        /// <summary>
        /// Initialize instance of accounts dialog box.
        /// </summary>
        /// <param name="dataTable">iCampaign.TACS.Data.AccountsDs.AccountsDataTable</param>
        public AccountsBox(iCampaign.TACS.Data.AccountsDs.AccountsDataTable dataTable)
        {
            //  Initialize the form controls
            InitializeComponent();
            accountsTable = dataTable;
        }

        /// <summary>
        /// Gets the selected account id.
        /// </summary>
        public long SelectedAccountId
        {
            get { return Convert.ToInt64(listAcct.SelectedItems[0].Name); }
        }

        /// <summary>
        /// Gets the selected account name.
        /// </summary>
        public string SelectedAccount
        {
            get { return listAcct.SelectedItems[0].Text.ToString(); }
        }

        /// <summary>
        /// Display the contents of the data table.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AccountsBox_Load(object sender, EventArgs e)
        {
            foreach (iCampaign.TACS.Data.AccountsDs.AccountsRow row in accountsTable)
            {
                ListViewItem item = new ListViewItem();
                item.Name = row.AcctId.ToString();
                item.Text = row.AcctName;
                listAcct.Items.Add(item);
            }

            btnOkay.Enabled = false;
            btnCancel.Enabled = true;
        }

        /// <summary>
        /// List view selected index event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listAcct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!btnOkay.Enabled)
                btnOkay.Enabled = true;
        }

        /// <summary>
        /// Cancel button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// OK button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOkay_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// List double click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listAcct_DoubleClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
