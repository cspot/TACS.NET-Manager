//	iCampaign.TACS.ICredentials
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

namespace iCampaign.TACS.Client
{
    /// <summary>
    /// Declares interface describing an implementation of an access credential class.
    /// </summary>
    public interface ICredentials
    {
        /// <summary>
        /// Enumeration of access level.
        /// </summary>
        iCampaign.TACS.AccessLevelEnum AccessLevel { get; }
        /// <summary>
        /// Unique account id.
        /// </summary>
        long AccountId { get; }
        /// <summary>
        /// Account name.
        /// </summary>
        string AccountName { get; }
        /// <summary>
        /// Account owner flag.
        /// </summary>
        bool AccountOwner { get; }
        /// <summary>
        /// Application code string.
        /// </summary>
        string ApplicationCode { get; }
        /// <summary>
        /// Released application GUID.
        /// </summary>
        string ApplicationGUID { get; }
        /// <summary>
        /// ODBC connection string.
        /// </summary>
        string ConnectionString { get; }
        /// <summary>
        /// Enumerator of database connector types.
        /// </summary>
        iCampaign.TACS.ConnectorEnum ConnectorType { get; }
        /// <summary>
        /// Database name.
        /// </summary>
        string Database { get; }
        /// <summary>
        /// Database server.
        /// </summary>
        string DataSource { get; }
        /// <summary>
        /// Profile disabled flag.
        /// </summary>
        bool Disabled { get; }
        /// <summary>
        /// Application update URL.
        /// </summary>
        string DownloadUrl { get; }
        /// <summary>
        /// User's email address.
        /// </summary>
        string Email { get; }
        /// <summary>
        /// Error message.
        /// </summary>
        string ErrorMessage { get; }
        /// <summary>
        /// Profile expiration timestamp.
        /// </summary>
        DateTime ExpireyDate { get; }
        /// <summary>
        /// User's full name.
        /// </summary>
        string FullName { get; }
        /// <summary>
        /// Database project name.
        /// </summary>
        string Project { get; }
        /// <summary>
        /// Collection of permitted roles.
        /// </summary>
        System.Collections.Generic.List<iCampaign.TACS.IRole> Roles { get; }
        /// <summary>
        /// Session token string.
        /// </summary>
        string SessionToken { get; }
        /// <summary>
        /// Database password.
        /// </summary>
        string SqlPassword { get; }
        /// <summary>
        /// Database username.
        /// </summary>
        string SqlUser { get; }
        /// <summary>
        /// Profile super admin flag.
        /// </summary>
        bool SuperAdministrator { get; }
        /// <summary>
        /// Profile username.
        /// </summary>
        string Username { get; }

        /// <summary>
        /// Check to see if user has expired.
        /// </summary>
        /// <returns>bool</returns>
        bool CheckExpirey();
        /// <summary>
        /// Check role for permitted access level.
        /// </summary>
        /// <param name="role">string: Role name.</param>
        /// <returns>iCampaign.TACS.AccessLevelEnum</returns>
        iCampaign.TACS.AccessLevelEnum CheckRoleAccess(string role);
        /// <summary>
        /// Determine if the role is allowed the requested access level.
        /// </summary>
        /// <param name="role">string: Role name.</param>
        /// <param name="minAccess">iCampaign.TACS.AccessLevelEnum: Requested access.</param>
        /// <returns>bool</returns>
        bool HasAccess(string role, iCampaign.TACS.AccessLevelEnum minAccess);

    }
}
