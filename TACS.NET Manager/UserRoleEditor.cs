using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TACS.NET_Manager
{
    public partial class UserRoleEditor : Form
    {
        private iCampaign.TACS.Data.ProjectsDs.ProjectsDataTable projectTable =
            new iCampaign.TACS.Data.ProjectsDs.ProjectsDataTable();
        private iCampaign.TACS.Data.ProjectsDsTableAdapters.ProjectsTableAdapter projectAdapter =
            new iCampaign.TACS.Data.ProjectsDsTableAdapters.ProjectsTableAdapter();
        private iCampaign.TACS.Data.RolesDs.RolesDataTable roleTable =
            new iCampaign.TACS.Data.RolesDs.RolesDataTable();
        private iCampaign.TACS.Data.RolesDsTableAdapters.RolesTableAdapter roleAdapter =
            new iCampaign.TACS.Data.RolesDsTableAdapters.RolesTableAdapter();
        /// <summary>
        /// RoleId property.
        /// </summary>
        private long _RoleId;
        /// <summary>
        /// Project property.
        /// </summary>
        private string _Project;
        /// <summary>
        /// AccountId property.
        /// </summary>
        private long _AccountId;

        /// <summary>
        /// Initialize instance of user role editor form.
        /// </summary>
        /// <param name="acct">long: Account id.</param>
        /// <param name="user">string: Username.</param>
        public UserRoleEditor(long acct, string user)
        {
            //  Initialize form components
            InitializeComponent();
            this.Text = user + " - Projects";
            _AccountId = acct;
            GetProjects();
            cbProject.SelectedIndex = 0;
        }

        /// <summary>
        /// Initialize instance of user role editor form.
        /// </summary>
        /// <param name="acct">long: Account id.</param>
        /// <param name="user">string: Username.</param>
        /// <param name="project">string: Project name.</param>
        /// <param name="rid">long: Selected role id.</param>
        public UserRoleEditor(long acct, string user, string project, long rid)
        {
            //  Initialize form components
            InitializeComponent();
            this.Text = user + " - Projects";
            _AccountId = acct;
            _Project = project;
            _RoleId = rid;
            GetProjects();

            //  Select the project and role being edited
            FindProject();
            FindRole();
        }

        /// <summary>
        /// Gets the role id value.
        /// </summary>
        public long RoleId
        {
            get { return _RoleId; }
        }

        /// <summary>
        /// Gets the project name.
        /// </summary>
        public string Project
        {
            get { return _Project; }
        }

        /// <summary>
        /// Gets the account id value.
        /// </summary>
        public long AccountId
        {
            get { return _AccountId; }
        }

        /// <summary>
        /// Get list of projects from database.
        /// </summary>
        private void GetProjects()
        {
            //  Initialize database objects
            projectAdapter.Connection = new System.Data.SqlClient.SqlConnection();
            projectAdapter.Connection.ConnectionString = TacsSession.ConnectionString;
            projectTable.Clear();

            //  Load projects for specified account
            try
            {
                projectAdapter.Connection.Open();
                projectAdapter.FillByAcct(projectTable, this.AccountId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error getting projects",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
            }
            finally
            {
                projectAdapter.Connection.Close();
            }

            //  Update the combobox control
            cbProject.Items.Clear();
            foreach (iCampaign.TACS.Data.ProjectsDs.ProjectsRow row in projectTable)
            {
                cbProject.Items.Add(row.Project);
            }
        }

        /// <summary>
        /// Get project roles from database.
        /// </summary>
        private void GetRoles()
        {
            //  Initialize database objects
            roleAdapter.Connection = new System.Data.SqlClient.SqlConnection();
            roleAdapter.Connection.ConnectionString = TacsSession.ConnectionString;
            roleTable.Clear();

            //  Download the roles for the selected project
            try
            {
                roleAdapter.Connection.Open();
                roleAdapter.FillByProject(roleTable, this.Project);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error getting roles",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
            }
            finally
            {
                roleAdapter.Connection.Close();
            }

            //  Display the results
            roleView.Items.Clear();
            foreach (iCampaign.TACS.Data.RolesDs.RolesRow row in roleTable)
            {
                ListViewItem item = new ListViewItem();
                item.Name = row.RoleId.ToString();
                item.Text = row.RoleName;
                ListViewItem.ListViewSubItem subItem = new ListViewItem.ListViewSubItem();
                subItem.Text = TacsSession.GetAccessLevel((iCampaign.TACS.AccessLevelEnum)row.AccessLevel);
                item.SubItems.Add(subItem);
                roleView.Items.Add(item);
            }
        }

        /// <summary>
        /// Project changed so update displayed roles.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Project = cbProject.SelectedItem.ToString();
            _RoleId = -1;
            GetRoles();
            btnOkay.Enabled = false;
        }

        /// <summary>
        /// User selected role.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void roleView_SelectedIndexChanged(object sender, EventArgs e)
        {
            _RoleId = Convert.ToInt64(roleView.SelectedItems[0].Name);
            btnOkay.Enabled = true;
        }

        /// <summary>
        /// Locate the requested project in the combobox items.
        /// </summary>
        private void FindProject()
        {
            int row = -1;
            for (int x = 0; x < cbProject.Items.Count; ++x)
            {
                if (cbProject.Items[x].ToString() == this.Project)
                    row = x;
            }
            cbProject.SelectedIndex = row;
        }

        /// <summary>
        /// Locate the requested role in the list view.
        /// </summary>
        private void FindRole()
        {
            for (int x = 0; x < roleView.Items.Count; ++x)
            {
                if (roleView.Items[x].Name == this.RoleId.ToString())
                {
                    roleView.Items[x].Selected = true;
                    roleView.Select();
                }
            }
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
        /// User double click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void roleView_DoubleClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
