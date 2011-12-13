using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

using iCampaign.TACS;
using iCampaign.TACS.Data;

namespace TACS.NET_Manager
{
    /// <summary>
    /// Represents the methods for accessing the TACS.NET project service.
    /// </summary>
    internal class ProjectService
    {
        /// <summary>
        /// Retrieves a data table of applications currently in the TACS.NET database.
        /// </summary>
        /// <returns>iCampaign.TACS.Data.ApplicationsDs.ApplicationsDataTable</returns>
        internal iCampaign.TACS.Data.ApplicationsDs.ApplicationsDataTable GetApplications()
        {
            //  Instantiate the database objects
            ApplicationsDs.ApplicationsDataTable dataTable = new ApplicationsDs.ApplicationsDataTable();
            iCampaign.TACS.Data.ApplicationsDsTableAdapters.ApplicationsTableAdapter tableAdapter =
                new iCampaign.TACS.Data.ApplicationsDsTableAdapters.ApplicationsTableAdapter();
            tableAdapter.Connection = new SqlConnection(TacsSession.ConnectionString);

            //  Try and get the data from the TACS.NET database
            try
            {
                tableAdapter.Connection.Open();
                tableAdapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                tableAdapter.Connection.Close();
            }

            return dataTable;
        }

        /// <summary>
        /// Retrieve a data table containing the application specified.
        /// </summary>
        /// <param name="appcode">string: Application code.</param>
        /// <returns>iCampaign.TACS.Data.ApplicationsDs.ApplicationsDataTable</returns>
        internal iCampaign.TACS.Data.ApplicationsDs.ApplicationsDataTable GetApplication(string appcode)
        {
            //  Instantiate the database objects
            ApplicationsDs.ApplicationsDataTable dataTable = new ApplicationsDs.ApplicationsDataTable();
            iCampaign.TACS.Data.ApplicationsDsTableAdapters.ApplicationsTableAdapter tableAdapter =
                new iCampaign.TACS.Data.ApplicationsDsTableAdapters.ApplicationsTableAdapter();
            tableAdapter.Connection = new SqlConnection(TacsSession.ConnectionString);

            //  Try and get the data from the TACS.NET database
            try
            {
                tableAdapter.Connection.Open();
                tableAdapter.FillByAppCode(dataTable, appcode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                tableAdapter.Connection.Close();
            }

            return dataTable;
        }

        /// <summary>
        /// Retrieves a data table containing accounts in the TACS.NET database.
        /// </summary>
        /// <returns>iCampaign.TACS.Data.AccountsDs.AccountsDataTable</returns>
        internal iCampaign.TACS.Data.AccountsDs.AccountsDataTable GetAccounts()
        {
            //  Instantiate the database objects
            AccountsDs.AccountsDataTable dataTable = new AccountsDs.AccountsDataTable();
            iCampaign.TACS.Data.AccountsDsTableAdapters.AccountsTableAdapter tableAdapter =
                new iCampaign.TACS.Data.AccountsDsTableAdapters.AccountsTableAdapter();
            tableAdapter.Connection = new SqlConnection(TacsSession.ConnectionString);

            //  Try to get the data from the database server
            try
            {
                tableAdapter.Connection.Open();
                tableAdapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                tableAdapter.Connection.Close();
            }

            return dataTable;
        }

        /// <summary>
        /// Retrieves a data table containing the projects under the specified account id.
        /// </summary>
        /// <param name="acctId">long: Account id.</param>
        /// <returns>iCampaign.TACS.Data.ProjectDs.ProjectsDataTable</returns>
        internal iCampaign.TACS.Data.ProjectsDs.ProjectsDataTable GetProjects(long acctId)
        {
            //  Instantiate the database objects
            ProjectsDs.ProjectsDataTable dataTable = new ProjectsDs.ProjectsDataTable();
            iCampaign.TACS.Data.ProjectsDsTableAdapters.ProjectsTableAdapter tableAdapter =
                new iCampaign.TACS.Data.ProjectsDsTableAdapters.ProjectsTableAdapter();
            tableAdapter.Connection = new SqlConnection(TacsSession.ConnectionString);

            //  Try to get the data from the database server
            try
            {
                tableAdapter.Connection.Open();
                tableAdapter.FillByAcct(dataTable, acctId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                tableAdapter.Connection.Close();
            }

            return dataTable;
        }
    }
}
