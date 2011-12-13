//	iCampaign.TACS.AccessLevelEnum
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
    /// An enumeration of the allowed access levels provided.
    /// </summary>
    public enum AccessLevelEnum : int
    {
        /// <summary>
        /// No access to the data object.
        /// </summary>
        NoAccess,
        /// <summary>
        /// Read-only access to the data object.
        /// </summary>
        DataReader,
        /// <summary>
        /// Read-Write access to the data object.
        /// </summary>
        DataWriter,
        /// <summary>
        /// Full access to the data object.
        /// </summary>
        Owner,
        /// <summary>
        /// Full administrative access to all data objects.
        /// </summary>
        Administrator,
    }
}
