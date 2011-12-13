using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TACS.NET_Manager.Documents
{
    public partial class Events : TD.SandDock.UserTabbedDocument, ITacsDocument
    {
        /// <summary>
        /// ApplicationForm property.
        /// </summary>
        private TACS.NET_Manager.MainForm _ApplicationForm;

        /// <summary>
        /// Initialize instance of event viewer tabbed document.
        /// </summary>
        public Events(TACS.NET_Manager.MainForm parent)
        {
            _ApplicationForm = parent;

            //  Initialize controls and display data
            InitializeComponent();
            InitializeDocument();
        }

        #region ITacsDocument Members
        
        /// <summary>
        /// Gets the main application form reference.
        /// </summary>
        public MainForm ApplicationForm
        {
            get { return _ApplicationForm; }
        }

        /// <summary>
        /// Not implemented.
        /// </summary>
        public bool FormChanged
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Not implemented.
        /// </summary>
        public bool NewRecord
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Not implemented.
        /// </summary>
        public void GetRecord()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented.
        /// </summary>
        public void SaveRecord()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented.
        /// </summary>
        public void PrintForm()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented.
        /// </summary>
        public void DeleteRecord()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Initialize data grid view with database data.
        /// </summary>
        public void InitializeDocument()
        {
            iCampaign.TACS.Data.EventLogDsTableAdapters.EventLogTableAdapter tableAdapter =
                new iCampaign.TACS.Data.EventLogDsTableAdapters.EventLogTableAdapter();
            tableAdapter.Connection = new System.Data.SqlClient.SqlConnection(TacsSession.ConnectionString);
            try
            {
                tableAdapter.Fill(eventLogDs1.EventLog);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error getting event log",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            eventGrid.Refresh();
        }

        #endregion

        /// <summary>
        /// Refresh button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Activate(object sender, EventArgs e)
        {
            InitializeDocument();
        }

        /// <summary>
        /// Clear button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Activate(object sender, EventArgs e)
        {
            if (MessageBox.Show("You are about to clear the event log!  Are you sure you want to do this?",
                "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                SqlConnection sqlConn = new SqlConnection(TacsSession.ConnectionString);
                SqlCommand sqlCmd = new SqlCommand("DELETE FROM [EventLog];", sqlConn);
                try
                {
                    sqlConn.Open();
                    sqlCmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error clearing event log",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    sqlConn.Close();
                }
                InitializeDocument();
            }
        }

        /// <summary>
        /// Update main user interface.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Events_Closing(object sender, TD.SandDock.DockControlClosingEventArgs e)
        {
            this.ApplicationForm.CloseEventViewer();
        }

    }
}
