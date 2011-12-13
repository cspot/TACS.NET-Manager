//	iCampaign.TACS.IAccessService
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
using System.Linq;
using System.Text;
using iCampaign.TACS.Client;

namespace iCampaign.TACS
{
    /// <summary>
    /// Describes interface used to implement the access service proxy.
    /// </summary>
    public interface IAccessService
    {
        /// <summary>
        /// Provides login authentication for iCampaign application returning the user
        /// access credentials.
        /// </summary>
        /// <param name="project">string: Project name.</param>
        /// <param name="user">string: User name.</param>
        /// <param name="encpass">string: Encrypted password.</param>
        /// <param name="appcode">string: Application code.</param>
        /// <returns>iCampaign.TACS.Client.Credentials: object.</returns>
        Credentials Login(string project, string user, string encpass, string appcode);

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
        string AddUser(string user, string pass, string name, string email, DateTime expirey,
            bool owner, bool superAdmin, string role, Credentials credentials);

        /// <summary>
        /// Delete the specified user id from the TACS.NET user table.
        /// </summary>
        /// <param name="user">string: Username to delete.</param>
        /// <param name="role">string: Caller role being used.</param>
        /// <param name="credentials">iCampaign.TACS.Client.Credentials: object.</param>
        /// <returns>string: Status code.</returns>
        string DeleteUser(string user, string role, Credentials credentials);

        /// <summary>
        /// Returns the requested user profile from the TACS.NET user table.
        /// </summary>
        /// <param name="user">string: Username.</param>
        /// <param name="role">string: Caller role being used.</param>
        /// <param name="credentials">iCampaign.TACS.Client.Credentials: object.</param>
        /// <returns>iCampaign.TACS.UserProfile</returns>
        UserProfile GetUserProfile(string user, string role, Credentials credentials);

        /// <summary>
        /// Updates the provided user profile in the TACS.NET user table.
        /// </summary>
        /// <param name="profile">iCampaign.TACS.UserProfile: object.</param>
        /// <param name="role">string: Caller role being used.</param>
        /// <param name="credentials">iCampaign.TACS.Client.Credentials: object.</param>
        /// <returns>Status code</returns>
        string UpdateUser(UserProfile profile, string role, Credentials credentials);

        /// <summary>
        /// Publishes list of user profiles for account id specified in Credentials.
        /// </summary>
        /// <param name="credentials">iCampaign.TACS.Client.Credentials: object.</param>
        /// <returns>System.Collections.Generic.List T:iCampaign.TACS.UserProfile</returns>
        List<UserProfile> GetUserProfiles(Credentials credentials);

        /// <summary>
        /// Reset the password of the specified user in the TACS.NET database.
        /// </summary>
        /// <param name="credentials">iCampaign.TACS.Client.Credentials: object.</param>
        /// <param name="encpass">string: Encrypted password.</param>
        void ResetPassword(Credentials credentials, string encpass);

        /// <summary>
        /// Returns a list of roles assigned to specified user profile for all projects.
        /// </summary>
        List<Role> GetUserRoles();
    }
}
