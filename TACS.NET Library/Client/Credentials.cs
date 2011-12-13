//	iCampaign.TACS.Client.Credentials
//	Copyright © 2007 by c.Spot InterWorks.  All Rights Reserved.
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
using System.Data.Sql;
using System.Data.SqlClient;
using System.Text;

namespace iCampaign.TACS.Client
{
    /// <summary>
    /// Represents the TACS.NET credentials object used for access control.
    /// </summary>
    [Serializable]
    public class Credentials : iCampaign.TACS.Client.ICredentials
    {
        #region Fields
        /// <summary>
        /// AccountId property.
        /// </summary>
        private long _AccountId = -1;
        /// <summary>
        /// AccountName property.
        /// </summary>
        private string _AccountName = String.Empty;
        /// <summary>
        /// Project property.
        /// </summary>
        private string _Project = String.Empty;
        /// <summary>
        /// Username property.
        /// </summary>
        private string _Username = String.Empty;
        /// <summary>
        /// FullName property.
        /// </summary>
        private string _FullName = String.Empty;
        /// <summary>
        /// DataSource property.
        /// </summary>
        private string _DataSource = String.Empty;
        /// <summary>
        /// Database property.
        /// </summary>
        private string _Database = String.Empty;
        /// <summary>
        /// SqlUser property.
        /// </summary>
        private string _SqlUser = String.Empty;
        /// <summary>
        /// SqlPassword property.
        /// </summary>
        private string _SqlPassword = String.Empty;
        /// <summary>
        /// ErrorMessage property.
        /// </summary>
        private string _ErrorMessage = String.Empty;
        /// <summary>
        /// Email property.
        /// </summary>
        private string _Email = String.Empty;
        /// <summary>
        /// UserExpirey property.
        /// </summary>
        private DateTime _ExpireyDate = System.DateTime.Now;
        /// <summary>
        /// AccessLevel property.
        /// </summary>
        private AccessLevelEnum _AccessLevel = AccessLevelEnum.NoAccess;
        /// <summary>
        /// Disabled property.
        /// </summary>
        private bool _Disabled = true;
        /// <summary>
        /// DownloadUrl property.
        /// </summary>
        private string _DownloadUrl = String.Empty;
        /// <summary>
        /// SessionToken property.
        /// </summary>
        private string _SessionToken = String.Empty;
        /// <summary>
        /// ConnectorType property.
        /// </summary>
        private ConnectorEnum _ConnectorType = ConnectorEnum.SQL_SERVER;
        /// <summary>
        /// Roles property.
        /// </summary>
        private List<iCampaign.TACS.IRole> _Roles = new List<IRole>();
        /// <summary>
        /// ApplicationCode property.
        /// </summary>
        private string _ApplicationCode = String.Empty;
        /// <summary>
        /// ApplicationGUID property.
        /// </summary>
        private string _ApplicationGUID = String.Empty;
        /// <summary>
        /// AccountOwner property.
        /// </summary>
        private bool _AccountOwner = false;
        /// <summary>
        /// SuperAdministrator property.
        /// </summary>
        private bool _SuperAdministrator = false;
        #endregion

        #region Constructor
        /// <summary>
        /// Initialize instance of credentials object.
        /// </summary>
        public Credentials()
        {
            _Disabled = true;
        }

        /// <summary>
        /// Initialize instance of credentials object with error message.
        /// </summary>
        /// <param name="err">string: Error message.</param>
        public Credentials(string err)
        {
            _ErrorMessage = err;
            _Disabled = true;
        }

        /// <summary>
        /// Initialize instance of credentials object based on user profile.
        /// </summary>
        /// <param name="profile">iCampaign.TACS.UserProfile: object.</param>
        public Credentials(UserProfile profile)
        {
            _AccountId = profile.AccountId;
            _AccountName = profile.AccountName;
            _ApplicationCode = profile.ApplicationCode;
            _ApplicationGUID = profile.ApplicationGUID;
            _ConnectorType = profile.ConnectorType;
            _Database = profile.Database;
            _DataSource = profile.DataSource;
            _Disabled = profile.Disable;
            _DownloadUrl = profile.DownloadURL;
            _Email = profile.Email;
            _ErrorMessage = profile.ErrorMessage;
            _ExpireyDate = profile.UserExpirey;
            _FullName = profile.FullName;
            _Project = profile.Project;
            _Roles = profile.Roles;
            _SessionToken = profile.SessionToken;
            _SqlPassword = profile.SqlPassword;
            _SqlUser = profile.SqlUser;
            _Username = profile.Username;
            _SuperAdministrator = profile.SuperAdministrator;
            _AccountOwner = profile.AccountOwner;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the account id user profile is registered under.
        /// </summary>
        public long AccountId
        {
            get { return _AccountId; }
        }

        /// <summary>
        /// Gets the account name user is registered under.
        /// </summary>
        public string AccountName
        {
            get { return _AccountName; }
        }

        /// <summary>
        /// Gets the project name user is currently using.
        /// </summary>
        public string Project
        {
            get { return _Project; }
        }

        /// <summary>
        /// Gets the username that is currently in use.
        /// </summary>
        public string Username
        {
            get { return _Username; }
        }

        /// <summary>
        /// Gets the user's full name.
        /// </summary>
        public string FullName
        {
            get { return _FullName; }
        }

        /// <summary>
        /// Gets the database server name.
        /// </summary>
        public string DataSource
        {
            get { return _DataSource; }
        }

        /// <summary>
        /// Gets the database name.
        /// </summary>
        public string Database
        {
            get { return _Database; }
        }

        /// <summary>
        /// Gets the SQL database username.
        /// </summary>
        public string SqlUser
        {
            get { return _SqlUser; }
        }

        /// <summary>
        /// Gets the SQL database password.
        /// </summary>
        public string SqlPassword
        {
            get { return _SqlPassword; }
        }

        /// <summary>
        /// Gets the ODBC connection string for these credentials.
        /// </summary>
        public string ConnectionString
        {
            get { return SetConnectionString(); }
        }

        /// <summary>
        /// Gets the access service error message.
        /// </summary>
        public string ErrorMessage
        {
            get { return _ErrorMessage; }
        }

        /// <summary>
        /// Gets the user's e-mail address.
        /// </summary>
        public string Email
        {
            get { return _Email; }
        }

        /// <summary>
        /// Gets the user account expiration date.
        /// </summary>
        public DateTime ExpireyDate
        {
            get { return _ExpireyDate; }
        }

        /// <summary>
        /// Gets the user's access level for the project.
        /// </summary>
        public AccessLevelEnum AccessLevel
        {
            get { return _AccessLevel; }
        }

        /// <summary>
        /// Gets the disabled account flag.
        /// </summary>
        public bool Disabled
        {
            get { return _Disabled; }
        }

        /// <summary>
        /// Gets the software upgrade download URL.
        /// </summary>
        public string DownloadUrl
        {
            get { return _DownloadUrl; }
        }

        /// <summary>
        /// Gets the session token used by the iCampaign application.
        /// </summary>
        public string SessionToken
        {
            get { return _SessionToken; }
        }

        /// <summary>
        /// Gets the database connector type enumeration.
        /// </summary>
        public ConnectorEnum ConnectorType
        {
            get { return _ConnectorType; }
        }

        /// <summary>
        /// Gets list of allowed project roles for user.
        /// </summary>
        public List<iCampaign.TACS.IRole> Roles
        {
            get { return _Roles; }
        }

        /// <summary>
        /// Gets the registered application code.
        /// </summary>
        public string ApplicationCode
        {
            get { return _ApplicationCode; }
        }

        /// <summary>
        /// Gets the current application GUID string.
        /// </summary>
        public string ApplicationGUID
        {
            get { return _ApplicationGUID; }
        }

        /// <summary>
        /// Gets the account owner attribute.
        /// </summary>
        public bool AccountOwner
        {
            get { return _AccountOwner; }
        }

        /// <summary>
        /// Gets the super administrator attribute.
        /// </summary>
        public bool SuperAdministrator
        {
            get { return _SuperAdministrator; }
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Check to see if credentials have expired.
        /// </summary>
        /// <returns>boolean</returns>
        public bool CheckExpirey()
        {
            if (this.ExpireyDate < DateTime.Now)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Get the access level for the specified project role for this user.
        /// If no role is found AccessLevelEnum.NoAccess is returned.
        /// </summary>
        /// <param name="role">string: Role name.</param>
        /// <returns>AccessLevelEnum: enumeration.</returns>
        public AccessLevelEnum CheckRoleAccess(string role)
        {
            AccessLevelEnum access = AccessLevelEnum.NoAccess;
            foreach (Role roleItem in this.Roles)
            {
                if (roleItem.Name == role)
                    access = roleItem.AccessLevel;
            }
            return access;
        }

        /// <summary>
        /// Verify that user has the minimum access required for specified role.
        /// </summary>
        /// <param name="role">string: Role name.</param>
        /// <param name="minAccess">iCampaign.TACS.AccessLevelEnum: minimum access level.</param>
        /// <returns>bool</returns>
        public bool HasAccess(string role, AccessLevelEnum minAccess)
        {
            bool returnStatus = false;
            foreach (Role roleItem in this.Roles)
            {
                if (roleItem.Name == role)
                {
                    if (Convert.ToInt32(roleItem.AccessLevel) >= Convert.ToInt32(minAccess))
                        returnStatus = true;
                }
            }
            return returnStatus;
        }
        #endregion

        #region Internal methods
        /// <summary>
        /// Returns an ODBC connection string for connecting to a data source
        /// based on user credentials.
        /// </summary>
        /// <returns>string</returns>
        internal string SetConnectionString()
        {
            string connStr = String.Empty;

            switch (this.ConnectorType)
            {
                case ConnectorEnum.MYSQL:
                    break;
                case ConnectorEnum.SQL_SERVER:
                    //  Build a connection string for MS SQL Server
                    SqlConnectionStringBuilder connBuilder = new SqlConnectionStringBuilder();
                    connBuilder.ApplicationName = this.AccountName;
                    connBuilder.ConnectTimeout = 120;
                    connBuilder.DataSource = this.DataSource;
                    connBuilder.InitialCatalog = this.Database;
                    connBuilder.IntegratedSecurity = false;
                    connBuilder.Password = this.SqlPassword;
                    connBuilder.Pooling = true;
                    connBuilder.UserID = this.SqlUser;
                    connStr = connBuilder.ToString();
                    break;
            }
            return connStr.ToString();
        }
        #endregion
    }
}
