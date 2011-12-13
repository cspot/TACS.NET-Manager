//	iCampaign.TACS.UserProfile
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
using System.Collections.Generic;
using System.Text;

namespace iCampaign.TACS
{
    /// <summary>
    /// Represents TACS.NET user profile data structure.
    /// </summary>
    [Serializable]
    public class UserProfile : iCampaign.TACS.IUserProfile
    {
        #region Fields
        /// <summary>
        /// Username property.
        /// </summary>
        private string _Username;
        /// <summary>
        /// Password property.
        /// </summary>
        private string _Password;
        /// <summary>
        /// FullName property.
        /// </summary>
        private string _FullName;
        /// <summary>
        /// Email property.
        /// </summary>
        private string _Email;
        /// <summary>
        /// CreatedOn property.
        /// </summary>
        private DateTime _CreatedOn;
        /// <summary>
        /// UserExpirey property.
        /// </summary>
        private DateTime _ExpireyDate;
        /// <summary>
        /// Disable property.
        /// </summary>
        private bool _Disable;
        /// <summary>
        /// ErrorMessage property.
        /// </summary>
        private string _ErrorMessage;
        /// <summary>
        /// AccountId property.
        /// </summary>
        private long _AccountId;
        /// <summary>
        /// AccountName property.
        /// </summary>
        private string _AccountName;
        /// <summary>
        /// AccountExpirey property.
        /// </summary>
        private DateTime _AccountExpirey;
        /// <summary>
        /// Project property.
        /// </summary>
        private string _Project;
        /// <summary>
        /// ConnectorType property.
        /// </summary>
        private ConnectorEnum _ConnectorType;
        /// <summary>
        /// DataSource property.
        /// </summary>
        private string _DataSource;
        /// <summary>
        /// Database property.
        /// </summary>
        private string _Database;
        /// <summary>
        /// SqlUser property.
        /// </summary>
        private string _SqlUser;
        /// <summary>
        /// SqlPassword property.
        /// </summary>
        private string _SqlPassword;
        /// <summary>
        /// SessionToken property.
        /// </summary>
        private string _SessionToken;
        /// <summary>
        /// Roles property.
        /// </summary>
        private List<iCampaign.TACS.IRole> _Roles = new List<IRole>();
        /// <summary>
        /// ApplicationCode property.
        /// </summary>
        private string _ApplicationCode;
        /// <summary>
        /// DownloadURL property.
        /// </summary>
        private string _DownloadURL;
        /// <summary>
        /// ApplicationGUID property.
        /// </summary>
        private string _ApplicationGUID;
        /// <summary>
        /// AccountOwner property.
        /// </summary>
        private bool _AccountOwner;
        /// <summary>
        /// SuperAdministrator property.
        /// </summary>
        private bool _SuperAdministrator;
        #endregion

        #region Constructor
        /// <summary>
        /// Initialize instance of UserProfile object.
        /// </summary>
        public UserProfile()
        {
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        public string Username
        {
            get
            {
                return _Username;
            }
            set
            {
                _Username = value;
            }
        }

        /// <summary>
        /// Gets or sets the encrypted password.
        /// </summary>
        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
            }
        }

        /// <summary>
        /// Gets or sets the user's full name.
        /// </summary>
        public string FullName
        {
            get
            {
                return _FullName;
            }
            set
            {
                _FullName = value;
            }
        }

        /// <summary>
        /// Gets or sets the user's email address.
        /// </summary>
        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
            }
        }

        /// <summary>
        /// Gets or sets the profile creation date.
        /// </summary>
        public DateTime CreatedOn
        {
            get
            {
                return _CreatedOn;
            }
            set
            {
                _CreatedOn = value;
            }
        }

        /// <summary>
        /// Gets or sets the profile expiration date.
        /// </summary>
        public DateTime UserExpirey
        {
            get
            {
                return _ExpireyDate;
            }
            set
            {
                _ExpireyDate = value;
            }
        }

        /// <summary>
        /// Gets or sets the profile disabled flag.
        /// </summary>
        public bool Disable
        {
            get
            {
                return _Disable;
            }
            set
            {
                _Disable = value;
            }
        }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        public string ErrorMessage
        {
            get
            {
                return _ErrorMessage;
            }
            set
            {
                _ErrorMessage = value;
            }
        }

        /// <summary>
        /// Ges or sets the account id value.
        /// </summary>
        public long AccountId
        {
            get
            {
                return _AccountId;
            }
            set
            {
                _AccountId = value;
            }
        }

        /// <summary>
        /// Gets or sets the account name.
        /// </summary>
        public string AccountName
        {
            get
            {
                return _AccountName;
            }
            set
            {
                _AccountName = value;
            }
        }

        /// <summary>
        /// Gets or sets the account expiration date value.
        /// </summary>
        public DateTime AccountExpirey
        {
            get
            {
                return _AccountExpirey;
            }
            set
            {
                _AccountExpirey = value;
            }
        }

        /// <summary>
        /// Gets or sets the project name.
        /// </summary>
        public string Project
        {
            get
            {
                return _Project;
            }
            set
            {
                _Project = value;
            }
        }

        /// <summary>
        /// Gets or sets the database connector type.
        /// </summary>
        public ConnectorEnum ConnectorType
        {
            get
            {
                return _ConnectorType;
            }
            set
            {
                _ConnectorType = value;
            }
        }

        /// <summary>
        /// Gets or sets the database server name.
        /// </summary>
        public string DataSource
        {
            get
            {
                return _DataSource;
            }
            set
            {
                _DataSource = value;
            }
        }

        /// <summary>
        /// Gets or sets the database name.
        /// </summary>
        public string Database
        {
            get
            {
                return _Database;
            }
            set
            {
                _Database = value;
            }
        }

        /// <summary>
        /// Gets or sets the SQL database username.
        /// </summary>
        public string SqlUser
        {
            get
            {
                return _SqlUser;
            }
            set
            {
                _SqlUser = value;
            }
        }

        /// <summary>
        /// Gets or sets the SQL database password.
        /// </summary>
        public string SqlPassword
        {
            get
            {
                return _SqlPassword;
            }
            set
            {
                _SqlPassword = value;
            }
        }

        /// <summary>
        /// Gets or sets the session token string.
        /// </summary>
        public string SessionToken
        {
            get
            {
                return _SessionToken;
            }
            set
            {
                _SessionToken = value;
            }
        }

        /// <summary>
        /// Gets or sets the generic collection of roles.
        /// </summary>
        public List<iCampaign.TACS.IRole> Roles
        {
            get
            {
                return _Roles;
            }
            set
            {
                _Roles = value;
            }
        }

        /// <summary>
        /// Gets or sets the application code string.
        /// </summary>
        public string ApplicationCode
        {
            get
            {
                return _ApplicationCode;
            }
            set
            {
                _ApplicationCode = value;
            }
        }

        /// <summary>
        /// Gets or sets the application download URL.
        /// </summary>
        public string DownloadURL
        {
            get
            {
                return _DownloadURL;
            }
            set
            {
                _DownloadURL = value;
            }
        }

        /// <summary>
        /// Gets or sets the current application GUID string.
        /// </summary>
        public string ApplicationGUID
        {
            get
            {
                return _ApplicationGUID;
            }
            set
            {
                _ApplicationGUID = value;
            }
        }

        /// <summary>
        /// Gets or sets the account owner attribute.
        /// </summary>
        public bool AccountOwner
        {
            get
            {
                return _AccountOwner;
            }
            set
            {
                _AccountOwner = value;
            }
        }

        /// <summary>
        /// Gets or sets the super administrator attribute.
        /// </summary>
        public bool SuperAdministrator
        {
            get
            {
                return _SuperAdministrator;
            }
            set
            {
                _SuperAdministrator = value;
            }
        }
        #endregion
    }
}
