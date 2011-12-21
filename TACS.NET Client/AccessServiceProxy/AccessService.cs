//	iCampaign.TACS.AccessServiceProxy.AccessService
//	Copyright © 2007-2010 by c.Spot InterWorks.  All Rights Reserved.
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
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

using iCampaign.TACS;
using iCampaign.TACS.Client;
using iCampaign.TACS.Data;

namespace iCampaign.TACS.AccessServiceProxy
{
    /// <summary>
    /// Represents local provider for TACS.NET user profile services.
    /// </summary>
    public class AccessService : iCampaign.TACS.IAccessService
    {
        #region Internal methods
        /// <summary>
        /// Provides login authentication for iCampaign application returning the user
        /// access credentials.
        /// </summary>
        /// <param name="project">string: Project name.</param>
        /// <param name="user">string: User name.</param>
        /// <param name="encpass">string: Encrypted password.</param>
        /// <param name="appcode">string: Application code.</param>
        /// <returns>iCampaign.TACS.Client.Credentials: object.</returns>
        public Credentials Login(string project, string user, string encpass, string appcode)
        {
            bool errorStatus = false;

            //  Instantiate objects required for this method
            Credentials myCredentials = null;
            UserProfile userProfile = new UserProfile();

            //  Validate the application code
            if (!TacsSession.IsAppValid(appcode))
            {
                myCredentials = new Credentials(TacsSession.MSG_INVALIDAPP);
                errorStatus = true;
            }

            //  Validate the project
            if (!errorStatus)
            {
                if (!TacsSession.IsProjectValid(appcode, project))
                {
                    myCredentials = new Credentials(TacsSession.MSG_UNKPROJECT);
                    errorStatus = true;
                }
            }

            //  Authenticate the login request
            if (!errorStatus)
            {
                Data.AccessViewDs.AccessViewDataTable accessTable = new AccessViewDs.AccessViewDataTable();
                Data.AccessViewDsTableAdapters.AccessViewTableAdapter tableAdapter =
                    new iCampaign.TACS.Data.AccessViewDsTableAdapters.AccessViewTableAdapter();
                tableAdapter.Connection = new SqlConnection(TacsSession.ConnectionString);
                Data.AccessViewDs.AccessViewRow accessRow = null;
                try
                {
                    tableAdapter.Connection.Open();
                    if (tableAdapter.FillByLogin(accessTable, project, user, encpass) == 0)
                    {
                        //  Username or password is invalid so set error message
                        myCredentials = new Credentials(TacsSession.MSG_INVALIDPASS);
                        errorStatus = true;
                    }
                    else
                    {
                        //  User profile found so set row object
                        accessRow = accessTable[0];
                    }
                }
                catch (Exception ex)
                {
                    //  An exception occurred so send stack trace back
                    myCredentials = new Credentials(ex.Message);
                    errorStatus = true;
                    TacsSession.WriteEventLogEntry("AccessService", EventTypeEnum.Error,
                        ex.Message + " " + ex.StackTrace);
                }
                finally
                {
                    tableAdapter.Connection.Close();
                }
                //  If no error has occurred go ahead and check account status
                if (!errorStatus)
                {
                    //  Check for account expiration
                    if (accessRow.AcctExpirey < System.DateTime.Now)
                    {
                        myCredentials = new Credentials(TacsSession.MSG_ACCTDISABLED);
                        errorStatus = true;
                    }
                    //  Check for user profile expiration or disabled flag
                    if (accessRow.UserExpirey < System.DateTime.Now || accessRow.UserDisabled)
                    {
                        myCredentials = new Credentials(TacsSession.MSG_USERDISABLED);
                        errorStatus = true;
                    }
                }
                //  If no error has occurred go ahead and build user profile
                if (!errorStatus)
                {
                    userProfile.AccountExpirey = accessRow.AcctExpirey;
                    userProfile.AccountId = accessRow.AcctId;
                    userProfile.AccountName = accessRow.AcctName;
                    userProfile.ConnectorType = TacsSession.GetConnectorType(accessRow.ConnectorType);
                    userProfile.Database = accessRow.Database;
                    userProfile.DataSource = accessRow.DataSource;
                    userProfile.Disable = accessRow.UserDisabled;
                    userProfile.Email = accessRow.Email;
                    userProfile.ErrorMessage = TacsSession.MSG_SUCCESS;
                    userProfile.FullName = accessRow.FullName;
                    userProfile.Project = accessRow.Project;
                    userProfile.SqlPassword = accessRow.DbPassword;
                    userProfile.SqlUser = accessRow.DbUsername;
                    userProfile.UserExpirey = accessRow.UserExpirey;
                    userProfile.Username = accessRow.Username;
                    userProfile.AccountOwner = accessRow.AccountOwner;
                    userProfile.SuperAdministrator = accessRow.SuperAdministrator;

                    //  Get the security roles
                    try
                    {
                        userProfile.Roles = GetRoles(project, user);
                    }
                    catch (Exception ex)
                    {
                        myCredentials = new Credentials(ex.Message);
                        errorStatus = true;
                        TacsSession.WriteEventLogEntry("AccessService", EventTypeEnum.Error,
                        ex.Message + " " + ex.StackTrace);
                    }
                }

                //  If no error occurred go ahead and get application info
                if (!errorStatus)
                {
                    try
                    {
                        Data.ApplicationsDs.ApplicationsRow appRow =
                            GetApplicationRow(appcode);
                        userProfile.ApplicationCode = appcode;
                        userProfile.ApplicationGUID = appRow.AppGuid;
                        userProfile.DownloadURL = appRow.DownloadURL;
                    }
                    catch (Exception ex)
                    {
                        myCredentials = new Credentials(ex.Message);
                        errorStatus = true;
                        TacsSession.WriteEventLogEntry("AccessService", EventTypeEnum.Error,
                        ex.Message + " " + ex.StackTrace);
                    }
                }

                //  If no error occurred go ahead and create the session token
                if (!errorStatus)
                {
                    try
                    {
                        userProfile.SessionToken = SetSessionToken(user);
                    }
                    catch (Exception ex)
                    {
                        myCredentials = new Credentials(ex.Message);
                        errorStatus = true;
                        TacsSession.WriteEventLogEntry("AccessService", EventTypeEnum.Error,
                        ex.Message + " " + ex.StackTrace);
                    }
                }

                //  If no error occurred go ahead and create the credentials object
                if (!errorStatus)
                {
                    myCredentials = new Credentials(userProfile);
                    TacsSession.WriteEventLogEntry("Login", EventTypeEnum.Information,
                        myCredentials.Username + " successfully logged in.");
                }
                else
                {
                    TacsSession.WriteEventLogEntry("AccessService", EventTypeEnum.Warning,
                        myCredentials.Username + " login failed.");
                }
            }
            return myCredentials;
        }

        /// <summary>
        /// Add a new user profile to a TACS.NET account.
        /// </summary>
        /// <param name="user">string: Unique user name.</param>
        /// <param name="pass">string: Encrypted password.</param>
        /// <param name="name">string: Full name.</param>
        /// <param name="email">string: Email address.</param>
        /// <param name="expirey">DateTime: Expiration date.</param>
        /// <param name="owner">bool: Account owner flag.</param>
        /// <param name="superAdmin">bool: Super administrator flag.</param>
        /// <param name="role">string: Caller role being used.</param>
        /// <param name="credentials">iCampaign.TACS.Client.Credentials: Object.</param>
        /// <returns>string: Status code.</returns>
        public string AddUser(string user, string pass, string name, string email, DateTime expirey,
            bool owner, bool superAdmin, string role, Credentials credentials)
        {
            bool errorStatus = false;
            string statusMsg = "";

            //  Check to see if user has sufficient access
            if (!credentials.HasAccess(role, AccessLevelEnum.Owner) &&
                !credentials.AccountOwner && !credentials.SuperAdministrator)
            {
                errorStatus = true;
                statusMsg = TacsSession.MSG_INSUFPRIV;
            }

            //  Check for valid session token
            if (!TacsSession.IsTokenValid(credentials.Username, credentials.SessionToken))
            {
                errorStatus = true;
                statusMsg = TacsSession.MSG_INVALSESS;
            }

            //  Check to see if new account is a super admin
            if (superAdmin == true && credentials.SuperAdministrator == false)
            {
                errorStatus = true;
                statusMsg = TacsSession.MSG_SUPERONLY;
            }

            //  Check username to see if it exists
            if (!errorStatus)
            {
                if (TacsSession.DoesUserExist(user) == true)
                {
                    errorStatus = true;
                    statusMsg = TacsSession.MSG_USEREXISTS;
                }
            }

            //  Create the user profile
            if (!errorStatus)
            {
                //  Instantiate ADO.NET objects
                Data.UserDs.UsersDataTable userTable = new UserDs.UsersDataTable();
                Data.UserDs.UsersRow userRow = userTable.NewUsersRow();
                Data.UserDsTableAdapters.UsersTableAdapter tableAdapter =
                    new iCampaign.TACS.Data.UserDsTableAdapters.UsersTableAdapter();
                tableAdapter.Connection = new SqlConnection(TacsSession.ConnectionString);

                //  Build the new user profile
                userRow.AcctId = credentials.AccountId;
                userRow.CreatedOn = System.DateTime.Now;
                userRow.Email = email;
                userRow.ExpireOn = expirey;
                userRow.FullName = name;
                userRow.Password = pass;
                userRow.UserDisabled = false;
                userRow.Username = user;
                userRow.AccountOwner = owner;
                userRow.SuperAdministrator = superAdmin;
                userTable.AddUsersRow(userRow);

                //  Add the record to the database
                try
                {
                    tableAdapter.Connection.Open();
                    tableAdapter.Update(userTable);
                    statusMsg = TacsSession.MSG_SUCCESS;
                }
                catch (Exception ex)
                {
                    statusMsg = ex.StackTrace;
                    errorStatus = true;
                }
                finally
                {
                    tableAdapter.Connection.Close();
                }
            }
            return statusMsg;
        }

        /// <summary>
        /// Delete the specified user id from the TACS.NET user table.
        /// </summary>
        /// <param name="user">string: Username to delete.</param>
        /// <param name="role">string: Caller role being used.</param>
        /// <param name="credentials">iCampaign.TACS.Client.Credentials: object.</param>
        /// <returns>string: Status code.</returns>
        public string DeleteUser(string user, string role, Credentials credentials)
        {
            bool errorStatus = false;
            string statusMsg = "";

            //  Check to see if user has sufficient access
            if (!credentials.HasAccess(role, AccessLevelEnum.Owner) &&
                !credentials.AccountOwner && !credentials.SuperAdministrator)
            {
                errorStatus = true;
                statusMsg = TacsSession.MSG_INSUFPRIV;
            }

            //  Check to see if requestor owns the username in profile
            if (TacsSession.GetUserAccountId(user) != credentials.AccountId)
            {
                errorStatus = true;
                statusMsg = TacsSession.MSG_USERWRONGACCT;
            }

            //  Check for valid session token
            if (!TacsSession.IsTokenValid(credentials.Username, credentials.SessionToken))
            {
                errorStatus = true;
                statusMsg = TacsSession.MSG_INVALSESS;
            }

            //  Check username to see if it exists
            if (!errorStatus)
            {
                if (!TacsSession.DoesUserExist(user))
                {
                    errorStatus = true;
                    statusMsg = TacsSession.MSG_USERNOEXIST;
                }
            }

            //  If no error has occurred go ahead and delete the user profile
            if (!errorStatus)
            {
                Data.UserDsTableAdapters.UsersTableAdapter tableAdapter =
                    new iCampaign.TACS.Data.UserDsTableAdapters.UsersTableAdapter();
                tableAdapter.Connection = new SqlConnection(TacsSession.ConnectionString);
                try
                {
                    tableAdapter.Connection.Open();
                    tableAdapter.DeleteAccountUser(user, credentials.AccountId);
                    statusMsg = TacsSession.MSG_SUCCESS;
                }
                catch (Exception ex)
                {
                    statusMsg = ex.StackTrace;
                }
                finally
                {
                    tableAdapter.Connection.Close();
                }
            }
            return statusMsg;
        }

        /// <summary>
        /// Returns the requested user profile from the TACS.NET user table.
        /// </summary>
        /// <param name="user">string: Username.</param>
        /// <param name="role">string: Caller role being used.</param>
        /// <param name="credentials">iCampaign.TACS.Client.Credentials: object.</param>
        /// <returns>iCampaign.TACS.UserProfile</returns>
        public UserProfile GetUserProfile(string user, string role, Credentials credentials)
        {
            bool errorStatus = false;
            UserProfile userProfile = new UserProfile();

            //  Check to see if user has sufficient access
            if (!credentials.HasAccess(role, AccessLevelEnum.Owner) && user != credentials.Username &&
                !credentials.AccountOwner && !credentials.SuperAdministrator)
            {
                errorStatus = true;
                userProfile.ErrorMessage = TacsSession.MSG_INSUFPRIV;
            }

            //  Check to see if requestor owns the username in profile
            if (TacsSession.GetUserAccountId(user) != credentials.AccountId)
            {
                errorStatus = true;
                userProfile.ErrorMessage = TacsSession.MSG_USERWRONGACCT;
            }

            //  Get the user profile
            if (!errorStatus)
            {
                Data.UserDs.UsersDataTable userTable = new UserDs.UsersDataTable();
                Data.UserDs.UsersRow userRow = null;
                Data.UserDsTableAdapters.UsersTableAdapter tableAdapter =
                    new iCampaign.TACS.Data.UserDsTableAdapters.UsersTableAdapter();
                tableAdapter.Connection = new SqlConnection(TacsSession.ConnectionString);
                try
                {
                    tableAdapter.Connection.Open();
                    tableAdapter.FillByUsername(userTable, user);
                    if (userTable.Rows.Count != 0)
                    {
                        userRow = userTable[0];
                    }
                    else
                    {
                        userProfile.ErrorMessage = TacsSession.MSG_UNKUSER;
                        errorStatus = true;
                    }
                }
                catch (Exception ex)
                {
                    errorStatus = true;
                    userProfile.ErrorMessage = ex.StackTrace;
                }
                finally
                {
                    tableAdapter.Connection.Close();
                }
                if (!errorStatus)
                {
                    userProfile.Username = userRow.Username;
                    userProfile.AccountId = userRow.AcctId;
                    userProfile.CreatedOn = userRow.CreatedOn;
                    userProfile.Email = userRow.Email;
                    userProfile.FullName = userRow.FullName;
                    userProfile.ErrorMessage = TacsSession.MSG_SUCCESS;
                    userProfile.UserExpirey = userRow.ExpireOn;
                    userProfile.Disable = userRow.UserDisabled;
                    userProfile.Password = userRow.Password;
                }

            }
            return userProfile;
        }

        /// <summary>
        /// Updates the provided user profile in the TACS.NET user table.
        /// </summary>
        /// <param name="profile">iCampaign.TACS.UserProfile: object.</param>
        /// <param name="role">string: Caller role being used.</param>
        /// <param name="credentials">iCampaign.TACS.Client.Credentials: object.</param>
        /// <returns>Status code</returns>
        public string UpdateUser(UserProfile profile, string role, Credentials credentials)
        {
            bool errorStatus = false;
            string statusMsg = "";

            //  Check to see if user has sufficient access
            if (!credentials.HasAccess(role, AccessLevelEnum.Owner) &&
                !credentials.AccountOwner && !credentials.SuperAdministrator)
            {
                errorStatus = true;
                statusMsg = TacsSession.MSG_INSUFPRIV;
            }

            //  Check to see if requestor owns the username in profile
            if (TacsSession.GetUserAccountId(profile.Username) != credentials.AccountId)
            {
                errorStatus = true;
                statusMsg = TacsSession.MSG_USERWRONGACCT;
            }

            //  Check for valid session token
            if (!TacsSession.IsTokenValid(credentials.Username, credentials.SessionToken))
            {
                errorStatus = true;
                statusMsg = TacsSession.MSG_INVALSESS;
            }

            //  Check for super administrator being set
            if (profile.SuperAdministrator == true && credentials.SuperAdministrator == false)
            {
                errorStatus = true;
                statusMsg = TacsSession.MSG_SUPERONLY;
            }

            //  Check username to see if it exists
            if (!errorStatus)
            {
                if (!TacsSession.DoesUserExist(profile.Username))
                {
                    errorStatus = true;
                    statusMsg = TacsSession.MSG_USERNOEXIST;
                }
            }

            //  If no error condition exists, go ahead and update database
            if (!errorStatus)
            {
                Data.UserDsTableAdapters.UsersTableAdapter tableAdapter =
                    new iCampaign.TACS.Data.UserDsTableAdapters.UsersTableAdapter();
                tableAdapter.Connection = new SqlConnection(TacsSession.ConnectionString);
                try
                {
                    tableAdapter.Connection.Open();
                    tableAdapter.UpdateUserProfile(profile.Username, profile.Password, profile.FullName,
                        profile.Email, profile.CreatedOn, profile.UserExpirey, profile.Disable,
                        profile.SessionToken, profile.AccountId, profile.AccountOwner, profile.SuperAdministrator, profile.Username);
                    statusMsg = TacsSession.MSG_SUCCESS;
                }
                catch (Exception ex)
                {
                    errorStatus = true;
                    statusMsg = ex.Message;
                }
                finally
                {
                    tableAdapter.Connection.Close();
                }
            }
            return statusMsg;
        }

        /// <summary>
        /// Publishes list of user profiles for account id specified in Credentials.
        /// </summary>
        /// <param name="credentials">iCampaign.TACS.Client.Credentials: object.</param>
        /// <returns>System.Collections.Generic.List T:iCampaign.TACS.UserProfile</returns>
        public List<UserProfile> GetUserProfiles(Credentials credentials)
        {
            List<UserProfile> userProfiles = new List<UserProfile>();

            //  Check to see if user has sufficient access
            if (!credentials.AccountOwner)
            {
                throw new SystemException(TacsSession.MSG_INSUFPRIV);
            }

            //  Check for valid session token
            if (!TacsSession.IsTokenValid(credentials.Username, credentials.SessionToken))
            {
                throw new SystemException(TacsSession.MSG_INVALSESS);
            }

            //  Go and retrieve the list of user profiles
            Data.UserDs.UsersDataTable dataTable = new UserDs.UsersDataTable();
            Data.UserDsTableAdapters.UsersTableAdapter tableAdapter =
                new iCampaign.TACS.Data.UserDsTableAdapters.UsersTableAdapter();
            tableAdapter.Connection = new SqlConnection(TacsSession.ConnectionString);
            try
            {
                tableAdapter.Connection.Open();
                tableAdapter.FillByAcctId(dataTable, credentials.AccountId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                tableAdapter.Connection.Close();
            }

            //  Now populate the list collection from the data table
            foreach (Data.UserDs.UsersRow row in dataTable)
            {
                UserProfile profile = new UserProfile();
                profile.AccountExpirey = row.ExpireOn;
                profile.AccountId = row.AcctId;
                profile.AccountName = credentials.AccountName;
                profile.AccountOwner = row.AccountOwner;
                profile.Disable = row.UserDisabled;
                profile.Email = row.Email;
                profile.FullName = row.FullName;
                profile.Password = row.Password;
                profile.SuperAdministrator = row.SuperAdministrator;
                userProfiles.Add(profile);
            }

            return userProfiles;
        }

        /// <summary>
        /// Reset the password of the specified user in the TACS.NET database.
        /// </summary>
        /// <param name="credentials">iCampaign.TACS.Client.Credentials: object.</param>
        /// <param name="encpass">string: Encrypted password.</param>
        public void ResetPassword(Credentials credentials, string encpass)
        {
            //  Check the session token first
            if (!TacsSession.IsTokenValid(credentials.Username, credentials.SessionToken))
                throw new System.Exception(TacsSession.MSG_INVALSESS);

            //  Reset the password
            Data.UserDsTableAdapters.UsersTableAdapter tableAdapter =
                new iCampaign.TACS.Data.UserDsTableAdapters.UsersTableAdapter();
            tableAdapter.Connection = new SqlConnection(TacsSession.ConnectionString);
            try
            {
                tableAdapter.Connection.Open();
                tableAdapter.ResetPassword(encpass, credentials.Username);
            }
            catch (Exception ex)
            {
                TacsSession.WriteEventLogEntry("AccessService", EventTypeEnum.Error,
                    "ResetPassword: " + ex.Message);
                throw ex;
            }
            finally
            {
                tableAdapter.Connection.Close();
            }
        }

        /// <summary>
        /// Returns a list of roles assigned to specified user profile for all projects.
        /// </summary>
        public List<Role> GetUserRoles()
        {
            throw new System.NotImplementedException();
        }
        #endregion

        #region Private methods
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

        /// <summary>
        /// Generate a session token and update the user account.
        /// </summary>
        /// <param name="user">string: Username.</param>
        /// <returns>string: Session token.</returns>
        private string SetSessionToken(string user)
        {
            //  Prepare token
            string tokenSeed = user + DateTime.Now.ToUniversalTime().ToString();
            string token = Security.CreateHash(tokenSeed);

            //  Update the user account with the current session token
            SqlConnection sqlConn = new SqlConnection(TacsSession.ConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConn;
            sqlCommand.CommandText = "UPDATE Users SET SessionToken='" + token + "'" +
                " WHERE Username='" + user + "'";
            try
            {
                sqlConn.Open();
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConn.Close();
            }

            return token;
        }

        /// <summary>
        /// Get the request application row from the database.
        /// </summary>
        /// <param name="appcode">string: Application code.</param>
        /// <returns>iCampaign.TACS.Data.ApplicationsDs.ApplicationsRow: object.</returns>
        private Data.ApplicationsDs.ApplicationsRow GetApplicationRow(string appcode)
        {
            //  Initialize ADO.NET objects
            Data.ApplicationsDs.ApplicationsDataTable appTable = new ApplicationsDs.ApplicationsDataTable();
            Data.ApplicationsDsTableAdapters.ApplicationsTableAdapter tableAdapter =
                new iCampaign.TACS.Data.ApplicationsDsTableAdapters.ApplicationsTableAdapter();
            Data.ApplicationsDs.ApplicationsRow appRow = null;
            tableAdapter.Connection = new SqlConnection(TacsSession.ConnectionString);

            //  Fetch the application information
            try
            {
                tableAdapter.Connection.Open();
                tableAdapter.FillByAppCode(appTable, appcode);
                if (appTable.Count != 0)
                    appRow = appTable[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                tableAdapter.Connection.Close();
            }
            return appRow;
        }

        /// <summary>
        /// Get the roles for the requested project and user.
        /// </summary>
        /// <param name="project">string: Project name.</param>
        /// <param name="user">string: Username.</param>
        /// <returns>System.Collections.Generic.List: as type Role.</returns>
        private List<IRole> GetRoles(string project, string user)
        {
            List<IRole> roles = new List<IRole>();
            Data.UserRolesDs.UserRoleViewDataTable dataTable =
                new UserRolesDs.UserRoleViewDataTable();
            Data.UserRolesDsTableAdapters.UserRoleViewTableAdapter tableAdapter =
                new iCampaign.TACS.Data.UserRolesDsTableAdapters.UserRoleViewTableAdapter();
            tableAdapter.Connection = new SqlConnection(TacsSession.ConnectionString);

            //  Get project roles for requested user
            try
            {
                tableAdapter.Connection.Open();
                tableAdapter.FillByUserProject(dataTable, user, project);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                tableAdapter.Connection.Close();
            }

            //  Load into the generic list collection
            foreach (Data.UserRolesDs.UserRoleViewRow row in dataTable)
            {
                roles.Add(new Role(row.RoleName, (AccessLevelEnum)row.AccessLevel));
            }
            return roles;
        }
        #endregion
    }
}
