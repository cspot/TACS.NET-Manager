//	iCampaign.TACS.Client.Projects
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
    /// Provides the client interface to the TACS.NET project service.
    /// </summary>
    public class Project : IClient
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
        public Project(string token)
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
        public Project(Credentials credentials, string token)
        {
            if (token.Length == 0)
                throw new System.ArgumentException("The application token [token] cannot be empty.");

            //  Set the properties
            _CurrentCredentials = credentials;
            _ApplicationToken = token;
        }
        #endregion

        #region IClient Members
        /// <summary>
        /// Gets the application token string.
        /// </summary>
        public string ApplicationToken
        {
            get { return _ApplicationToken; }
        }

        /// <summary>
        /// Gets the access credentials object.
        /// </summary>
        public Credentials CurrentCredentials
        {
            get { return _CurrentCredentials; }
        }
        #endregion

        /// <summary>
        /// Get the specified project profile from the TACS.NET database. (Requires
        /// CurrentCredentials property to be set.)
        /// </summary>
        /// <param name="project">string: Project name.</param>
        /// <param name="role">string: Caller role being used.</param>
        /// <returns>iCampaign.TACS.ProjectProfile: object.</returns>
        public ProjectProfile GetProjectProfile(string project, string role)
        {
            return this.GetProjectProfile(project, role, this.CurrentCredentials);
        }

        /// <summary>
        /// Get the specified project profile from the TACS.NET database.
        /// </summary>
        /// <param name="project">string: Project name.</param>
        /// <param name="role">string: Caller role being used.</param>
        /// <param name="credentials">iCampaign.TACS.Client.Credentials: object.</param>
        /// <returns>iCampaign.TACS.ProjectProfile: object.</returns>
        public ProjectProfile GetProjectProfile(string project, string role,
            Credentials credentials)
        {
            ProjectProfile result = null;
            ProjectServiceProxy.ProjectService projectService =
                new iCampaign.TACS.ProjectServiceProxy.ProjectService();
            try
            {
                result = projectService.GetProject(project, role, credentials);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// Add new project to the TACS.NET database.
        /// </summary>
        /// <param name="project"></param>
        /// <param name="credentials"></param>
        public void AddProjectProfile(ProjectProfile project, Credentials credentials)
        {
            string result = String.Empty;
            ProjectServiceProxy.ProjectService projectService =
                new iCampaign.TACS.ProjectServiceProxy.ProjectService();
            try
            {
                result = projectService.AddProject(project, credentials);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (result != "OK")
            {
                throw new System.SystemException(result);
            }
        }

        /// <summary>
        /// Assign a project role to the specified user profile.
        /// </summary>
        /// <param name="username">string: Username.</param>
        /// <param name="roleId">long: Role id to assign.</param>
        /// <param name="role">string: Caller role being used.</param>
        /// <param name="credentials">iCampaign.TACS.Client.Credentials: object.</param>
        public void AssignUserRole(string username, long roleId, string role, Credentials credentials)
        {
            string result = String.Empty;
            ProjectServiceProxy.ProjectService projectService =
                new iCampaign.TACS.ProjectServiceProxy.ProjectService();
            try
            {
                result = projectService.AddUserRole(username, roleId, role, credentials);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (result != "OK")
            {
                throw new System.SystemException(result);
            }
        }

        /// <summary>
        /// Add new project role to the TACS.NET database.
        /// </summary>
        /// <param name="newRole">iCampaign.TACS.Role: object.</param>
        /// <param name="role">string: Caller role being used.</param>
        /// <param name="credentials">iCampaign.TACS.Client.Credentials: object.</param>
        public void AddProjectRole(Role newRole, string role, Credentials credentials)
        {
            string result = String.Empty;
            ProjectServiceProxy.ProjectService projectService =
                new iCampaign.TACS.ProjectServiceProxy.ProjectService();
            try
            {
                result = projectService.AddRole(newRole, role, credentials);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (result != "OK")
            {
                throw new System.SystemException(result);
            }
        }

        /// <summary>
        /// Get list of projects for specified account id.
        /// </summary>
        /// <param name="account">long: Account id.</param>
        /// <returns>System.Collections.Generic.List T:string</returns>
        public List<string> GetProjects(long account)
        {
            List<string> resultList = new List<string>();
            ProjectServiceProxy.ProjectService projectService =
                new iCampaign.TACS.ProjectServiceProxy.ProjectService();
            try
            {
                resultList = projectService.GetProjectsByAcct(account);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultList;
        }

        /// <summary>
        /// Get list of projects for specified application token.
        /// </summary>
        /// <param name="appcode">string: Application token.</param>
        /// <returns>System.Collections.Generic.List T:string</returns>
        public List<string> GetProjects(string appcode)
        {
            List<string> resultList = new List<string>();
            ProjectServiceProxy.ProjectService projectService =
                new iCampaign.TACS.ProjectServiceProxy.ProjectService();
            try
            {
                resultList = projectService.GetProjectsByApp(appcode);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultList;
        }

        /// <summary>
        /// Get list of registered accounts from TACS.NET database.
        /// (Super Administrator only.)
        /// </summary>
        /// <param name="credentials">iCampaign.TACS.Client.Credentials: object.</param>
        /// <returns>System.Collections.Generic.List T:string</returns>
        public List<string> GetAccounts(Credentials credentials)
        {
            List<string> resultList = null;
            ProjectServiceProxy.ProjectService projectService =
                new iCampaign.TACS.ProjectServiceProxy.ProjectService();
            try
            {
                resultList = projectService.GetAccounts(credentials);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resultList;
        }

        /// <summary>
        /// Get list of account profiles registered in the TACS.NET database.  
        /// (Super Administrator only.)
        /// </summary>
        /// <param name="credentials">iCampaign.TACS.Client.Credentials: object.</param>
        /// <returns>System.Collections.Generic.List T:iCampaign.TACS.AccountProfile</returns>
        public List<AccountProfile> GetAccountProfiles(Credentials credentials)
        {
            List<AccountProfile> profileList = null;
            ProjectServiceProxy.ProjectService projectService =
                new iCampaign.TACS.ProjectServiceProxy.ProjectService();
            try
            {
                profileList = projectService.GetAccountProfiles(credentials);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return profileList;
        }

        /// <summary>
        /// Get the specified account profile from the TACS.NET database.  
        /// (Super Administrator only.)
        /// </summary>
        /// <param name="acctId">long: Account id.</param>
        /// <param name="credentials">iCampaign.TACS.Client.Credentials: object.</param>
        /// <returns>iCampaign.TACS.AccountProfile</returns>
        public AccountProfile GetAccountProfile(long acctId, Credentials credentials)
        {
            AccountProfile profile = null;
            ProjectServiceProxy.ProjectService projectService =
                new iCampaign.TACS.ProjectServiceProxy.ProjectService();
            try
            {
                profile = projectService.GetAccountProfile(acctId, credentials);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return profile;
        }

        /// <summary>
        /// Get a list of projects owned by the specified account.
        /// </summary>
        /// <param name="acctId">long: Account id.</param>
        /// <param name="credentials">iCampaign.TACS.Client.Credentials: object.</param>
        /// <returns>System.Collections.Generic.List T:string</returns>
        public List<string> GetProjectsByAccount(long acctId, Credentials credentials)
        {
            List<string> projectList = new List<string>();
            ProjectServiceProxy.ProjectService projectService =
                new iCampaign.TACS.ProjectServiceProxy.ProjectService();
            try
            {
                projectList = projectService.GetProjectsByAcct(acctId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return projectList;
        }
    }
}
