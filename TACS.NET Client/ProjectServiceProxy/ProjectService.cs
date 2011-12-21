//	iCampaign.TACS.ProjectServiceProxy.ProjectService (local)
//	Copyright (c) 2007-2009 by c.Spot InterWorks.  All Rights Reserved.
//
//	The above copyright notice and this permission notice shall be included in all 
//	copies or substantial portions of the Software.
//
//	THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
//	INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
//	PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE 
//	FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
//	ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS 
//  IN THE SOFTWARE.

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

using iCampaign.TACS;
using iCampaign.TACS.Client;
using iCampaign.TACS.Data;

namespace iCampaign.TACS.ProjectServiceProxy
{
    /// <summary>
    /// Represents local service provider for TACS.NET project database management.
    /// </summary>
    internal class ProjectService
    {
        #region Constructor
        /// <summary>
        /// Initialize instance of project service.
        /// </summary>
        public ProjectService()
        {
        }
        #endregion

        /// <summary>
        /// Get list of available projects for specified application.
        /// </summary>
        /// <param name="appcode">string: Application code.</param>
        /// <returns>System.Collections.Generic.List<string></returns>
        internal List<string> GetProjectsByApp(string appcode)
        {
            List<string> results = new List<string>();

            //  Check argument to make sure a value was passed
            if (appcode.Length == 0)
                throw new System.ArgumentException("You must specify a valid application code in argument.");

            //  Create database objects
            Data.ProjectsDs.ProjectsDataTable projectTable = new ProjectsDs.ProjectsDataTable();
            Data.ProjectsDsTableAdapters.ProjectsTableAdapter tableAdapter =
                new iCampaign.TACS.Data.ProjectsDsTableAdapters.ProjectsTableAdapter();
            tableAdapter.Connection = new SqlConnection(TacsSession.ConnectionString);

            //  Query the database
            try
            {
                tableAdapter.Connection.Open();
                tableAdapter.FillByApp(projectTable, appcode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                tableAdapter.Connection.Close();
            }

            //  Transfer database results to the list collection
            foreach (Data.ProjectsDs.ProjectsRow row in projectTable)
            {
                results.Add(row.Project);
            }

            return results;
        }

        /// <summary>
        /// Get list of available projects for specified account id.
        /// </summary>
        /// <param name="acctid">long: Account id.</param>
        /// <returns>System.Collections.Generic.List<string></returns>
        internal List<string> GetProjectsByAcct(long acctid)
        {
            List<string> results = new List<string>();

            //  Check argument to make sure a value was passed
            if (acctid <= 0)
                throw new System.ArgumentException("You must specify a valid account id in argument.");

            //  Create database objects
            Data.ProjectsDs.ProjectsDataTable projectTable = new ProjectsDs.ProjectsDataTable();
            Data.ProjectsDsTableAdapters.ProjectsTableAdapter tableAdapter =
                new iCampaign.TACS.Data.ProjectsDsTableAdapters.ProjectsTableAdapter();
            tableAdapter.Connection = new SqlConnection(TacsSession.ConnectionString);

            //  Query the database
            try
            {
                tableAdapter.Connection.Open();
                tableAdapter.FillByAcct(projectTable, acctid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                tableAdapter.Connection.Close();
            }

            //  Transfer database results to the list collection
            foreach (Data.ProjectsDs.ProjectsRow row in projectTable)
            {
                results.Add(row.Project);
            }

            return results;
        }

        /// <summary>
        /// Get project profile from TACS.NET database for specified project.
        /// </summary>
        /// <param name="project">string: Project name.</param>
        /// <param name="role">string: Caller role being used.</param>
        /// <param name="credentials">iCampaign.TACS.Client.Credentials: object.</param>
        /// <returns>iCampaign.TACS.ProjectProfile: object.</returns>
        internal ProjectProfile GetProject(string project, string role, iCampaign.TACS.Client.Credentials credentials)
        {
            bool errorStatus = false;
            ProjectProfile result = new ProjectProfile();

            //  Check to see if user has sufficient access
            if (!credentials.HasAccess(role, AccessLevelEnum.Owner))
            {
                errorStatus = true;
                result.ErrorMessage = TacsSession.MSG_INSUFPRIV;
            }

            //  Check for valid session token
            if (!TacsSession.IsTokenValid(credentials.Username, credentials.SessionToken))
            {
                errorStatus = true;
                result.ErrorMessage = TacsSession.MSG_INVALSESS;
            }

            //  Check to see if project is valid
            if (!errorStatus)
            {
                if (!TacsSession.IsProjectValid(credentials.ApplicationCode, project))
                {
                    errorStatus = true;
                    result.ErrorMessage = TacsSession.MSG_UNKPROJECT;
                }
            }

            //  If no error exists, go ahead and get project profile
            if (!errorStatus)
            {
                Data.ProjectsDs.ProjectsDataTable projectTable = new ProjectsDs.ProjectsDataTable();
                Data.ProjectsDsTableAdapters.ProjectsTableAdapter tableAdapter =
                    new iCampaign.TACS.Data.ProjectsDsTableAdapters.ProjectsTableAdapter();
                Data.ProjectsDs.ProjectsRow row = null;
                tableAdapter.Connection = new SqlConnection(TacsSession.ConnectionString);
                try
                {
                    tableAdapter.Connection.Open();
                    tableAdapter.FillByProject(projectTable, project);
                    row = projectTable[0];
                }
                catch (Exception ex)
                {
                    result.ErrorMessage = ex.Message;
                    errorStatus = true;
                }
                finally
                {
                    tableAdapter.Connection.Close();
                }
                if (!errorStatus)
                {
                    result.Project = row.Project;
                    result.ConnectorType = TacsSession.GetConnectorType(row.ConnectorType);
                    result.DataSource = row.DataSource;
                    result.Database = row.Database;
                    result.Username = row.Username;
                    result.Password = row.Password;
                    result.CreatedOn = row.CreatedOn;
                    result.ApplicationCode = row.AppCode;
                    result.AccountId = row.AcctId;
                    result.ErrorMessage = TacsSession.MSG_SUCCESS;
                }
            }

            return result;
        }

        internal string DeleteProject(string project, string role, Credentials credentials)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Add a new project to an account in the TACS.NET database.
        /// </summary>
        /// <param name="project">iCampaign.TACS.ProjectProfile: object.</param>
        /// <param name="credentials">iCampaign.TACS.Client.Credentials: object.</param>
        /// <returns>string: Status message.</returns>
        internal string AddProject(ProjectProfile project, Credentials credentials)
        {
            bool errorStatus = false;
            string result = String.Empty;

            //  Check to see if user has sufficient privilege
            if (!credentials.AccountOwner)
            {
                result = TacsSession.MSG_INSUFPRIV;
                errorStatus = true;
            }

            //  If no error exists, create the database objects and insert the record
            if (!errorStatus)
            {
                Data.ProjectsDs.ProjectsDataTable projectTable =
                    new ProjectsDs.ProjectsDataTable();
                Data.ProjectsDs.ProjectsRow row = projectTable.NewProjectsRow();
                Data.ProjectsDsTableAdapters.ProjectsTableAdapter tableAdapter =
                    new iCampaign.TACS.Data.ProjectsDsTableAdapters.ProjectsTableAdapter();
                tableAdapter.Connection = new SqlConnection(TacsSession.ConnectionString);
                try
                {
                    tableAdapter.Connection.Open();
                    row.AcctId = credentials.AccountId;
                    row.AppCode = project.ApplicationCode;
                    row.ConnectorType = project.ConnectorType.ToString();
                    row.CreatedOn = DateTime.Now;
                    row.Database = project.Database;
                    row.DataSource = project.DataSource;
                    row.Password = project.Password;
                    row.Project = project.Project;
                    row.Username = project.Username;
                    projectTable.AddProjectsRow(row);
                    tableAdapter.Update(projectTable);
                }
                catch (Exception ex)
                {
                    errorStatus = true;
                    result = ex.Message;
                }
                finally
                {
                    tableAdapter.Connection.Close();
                }
            }

            if (!errorStatus)
                result = TacsSession.MSG_SUCCESS;
            return result;
        }

        /// <summary>
        /// Add a new security role to the specified project.
        /// </summary>
        /// <param name="newRole">iCampaign.TACS.Role: object.</param>
        /// <param name="role">string: Caller role being used.</param>
        /// <param name="credentials">iCampaign.TACS.Client.Credentials: object.</param>
        public string AddRole(Role newRole, string role, Credentials credentials)
        {
            string result = String.Empty;
            bool errorStatus = false;

            //  Check to see if user has sufficient access
            if (!credentials.HasAccess(role, AccessLevelEnum.Owner) || credentials.AccountOwner)
            {
                errorStatus = true;
                result = TacsSession.MSG_INSUFPRIV;
            }

            //  Check for valid session token
            if (!TacsSession.IsTokenValid(credentials.Username, credentials.SessionToken))
            {
                errorStatus = true;
                result = TacsSession.MSG_INVALSESS;
            }

            //  Verify that a role name was provided
            if (newRole.Name.Length == 0)
            {
                errorStatus = true;
                result = TacsSession.MSG_INVALROLE;
            }

            //  If no error condition exists, go ahead and add the new role
            if (!errorStatus)
            {
                Data.RolesDs.RolesDataTable rolesTable = new RolesDs.RolesDataTable();
                Data.RolesDs.RolesRow rolesRow = rolesTable.NewRolesRow();
                Data.RolesDsTableAdapters.RolesTableAdapter tableAdapter =
                    new iCampaign.TACS.Data.RolesDsTableAdapters.RolesTableAdapter();
                tableAdapter.Connection = new SqlConnection(TacsSession.ConnectionString);
                try
                {
                    rolesRow.RoleName = newRole.Name;
                    rolesRow.AccessLevel = (int)newRole.AccessLevel;
                    rolesTable.AddRolesRow(rolesRow);
                    tableAdapter.Connection.Open();
                    tableAdapter.Update(rolesTable);
                    result = TacsSession.MSG_SUCCESS;
                }
                catch (Exception ex)
                {
                    errorStatus = true;
                    result = ex.Message;
                }
                finally
                {
                    tableAdapter.Connection.Close();
                }
            }

            return result;
        }

        /// <summary>
        /// Assign a project role to specified user profile.
        /// </summary>
        /// <param name="username">string: Username to assign.</param>
        /// <param name="roleId">long: Role id to assign.</param>
        /// <param name="role">string: Caller role being used.</param>
        /// <param name="credentials">iCampaign.TACS.Client.Credentials: object.</param>
        /// <returns>string: Status message.</returns>
        public string AddUserRole(string username, long roleId, string role, Credentials credentials)
        {
            bool errorStatus = false;
            string result = String.Empty;

            //  Check to see if user has sufficient access
            if (!credentials.HasAccess(role, AccessLevelEnum.Owner) || credentials.AccountOwner)
            {
                errorStatus = true;
                result = TacsSession.MSG_INSUFPRIV;
            }

            //  Check for valid session token
            if (!TacsSession.IsTokenValid(credentials.Username, credentials.SessionToken))
            {
                errorStatus = true;
                result = TacsSession.MSG_INVALSESS;
            }

            //  If no error condition exists, add go ahead and assign the user roles
            if (!errorStatus)
            {
                Data.UserProjectsDs.UserProjectsDataTable dataTable =
                    new UserProjectsDs.UserProjectsDataTable();
                Data.UserProjectsDs.UserProjectsRow dataRow = dataTable.NewUserProjectsRow();
                Data.UserProjectsDsTableAdapters.UserProjectsTableAdapter tableAdapter =
                    new iCampaign.TACS.Data.UserProjectsDsTableAdapters.UserProjectsTableAdapter();
                tableAdapter.Connection = new SqlConnection(TacsSession.ConnectionString);
                try
                {
                    dataRow.CreatedOn = System.DateTime.Now;
                    dataRow.RoleId = roleId;
                    dataRow.Project = credentials.Project;
                    dataRow.Username = username;
                    dataTable.AddUserProjectsRow(dataRow);
                    tableAdapter.Connection.Open();
                    tableAdapter.Update(dataTable);
                    result = TacsSession.MSG_SUCCESS;
                }
                catch (Exception ex)
                {
                    errorStatus = true;
                    result = ex.Message;
                }
                finally
                {
                    tableAdapter.Connection.Close();
                }
            }
            return result;
        }

        /// <summary>
        /// Get a list of accounts registered in TACS.NET database.
        /// </summary>
        /// <param name="credentials">iCampaign.TACS.Client.Credentials: object.</param>
        /// <returns>System.Collections.Generic.List T:string</returns>
        internal List<string> GetAccounts(Credentials credentials)
        {
            List<string> resultList = new List<string>();

            //  Check to see if user has sufficient access
            if (!credentials.SuperAdministrator)
            {
                throw new System.Exception(TacsSession.MSG_INSUFPRIV);
            }

            //  Check for valid session token
            if (!TacsSession.IsTokenValid(credentials.Username, credentials.SessionToken))
            {
                throw new System.Exception(TacsSession.MSG_INVALSESS);
            }

            //  Get the list of accounts from the database
            Data.AccountsDs.AccountsDataTable dataTable = new AccountsDs.AccountsDataTable();
            Data.AccountsDsTableAdapters.AccountsTableAdapter tableAdapter =
                new iCampaign.TACS.Data.AccountsDsTableAdapters.AccountsTableAdapter();
            tableAdapter.Connection = new SqlConnection(TacsSession.ConnectionString);
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

            //  Copy the data table to a list collection
            foreach (Data.AccountsDs.AccountsRow row in dataTable)
            {
                resultList.Add(row.AcctName);
            }
            return resultList;
        }

        /// <summary>
        /// Get list of account profiles registered in TACS.NET database.
        /// </summary>
        /// <param name="credentials">iCamapaign.TACS.Client.Credentials: object.</param>
        /// <returns>System.Collections.Generic.List T:iCampaign.TACS.AccountProfile</returns>
        internal List<AccountProfile> GetAccountProfiles(Credentials credentials)
        {
            List<AccountProfile> profileList = new List<AccountProfile>();

            //  Check to see if user has sufficient access
            if (!credentials.SuperAdministrator)
            {
                throw new System.Exception(TacsSession.MSG_INSUFPRIV);
            }

            //  Check for valid session token
            if (!TacsSession.IsTokenValid(credentials.Username, credentials.SessionToken))
            {
                throw new System.Exception(TacsSession.MSG_INVALSESS);
            }

            //  Retrieve the list of account profiles from the database
            Data.AccountsDs.AccountsDataTable dataTable = new AccountsDs.AccountsDataTable();
            Data.AccountsDsTableAdapters.AccountsTableAdapter tableAdapter =
                new iCampaign.TACS.Data.AccountsDsTableAdapters.AccountsTableAdapter();
            tableAdapter.Connection = new SqlConnection(TacsSession.ConnectionString);
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

            //  Transfer data from data table to list collection
            foreach (Data.AccountsDs.AccountsRow row in dataTable)
            {
                AccountProfile profile = new AccountProfile();
                profile.Account = row.AcctName;
                profile.AccountId = row.AcctId;
                profile.Address1 = row.Address1;
                profile.Address2 = row.Address2;
                profile.City = row.City;
                profile.Contact = row.Contact;
                profile.CreatedOn = row.CreatedOn;
                profile.Email = row.Email;
                profile.ExpireOn = row.ExpireOn;
                profile.Phone = row.Phone;
                profile.State = row.State;
                profile.ZipCode = row.ZipCode;
                profileList.Add(profile);
            }
            return profileList;
        }

        /// <summary>
        /// Get an account profile registered in TACS.NET database.
        /// </summary>
        /// <param name="acctId">long: Account id.</param>
        /// <param name="credentials">iCamapaign.TACS.Client.Credentials: object.</param>
        /// <returns>System.Collections.Generic.List T:iCampaign.TACS.AccountProfile</returns>
        internal AccountProfile GetAccountProfile(long acctId, Credentials credentials)
        {
            AccountProfile profile = null;

            //  Check to see if user has sufficient access
            if (!credentials.SuperAdministrator)
            {
                throw new System.Exception(TacsSession.MSG_INSUFPRIV);
            }

            //  Check for valid session token
            if (!TacsSession.IsTokenValid(credentials.Username, credentials.SessionToken))
            {
                throw new System.Exception(TacsSession.MSG_INVALSESS);
            }

            //  Retrieve the list of account profiles from the database
            Data.AccountsDs.AccountsDataTable dataTable = new AccountsDs.AccountsDataTable();
            Data.AccountsDsTableAdapters.AccountsTableAdapter tableAdapter =
                new iCampaign.TACS.Data.AccountsDsTableAdapters.AccountsTableAdapter();
            tableAdapter.Connection = new SqlConnection(TacsSession.ConnectionString);
            try
            {
                tableAdapter.Connection.Open();
                tableAdapter.FillByAcctId(dataTable, acctId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                tableAdapter.Connection.Close();
            }

            //  Transfer data from data table to list collection
            Data.AccountsDs.AccountsRow row = dataTable[0];
            profile.Account = row.AcctName;
            profile.AccountId = row.AcctId;
            profile.Address1 = row.Address1;
            profile.Address2 = row.Address2;
            profile.City = row.City;
            profile.Contact = row.Contact;
            profile.CreatedOn = row.CreatedOn;
            profile.Email = row.Email;
            profile.ExpireOn = row.ExpireOn;
            profile.Phone = row.Phone;
            profile.State = row.State;
            profile.ZipCode = row.ZipCode;
            return profile;
        }

        /// <summary>
        /// Returns a valid ADO.NET SQL connection string based on the credentials object.
        /// </summary>
        /// <param name="server">string: SQL Server name or IP address.</param>
        /// <param name="database">string: Database name.</param>
        /// <param name="user">string: Database username.</param>
        /// <param name="pass">string: Database password.</param>
        /// <param name="app">string: Application token.</param>
        /// <returns></returns>
        private string GetConnectionString(string server, string database, string user, string pass, string app)
        {
            SqlConnectionStringBuilder connBuilder = new SqlConnectionStringBuilder();
            connBuilder.ApplicationName = app;
            connBuilder.ConnectTimeout = 120;
            connBuilder.DataSource = server;
            connBuilder.InitialCatalog = database;
            connBuilder.IntegratedSecurity = false;
            connBuilder.Password = pass;
            connBuilder.Pooling = true;
            connBuilder.UserID = user;

            return connBuilder.ConnectionString;
        }
    }
}
