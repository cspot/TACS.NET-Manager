//	iCampaign.TACS.IUserProfile
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

namespace iCampaign.TACS
{
    /// <summary>
    /// Declares an interface describing an implementation of a user profile class.
    /// </summary>
    public interface IUserProfile
    {
        /// <summary>
        /// Account expiration date.
        /// </summary>
        DateTime AccountExpirey { get; set; }
        /// <summary>
        /// Unique account id.
        /// </summary>
        long AccountId { get; set; }
        /// <summary>
        /// Account name.
        /// </summary>
        string AccountName { get; set; }
        /// <summary>
        /// Account owner flag.
        /// </summary>
        bool AccountOwner { get; set; }
        /// <summary>
        /// Application code string.
        /// </summary>
        string ApplicationCode { get; set; }
        /// <summary>
        /// GUID of supported application build.
        /// </summary>
        string ApplicationGUID { get; set; }
        /// <summary>
        /// Enumeration of database connector type.
        /// </summary>
        ConnectorEnum ConnectorType { get; set; }
        /// <summary>
        /// User creation timestamp.
        /// </summary>
        DateTime CreatedOn { get; set; }
        /// <summary>
        /// Database name.
        /// </summary>
        string Database { get; set; }
        /// <summary>
        /// Database server name.
        /// </summary>
        string DataSource { get; set; }
        /// <summary>
        /// User disabled flag.
        /// </summary>
        bool Disable { get; set; }
        /// <summary>
        /// URL for downloading latest software update.
        /// </summary>
        string DownloadURL { get; set; }
        /// <summary>
        /// User email address.
        /// </summary>
        string Email { get; set; }
        /// <summary>
        /// Error message string.
        /// </summary>
        string ErrorMessage { get; set; }
        /// <summary>
        /// User's full name.
        /// </summary>
        string FullName { get; set; }
        /// <summary>
        /// User password.
        /// </summary>
        string Password { get; set; }
        /// <summary>
        /// Database project name.
        /// </summary>
        string Project { get; set; }
        /// <summary>
        /// Collection of roles.
        /// </summary>
        System.Collections.Generic.List<IRole> Roles { get; set; }
        /// <summary>
        /// Session token string.
        /// </summary>
        string SessionToken { get; set; }
        /// <summary>
        /// Database password.
        /// </summary>
        string SqlPassword { get; set; }
        /// <summary>
        /// Database username.
        /// </summary>
        string SqlUser { get; set; }
        /// <summary>
        /// Super administrator flag.
        /// </summary>
        bool SuperAdministrator { get; set; }
        /// <summary>
        /// User expiration date.
        /// </summary>
        DateTime UserExpirey { get; set; }
        /// <summary>
        /// Username.
        /// </summary>
        string Username { get; set; }
    }
}
