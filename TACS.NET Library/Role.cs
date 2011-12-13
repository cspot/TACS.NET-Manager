//	iCampaign.TACS.Role
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

namespace iCampaign.TACS
{
    /// <summary>
    /// Represents a security role object used in a generic collection.
    /// </summary>
    public class Role : iCampaign.TACS.IRole
    {
        #region Fields
        /// <summary>
        /// Name property.
        /// </summary>
        private string _Name;
        /// <summary>
        /// AccessLevel property.
        /// </summary>
        private AccessLevelEnum _AccessLevel;
        #endregion

        #region Constructors
        /// <summary>
        /// Initialize default instance of role object.
        /// </summary>
        public Role()
        {
            _Name = String.Empty;
            _AccessLevel = AccessLevelEnum.NoAccess;
        }

        /// <summary>
        /// Initialize instance of object with role name and access level.
        /// </summary>
        /// <param name="name">string: Role name.</param>
        /// <param name="level">iCampaign.TACS.AccessLevelEnum: enumeration.</param>
        public Role(string name, AccessLevelEnum level)
        {
            _Name = name;
            _AccessLevel = level;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the role name.
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        /// <summary>
        /// Gets or sets the access level enumeration.
        /// </summary>
        public AccessLevelEnum AccessLevel
        {
            get { return _AccessLevel; }
            set { _AccessLevel = value; }
        }
        #endregion
    }
}
