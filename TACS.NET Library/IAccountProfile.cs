//	iCampaign.TACS.IAccountProfile
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
    /// Declares the interface that describes an implementation of a account profile class.
    /// </summary>
    public interface IAccountProfile
    {
        /// <summary>
        /// Account name.
        /// </summary>
        string Account { get; set; }
        /// <summary>
        /// Unique account id.
        /// </summary>
        long AccountId { get; set; }
        /// <summary>
        /// Postal address line 1.
        /// </summary>
        string Address1 { get; set; }
        /// <summary>
        /// Postal address line 2.
        /// </summary>
        string Address2 { get; set; }
        /// <summary>
        /// Postal address city.
        /// </summary>
        string City { get; set; }
        /// <summary>
        /// Contact name.
        /// </summary>
        string Contact { get; set; }
        /// <summary>
        /// Account creation date.
        /// </summary>
        DateTime CreatedOn { get; set; }
        /// <summary>
        /// Contact email address.
        /// </summary>
        string Email { get; set; }
        /// <summary>
        /// Account expiration date.
        /// </summary>
        DateTime ExpireOn { get; set; }
        /// <summary>
        /// Contact phone number.
        /// </summary>
        string Phone { get; set; }
        /// <summary>
        /// Postal address state abbreviation.
        /// </summary>
        string State { get; set; }
        /// <summary>
        /// Postal address zip code.
        /// </summary>
        string ZipCode { get; set; }
    }
}
