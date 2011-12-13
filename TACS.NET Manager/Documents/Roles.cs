using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TACS.NET_Manager.Documents
{
    public partial class Roles : TD.SandDock.UserTabbedDocument, ITacsDocument
    {
        /// <summary>
        /// ParentForm property.
        /// </summary>
        private MainForm _ParentForm;
        private bool _FormChanged;

        private iCampaign.TACS.Data.RolesDs.RolesDataTable dataTable;
        private iCampaign.TACS.Data.RolesDsTableAdapters.RolesTableAdapter tableAdapter;
        private string projectName;

        /// <summary>
        /// Initialize instance of Roles tabbed document.
        /// </summary>
        /// <param name="project">string: Project name.</param>
        public Roles(MainForm parent, string project)
        {
            if (project.Length == 0)
                throw new System.ArgumentNullException("You must provide a valid project name.");
            _ParentForm = parent;
            projectName = project;
            this.Text = project + " - [Roles]";

            //  Initialize components
            InitializeComponent();
            dataTable = new iCampaign.TACS.Data.RolesDs.RolesDataTable();
            tableAdapter = new iCampaign.TACS.Data.RolesDsTableAdapters.RolesTableAdapter();
            tableAdapter.Connection = new System.Data.SqlClient.SqlConnection(TacsSession.ConnectionString);
            GetRecord();
        }

        #region ITacsDocument Members

        /// <summary>
        /// Gets the parent form object reference.
        /// </summary>
        public MainForm ApplicationForm
        {
            get { return _ParentForm; }
        }

        /// <summary>
        /// Gets the form changed status flag.
        /// </summary>
        public bool FormChanged
        {
            get { return _FormChanged; }
        }

        /// <summary>
        /// Not implemented in this class.
        /// </summary>
        public bool NewRecord
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Get records from the database and display on data grid view.
        /// </summary>
        public void GetRecord()
        {
            listRoles.Items.Clear();
            try
            {
                tableAdapter.Connection.Open();
                tableAdapter.FillByProject(dataTable, projectName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error getting records",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                tableAdapter.Connection.Close();
            }
        }

        /// <summary>
        /// Save records to the database server.
        /// </summary>
        public void SaveRecord()
        {

        }

        /// <summary>
        /// Not implemented in this class.
        /// </summary>
        public void PrintForm()
        {
            throw new NotImplementedException();
        }

        public void DeleteRecord()
        {
            throw new NotImplementedException();
        }

        public void InitializeDocument()
        {
            throw new NotImplementedException();
        }

        #endregion

        /// <summary>
        /// Save button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Activate(object sender, EventArgs e)
        {
            SaveRecord();
        }

        /// <summary>
        /// Form closing event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Roles_Closing(object sender, TD.SandDock.DockControlClosingEventArgs e)
        {
            if (this.FormChanged)
            {
                if (MessageBox.Show("Do you wish to save your changes first?",
                    "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SaveRecord();
                }
            }
        }
    }
}
