//	iCampaign.TACS.ProjectProfile
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
    /// Represents the data structure of a TACS.NET project profile.
    /// </summary>
    [Serializable]
    public class ProjectProfile : iCampaign.TACS.IProjectProfile
    {
        #region Fields
        /// <summary>
        /// Project property.
        /// </summary>
        private string _Project = String.Empty;
        /// <summary>
        /// ConnectorType property.
        /// </summary>
        private ConnectorEnum _ConnectorType = ConnectorEnum.SQL_SERVER;
        /// <summary>
        /// DataSource property.
        /// </summary>
        private string _DataSource = String.Empty;
        /// <summary>
        /// Database property.
        /// </summary>
        private string _Database = String.Empty;
        /// <summary>
        /// Username property.
        /// </summary>
        private string _Username = String.Empty;
        /// <summary>
        /// Password property.
        /// </summary>
        private string _Password = String.Empty;
        /// <summary>
        /// CreatedOn property.
        /// </summary>
        private DateTime _CreatedOn = System.DateTime.Now;
        /// <summary>
        /// ApplicationCode property.
        /// </summary>
        private string _ApplicationCode = String.Empty;
        /// <summary>
        /// AccountId property.
        /// </summary>
        private long _AccountId = -1;
        /// <summary>
        /// ErrorMessage property.
        /// </summary>
        private string _ErrorMessage = String.Empty;
        #endregion

        #region Constructor
        /// <summary>
        /// Initialize an instance of project profile object.
        /// </summary>
        public ProjectProfile()
        {

        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the project name.
        /// </summary>
        public string Project
        {
            get { return _Project; }
            set { _Project = value; }
        }

        /// <summary>
        /// Gets or sets the database connector type.
        /// </summary>
        public ConnectorEnum ConnectorType
        {
            get { return _ConnectorType; }
            set { _ConnectorType = value; }
        }

        /// <summary>
        /// Gets or sets the database server name.
        /// </summary>
        public string DataSource
        {
            get { return _DataSource; }
            set { _DataSource = value; }
        }

        /// <summary>
        /// Gets or sets the database.
        /// </summary>
        public string Database
        {
            get { return _Database; }
            set { _Database = value; }
        }

        /// <summary>
        /// Gets or sets the database username.
        /// </summary>
        public string Username
        {
            get { return _Username; }
            set { _Username = value; }
        }

        /// <summary>
        /// Gets or sets the database password.
        /// </summary>
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        /// <summary>
        /// Gets or sets the project creation date.
        /// </summary>
        public DateTime CreatedOn
        {
            get { return _CreatedOn; }
            set { _CreatedOn = value; }
        }

        /// <summary>
        /// Gets or sets the application code for project.
        /// </summary>
        public string ApplicationCode
        {
            get { return _ApplicationCode; }
            set { _ApplicationCode = value; }
        }

        /// <summary>
        /// Gets or sets the account id.
        /// </summary>
        public long AccountId
        {
            get { return _AccountId; }
            set { _AccountId = value; }
        }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        public string ErrorMessage
        {
            get { return _ErrorMessage; }
            set { _ErrorMessage = value; }
        }
        #endregion
    }
}
