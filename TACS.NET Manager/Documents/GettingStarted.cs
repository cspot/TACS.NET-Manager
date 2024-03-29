﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TACS.NET_Manager.Documents
{
    public partial class GettingStarted : TD.SandDock.UserTabbedDocument, ITacsDocument
    {
        /// <summary>
        /// ApplicationForm property.
        /// </summary>
        TACS.NET_Manager.MainForm _ApplicationForm;

        /// <summary>
        /// CurrentUrl property.
        /// </summary>
        string _CurrentUrl;

        #region Constructors
        /// <summary>
        /// Initialize instance of GettingStarted document.
        /// </summary>
        public GettingStarted(TACS.NET_Manager.MainForm parent)
        {
            _ApplicationForm = parent;
            _CurrentUrl = "\\GettingStarted.htm";

            //  Initialize controls
            InitializeComponent();
            InitializeDocument();
        }

        /// <summary>
        /// Initialize instance of browser document.
        /// </summary>
        /// <param name="parent">MainForm: parent form object.</param>
        /// <param name="url">string: Url of document to open.</param>
        /// <param name="title">string: Document title.</param>
        public GettingStarted(TACS.NET_Manager.MainForm parent, string url, string title)
        {
            _ApplicationForm = parent;
            _CurrentUrl = url;
            this.TabText = title;

            //  Initialize controls
            InitializeComponent();
            InitializeDocument();
        }
        #endregion

        #region ITacsDocument Members

        /// <summary>
        /// Gets the main application form object reference.
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
        /// Returns the current URL being displayed.
        /// </summary>
        public string CurrentUrl
        {
            get
            {
                return _CurrentUrl;
            }
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
        /// Initialize document and display HTML document.
        /// </summary>
        public void InitializeDocument()
        {
            webBrowser1.Navigate(GetURL());
        }

        #endregion

        /// <summary>
        /// Generate the URL based on the runtime directory path.
        /// </summary>
        /// <returns>string: URL</returns>
        private string GetURL()
        {
            StringBuilder url = new StringBuilder();
            string currentApp = System.Windows.Forms.Application.ExecutablePath;
            FileInfo executableFileInfo = new FileInfo(currentApp);
            url.Append(executableFileInfo.DirectoryName);
            url.Append(this.CurrentUrl);
            return url.ToString();
        }

        /// <summary>
        /// Document closing event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GettingStarted_Closing(object sender, TD.SandDock.DockControlClosingEventArgs e)
        {
            this.ApplicationForm.CloseGettingStarted();
        }
    }
}
