using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using iCampaign.TACS;
using iCampaign.TACS.Data;
using Microsoft.Win32;

namespace TACS.NET_Manager
{
    /// <summary>
    /// Provides session management features for local TACS.NET client.
    /// </summary>
    internal static class TacsSession
    {
        #region Error Messages
        internal static string MSG_INVALIDAPP = "This application is not registered in the TACS.NET database.";
        internal static string MSG_UNKPROJECT = "Specified project not found or is not registered to this application.";
        internal static string MSG_UNKUSER = "Specified username is invalid.";
        internal static string MSG_USERDISABLED = "Specified user profile is disabled. Please contact your system administrator.";
        internal static string MSG_ACCTDISABLED = "Specified account is disabled. Please contact your system administrator.";
        internal static string MSG_INVALIDPASS = "The username or password you entered is invalid.";
        internal static string MSG_USEREXISTS = "The specified username already exists.";
        internal static string MSG_USERNOEXIST = "The specified username does not exist.";
        internal static string MSG_SUCCESS = "OK";
        internal static string MSG_INSUFPRIV = "You have insufficient privileges to perform this operation.";
        internal static string MSG_INVALSESS = "Your session has expired or is invalid. Please login again.";
        internal static string MSG_USERWRONGACCT = "The specified username is not owned by your account.";
        internal static string MSG_INVALROLE = "An invalid or blank role name was provided.";
        internal static string MSG_SUPERONLY = "Only super administrators can create user profiles with super administrator privilege.";
        #endregion

        #region Properties
        /// <summary>
        /// Gets the Sql Server connection string.
        /// </summary>
        internal static string ConnectionString
        {
            get 
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\cSpot InterWorks\\TACS\\TacsDbConnect");
                return key.GetValue("ConnectionString").ToString();
            }
        }
        #endregion

        /// <summary>
        /// Returns boolean indicating whether session token is valid or not.
        /// </summary>
        /// <param name="user">string: Username.</param>
        /// <param name="token">string: Session token.</param>
        /// <param name="connectStr">string: Connection string.</param>
        /// <returns>bool</returns>
        internal static bool IsTokenValid(string user, string token)
        {
            bool returnStatus = false;

            //  Query database by username and session token
            SqlConnection sqlConn = new SqlConnection(TacsSession.ConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConn;
            sqlCommand.CommandText = "SELECT Count(*) FROM Users WHERE Username=" + user +
                " AND SessionToken='" + token + "'";
            try
            {
                sqlConn.Open();
                if ((int)sqlCommand.ExecuteScalar() == 0)
                    returnStatus = false;
                else
                    returnStatus = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConn.Close();
            }

            return returnStatus;
        }

        /// <summary>
        /// Verify if application is registered in TACS.NET database.
        /// </summary>
        /// <param name="appcode">string: Application code.</param>
        /// <returns>bool</returns>
        internal static bool IsAppValid(string appcode)
        {
            bool returnStatus = false;

            //  Query database by username and session token
            SqlConnection sqlConn = new SqlConnection(TacsSession.ConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConn;
            sqlCommand.CommandText = "SELECT Count(*) FROM Applications WHERE AppCode='" +
                appcode + "';";
            try
            {
                sqlConn.Open();
                if ((int)sqlCommand.ExecuteScalar() == 0)
                    returnStatus = false;
                else
                    returnStatus = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConn.Close();
            }

            return returnStatus;
        }

        /// <summary>
        /// Verify if requested project is valid.
        /// </summary>
        /// <param name="appcode">string: Application code.</param>
        /// <param name="project">string: Project name.</param>
        /// <returns>bool</returns>
        internal static bool IsProjectValid(string appcode, string project)
        {
            bool returnStatus = false;

            //  Query database by username and session token
            SqlConnection sqlConn = new SqlConnection(TacsSession.ConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConn;
            sqlCommand.CommandText = "SELECT Count(*) FROM AppProjectsView WHERE AppCode='" + appcode +
                "' AND Project='" + project + "'";
            try
            {
                sqlConn.Open();
                if ((int)sqlCommand.ExecuteScalar() == 0)
                    returnStatus = false;
                else
                    returnStatus = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConn.Close();
            }

            return returnStatus;
        }

        /// <summary>
        /// Verify existence of specified username in the TACS.NET database.
        /// </summary>
        /// <param name="user">string: Username.</param>
        /// <returns>bool</returns>
        internal static bool DoesUserExist(string user)
        {
            bool returnStatus = false;

            //  Query database by username and session token
            SqlConnection sqlConn = new SqlConnection(TacsSession.ConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConn;
            sqlCommand.CommandText = "SELECT Username FROM Users WHERE Username='" + user + "'";

            try
            {
                sqlConn.Open();
                if (sqlCommand.ExecuteNonQuery() == 0)
                    returnStatus = false;
                else
                    returnStatus = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConn.Close();
            }

            return returnStatus;
        }

        /// <summary>
        /// Returns the ConnectorEnum enumeration for the specified string.
        /// </summary>
        /// <param name="connector">string: Connector type.</param>
        /// <returns>ConnectorEnum: enumeration.</returns>
        internal static ConnectorEnum GetConnectorType(string connector)
        {
            ConnectorEnum connectorEnum;

            switch (connector)
            {
                case "SQL_SERVER":
                    connectorEnum = ConnectorEnum.SQL_SERVER;
                    break;
                case "MYSQL":
                    connectorEnum = ConnectorEnum.MYSQL;
                    break;
                default:
                    connectorEnum = ConnectorEnum.SQL_SERVER;
                    break;
            }

            return connectorEnum;
        }

        /// <summary>
        /// Write an event in the event log.
        /// </summary>
        /// <param name="source">string: Event source.</param>
        /// <param name="eventType">EventTypeEnum: enumeration.</param>
        /// <param name="message">string: Event message.</param>
        internal static void WriteEventLogEntry(string source, EventTypeEnum eventType,
            string message)
        {
            iCampaign.TACS.Data.EventLogDsTableAdapters.EventLogTableAdapter tableAdapter =
                new iCampaign.TACS.Data.EventLogDsTableAdapters.EventLogTableAdapter();
            tableAdapter.Connection = new SqlConnection(TacsSession.ConnectionString);
            try
            {
                tableAdapter.Connection.Open();
                tableAdapter.WriteEventLogEntry(System.DateTime.Now, source,
                    eventType.ToString(), message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                tableAdapter.Connection.Close();
            }
        }

        /// <summary>
        /// Get the account id of the specified username.
        /// </summary>
        /// <param name="user">string: Username.</param>
        /// <returns>long: Account id.</returns>
        internal static long GetUserAccountId(string user)
        {
            long acctid = -1;

            //  Create the ADO.NET objects required
            iCampaign.TACS.Data.UserDs.UsersDataTable usersTable = new iCampaign.TACS.Data.UserDs.UsersDataTable();
            iCampaign.TACS.Data.UserDs.UsersRow usersRow = null;
            iCampaign.TACS.Data.UserDsTableAdapters.UsersTableAdapter tableAdapter =
                new iCampaign.TACS.Data.UserDsTableAdapters.UsersTableAdapter();
            tableAdapter.Connection = new SqlConnection(TacsSession.ConnectionString);

            //  Lookup the record in the database
            try
            {
                tableAdapter.Connection.Open();
                tableAdapter.FillByUserAcctId(usersTable, user);
                if (usersTable.Rows.Count != 0)
                {
                    usersRow = usersTable[0];
                    acctid = usersRow.AcctId;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                tableAdapter.Connection.Close();
            }

            return acctid;
        }

        /// <summary>
        /// Returns the access level description.
        /// </summary>
        /// <param name="access">iCampaign.TACS.AccessLevelEnum: enumeration.</param>
        /// <returns></returns>
        internal static string GetAccessLevel(iCampaign.TACS.AccessLevelEnum access)
        {
            string result = String.Empty;

            switch (access)
            {
                case iCampaign.TACS.AccessLevelEnum.Administrator:
                    result = "Administrator";
                    break;
                case iCampaign.TACS.AccessLevelEnum.DataReader:
                    result = "Data Reader";
                    break;
                case iCampaign.TACS.AccessLevelEnum.DataWriter:
                    result = "Data Writer";
                    break;
                case iCampaign.TACS.AccessLevelEnum.NoAccess:
                    result = "No Access";
                    break;
                case iCampaign.TACS.AccessLevelEnum.Owner:
                    result = "Database Owner";
                    break;
            }
            return result;
        }
    }
}
