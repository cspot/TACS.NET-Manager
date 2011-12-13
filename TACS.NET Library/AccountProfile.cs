//	iCampaign.TACS.AccountProfile
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
    /// Represents a TACS.NET customer account profile.
    /// </summary>
    public class AccountProfile : iCampaign.TACS.IAccountProfile
    {
        /// <summary>
        /// AccountId property.
        /// </summary>
        private long _AccountId;
        /// <summary>
        /// Account property.
        /// </summary>
        private string _Account;
        /// <summary>
        /// Contact property.
        /// </summary>
        private string _Contact;
        /// <summary>
        /// Address1 property.
        /// </summary>
        private string _Address1;
        /// <summary>
        /// Address2 property.
        /// </summary>
        private string _Address2;
        /// <summary>
        /// City property.
        /// </summary>
        private string _City;
        /// <summary>
        /// State property.
        /// </summary>
        private string _State;
        /// <summary>
        /// ZipCode property.
        /// </summary>
        private string _ZipCode;
        /// <summary>
        /// Email property.
        /// </summary>
        private string _Email;
        /// <summary>
        /// Phone property.
        /// </summary>
        private string _Phone;
        /// <summary>
        /// CreatedOn property.
        /// </summary>
        private DateTime _CreatedOn;
        /// <summary>
        /// ExpireOn property.
        /// </summary>
        private DateTime _ExpireOn;

        /// <summary>
        /// Gets or sets the account id value.
        /// </summary>
        public long AccountId
        {
            get { return _AccountId; }
            set { _AccountId = value; }
        }

        /// <summary>
        /// Gets or sets the account name.
        /// </summary>
        public string Account
        {
            get { return _Account; }
            set { _Account = value; }
        }

        /// <summary>
        /// Gets or sets the account contact name.
        /// </summary>
        public string Contact
        {
            get { return _Contact; }
            set { _Contact = value; }
        }

        /// <summary>
        /// Gets or sets address line 1.
        /// </summary>
        public string Address1
        {
            get { return _Address1; }
            set { _Address1 = value; }
        }

        /// <summary>
        /// Gets or sets address line 2.
        /// </summary>
        public string Address2
        {
            get { return _Address2; }
            set { _Address2 = value; }
        }

        /// <summary>
        /// Gets or sets the postal address city.
        /// </summary>
        public string City
        {
            get { return _City; }
            set { _City = value; }
        }

        /// <summary>
        /// Gets or sets the postal address state.
        /// </summary>
        public string State
        {
            get { return _State; }
            set { _State = value; }
        }

        /// <summary>
        /// Gets or sets the postal address zip code.
        /// </summary>
        public string ZipCode
        {
            get { return _ZipCode; }
            set { _ZipCode = value; }
        }

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }

        /// <summary>
        /// Gets or sets the date the account was created.
        /// </summary>
        public DateTime CreatedOn
        {
            get { return _CreatedOn; }
            set { _CreatedOn = value; }
        }

        /// <summary>
        /// Gets or sets the date the account will expire.
        /// </summary>
        public DateTime ExpireOn
        {
            get { return _ExpireOn; }
            set { _ExpireOn = value; }
        }
    }
}
