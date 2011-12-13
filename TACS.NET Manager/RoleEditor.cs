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
    public partial class RoleEditor : Form
    {
        private iCampaign.TACS.Role _Role;

        /// <summary>
        /// Initialize instance of role editor form.
        /// </summary>
        /// <param name="project">string: Project name.</param>
        public RoleEditor(string project)
        {
            //  Initialize form controls
            InitializeComponent();
            this.Text = project + " - Role";
            cbAccess.SelectedIndex = 0;
            _Role = new iCampaign.TACS.Role();
        }

        /// <summary>
        /// Initialize instance of role editor form.
        /// </summary>
        /// <param name="project">string: Project name.</param>
        /// <param name="role">iCampaign.TACS.Role: object.</param>
        public RoleEditor(string project, iCampaign.TACS.Role role)
        {
            //  Initialize form controls
            InitializeComponent();
            this.Text = project + " - Role";

            //  Load the role object onto the form
            _Role = role;
            tbRole.Text = this.Role.Name;
            cbAccess.SelectedIndex = (int)this.Role.AccessLevel;
        }

        /// <summary>
        /// Gets the Role object.
        /// </summary>
        public iCampaign.TACS.Role Role
        {
            get { return _Role; }
        }

        /// <summary>
        /// OK button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOkay_Click(object sender, EventArgs e)
        {
            _Role.Name = tbRole.Text.ToString();
            _Role.AccessLevel = (iCampaign.TACS.AccessLevelEnum)cbAccess.SelectedIndex;
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
        /// Text box change event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbRole_TextChanged(object sender, EventArgs e)
        {
            if (tbRole.Text.Length == 0)
                btnOkay.Enabled = false;
            else
                btnOkay.Enabled = true;
        }
    }
}
