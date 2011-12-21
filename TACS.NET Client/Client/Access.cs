//	iCampaign.TACS.Client.Access
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

namespace iCampaign.TACS.Client
{
    /// <summary>
    /// Provides the client interface to the TACS.NET access control services.
    /// </summary>
    public class Access : IClient
    {
        #region Fields
        /// <summary>
        /// CurrentCredentials property.
        /// </summary>
        private Credentials _CurrentCredentials;
        /// <summary>
        /// ApplicationToken property.
        /// </summary>
        private string _ApplicationToken;
        #endregion

        #region Constructors
        /// <summary>
        /// Overloaded. Initialize instance of access object.
        /// </summary>
        /// <param name="token">string: Application token.</param>
        public Access(string token)
        {
            if (token.Length == 0)
                throw new System.ArgumentException("The application token [token] cannot be empty.");

            //  Set the properties
            _ApplicationToken = token;
        }

        /// <summary>
        /// Overloaded. Initialize instance of access object.
        /// </summary>
        /// <param name="credentials">CredentialsBase: Active credentials object.</param>
        /// <param name="token">string: Application token.</param>
        public Access(Credentials credentials, string token)
        {
             if (token.Length == 0)
                throw new System.ArgumentException("The application token [token] cannot be empty.");

            //  Set the properties
            _CurrentCredentials = credentials;
            _ApplicationToken = token;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the TACS.NET credentials object.
        /// </summary>
        public Credentials CurrentCredentials
        {
            get
            {
                return _CurrentCredentials;
            }
        }

        /// <summary>
        /// Gets the application token that references the TACS.NET application.
        /// </summary>
        public string ApplicationToken
        {
            get
            {
                return _ApplicationToken;
            }
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Returns the TACS.NET credentials based on the user's login information.
        /// </summary>
        /// <param name="project">string: Project name.</param>
        /// <param name="user">string: Username.</param>
        /// <param name="plainpass">string: Plain text password.</param>
        /// <returns>iCampaign.TACS.Client.Credentials: object.</returns>
        public Credentials Login(string project, string user, string plainpass)
        {
            //  Initialize CurrentCredentials property
            _CurrentCredentials = null;

            // Encrypt the password
            string hashedPass = "";
            if (plainpass.Length != 0)
                hashedPass = Security.CreateHash(plainpass);

            //  Use SOAP proxy to TACS.NET AccessService
            AccessServiceProxy.AccessService accessService = new 
                iCampaign.TACS.AccessServiceProxy.AccessService();
            //  Consume the web service and process authentication request
            try
            {
                _CurrentCredentials = accessService.Login(project, user, hashedPass, this.ApplicationToken);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return this.CurrentCredentials;
        }

        /// <summary>
        /// Add a new user profile to a TACS.NET account.
        /// </summary>
        /// <param name="user">string: Unique user name.</param>
        /// <param name="pass">string: Plaintext password.</param>
        /// <param name="name">string: Full name.</param>
        /// <param name="email">string: Email address.</param>
        /// <param name="expirey">DateTime: Expiration date.</param>
        /// <param name="owner">bool: Account owner flag.</param>
        /// <param name="superAdmin">bool: Super administrator flag.</param>
        /// <param name="role">string: Caller role being used.</param>
        /// <param name="credentials">iCampaign.TACS.Client.Credentials: Object.</param>
        public void AddUserProfile(string user, string pass, string name, string email, DateTime expirey,
            bool owner, bool superAdmin, string role, Credentials credentials)
        {
            string result = String.Empty;

            //  Use SOAP proxy to TACS.NET AccessService
            AccessServiceProxy.AccessService accessService =
                new iCampaign.TACS.AccessServiceProxy.AccessService();

            //  Try to add the user profile
            try
            {
                result = accessService.AddUser(user, Security.CreateHash(pass), name, email,
                    expirey, owner, superAdmin, role, credentials);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //  Check result code, if not success then throw exception with message
            //  from service.
            if (result != "OK")
                throw new System.Exception(result);
        }

        /// <summary>
        /// Get requested TACS.NET user profile from server.
        /// </summary>
        /// <param name="user">string: Username of profile.</param>
        /// <param name="role">string: Caller role being used.</param>
        /// <param name="credentials">iCampaign.TACS.Client.Credentials: object.</param>
        /// <returns>iCampaign.TACS.UserProfile</returns>
        public iCampaign.TACS.UserProfile GetUserProfile(string user, string role,
            iCampaign.TACS.Client.Credentials credentials)
        {
            //  Instantiate objects we will need
            UserProfile profile = null;
            AccessServiceProxy.AccessService accessService =
                new iCampaign.TACS.AccessServiceProxy.AccessService();

            //  Call the service and request user profile
            try
            {
                profile = accessService.GetUserProfile(user, role, credentials);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //  Check message for status
            if (profile.ErrorMessage != "OK")
            {
                throw new System.Exception(profile.ErrorMessage);
            }
            return profile;
        }

        /// <summary>
        /// Reset user password in TACS.NET database.
        /// </summary>
        /// <param name="credentials">iCampaign.TACS.Client.Credentials: object.</param>
        /// <param name="plainpass">string: Plain text password.</param>
        public void ResetPassword(Credentials credentials, string plainpass)
        {
            AccessServiceProxy.AccessService accessService =
                new iCampaign.TACS.AccessServiceProxy.AccessService();
            try
            {
                accessService.ResetPassword(credentials, Security.CreateHash(plainpass));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete the specified user profile from the TACS.NET database.
        /// </summary>
        /// <param name="user">string: Username.</param>
        /// <param name="role">string: Caller role being used.</param>
        /// <param name="credentials">iCampaign.TACS.Client.Credentials: object.</param>
        public void DeleteUserProfile(string user, string role, Credentials credentials)
        {
            string result = String.Empty;
            AccessServiceProxy.AccessService accessService =
                new iCampaign.TACS.AccessServiceProxy.AccessService();
            try
            {
                result = accessService.DeleteUser(user, role, credentials);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //  Check the result message
            if (result != "OK")
                throw new System.Exception(result);
        }
        /// <summary>
        /// Get list of user profiles for the account id specified in credentials.
        /// </summary>
        /// <param name="credential">iCampaign.TACS.Client.Credentials: object.</param>
        /// <returns>System.Collection.Generic.List T:iCampaign.TACS.UserProfile</returns>
        public List<UserProfile> GetUserProfiles(Credentials credential)
        {
            List<UserProfile> userProfiles = null;
            AccessServiceProxy.AccessService accessService =
                new iCampaign.TACS.AccessServiceProxy.AccessService();

            //  Call the service and request list of user profiles
            try
            {
                userProfiles = accessService.GetUserProfiles(credential);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return userProfiles;
        }

        /// <summary>
        /// Update the specified user profile in the TACS.NET database.
        /// </summary>
        /// <param name="profile">iCampaign.TACS.Profile: object.</param>
        /// <param name="role">string: Caller role being used.</param>
        /// <param name="credentials">iCampaign.TACS.Client.Credentials: object.</param>
        public void UpdateUserProfile(UserProfile profile, string role, Credentials credentials)
        {
            string result = String.Empty;
            AccessServiceProxy.AccessService accessService =
                new iCampaign.TACS.AccessServiceProxy.AccessService();
            try
            {
                result = accessService.UpdateUser(profile, role, credentials);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //  Check the result message
            if (result != "OK")
                throw new System.Exception(result);
        }
        #endregion
    }
}
