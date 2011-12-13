using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TACS.NET_Manager.Documents
{
    interface ITacsDocument
    {
        /// <summary>
        /// Gets the object reference to the parent form.
        /// </summary>
        TACS.NET_Manager.MainForm ApplicationForm
        {
            get;
        }
        /// <summary>
        /// Gets the boolean value indicating if form has changed.
        /// </summary>
        bool FormChanged
        {
            get;
        }
        /// <summary>
        /// Gets the boolean value indicating if a new record is being created.
        /// </summary>
        bool NewRecord
        {
            get;
        }
        /// <summary>
        /// Retrieve requested record from the database.
        /// </summary>
        void GetRecord();

        /// <summary>
        /// Save the current record to the database.
        /// </summary>
        void SaveRecord();

        /// <summary>
        /// Print the current form to the default printer.
        /// </summary>
        void PrintForm();

        /// <summary>
        /// Delete the current record.
        /// </summary>
        void DeleteRecord();

        /// <summary>
        /// Initialize the tabbed document controls.
        /// </summary>
        void InitializeDocument();
    }
}
