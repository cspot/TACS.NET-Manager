//	iCampaign.TACS.IProfileProfile
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
    /// Declares the interface describing an implementation of a project profile.
    /// </summary>
    public interface IProjectProfile
    {
        /// <summary>
        /// Unique account id.
        /// </summary>
        long AccountId { get; set; }
        /// <summary>
        /// Application code string.
        /// </summary>
        string ApplicationCode { get; set; }
        /// <summary>
        /// Enumeration of database connector type.
        /// </summary>
        ConnectorEnum ConnectorType { get; set; }
        /// <summary>
        /// Timestamp of project creation.
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
        /// Error message string.
        /// </summary>
        string ErrorMessage { get; set; }
        /// <summary>
        /// Database password.
        /// </summary>
        string Password { get; set; }
        /// <summary>
        /// Project name.
        /// </summary>
        string Project { get; set; }
        /// <summary>
        /// Database username.
        /// </summary>
        string Username { get; set; }
    }
}
