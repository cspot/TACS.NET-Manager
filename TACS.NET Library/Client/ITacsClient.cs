//	iCampaign.TACS.ITacsClient
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

namespace iCampaign.TACS.Client
{
    /// <summary>
    /// Declares interface describing an implementation of a TACS client class.
    /// </summary>
    public interface ITacsClient
    {
        /// <summary>
        /// Gets the TACS.NET application token string.
        /// </summary>
        string TacsAppToken
        {
            get;
        }

        /// <summary>
        /// Gets the TACS.NET Credentials object.
        /// </summary>
        iCampaign.TACS.Client.Credentials Credentials
        {
            get;
        }
    }
}
