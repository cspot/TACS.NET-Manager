using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using iCampaign.TACS.Data;

namespace TACS.NET_Manager
{
    public partial class ProjectsBox : Form
    {
        private long acctId;
        private iCampaign.TACS.Data.ProjectsDs.ProjectsDataTable dataTable;
        private iCampaign.TACS.Data.ProjectsDsTableAdapters.ProjectsTableAdapter tableAdapter;

        /// <summary>
        /// Initialize instance of open project dialog box.
        /// </summary>
        public ProjectsBox(long aid)
        {
            acctId = aid;
            InitializeComponent();
            dataTable = new ProjectsDs.ProjectsDataTable();
            tableAdapter = new iCampaign.TACS.Data.ProjectsDsTableAdapters.ProjectsTableAdapter();
            btnCancel.Enabled = true;
            btnOkay.Enabled = false;
            GetProjects();
        }

        /// <summary>
        /// Gets the selected project name.
        /// </summary>
        public string SelectedProject
        {
            get { return listProj.SelectedItems[0].Name.ToString(); }
        }

        /// <summary>
        /// Get the projects for the specified account and display.
        /// </summary>
        private void GetProjects()
        {
            tableAdapter.Connection = new System.Data.SqlClient.SqlConnection(TacsSession.ConnectionString);
            try
            {
                tableAdapter.Connection.Open();
                tableAdapter.FillByAcct(dataTable, acctId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error getting projects",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
            }
            finally
            {
                tableAdapter.Connection.Close();
            }

            //  Populate the list control
            foreach (iCampaign.TACS.Data.ProjectsDs.ProjectsRow row in dataTable)
            {
                ListViewItem item = new ListViewItem();
                item.Name = row.Project;
                item.Text = row.Project;
                listProj.Items.Add(item);
            }
        }

        /// <summary>
        /// Project list control event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listProj_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnOkay.Enabled = true;
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
        /// Cancel button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// List control double click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listProj_DoubleClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
