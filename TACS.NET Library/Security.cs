//	iCampaign.TACS.Security
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
using System.Security.Cryptography;
using System.Text;

namespace iCampaign.TACS
{
    /// <summary>
    /// Provides security encryption services for TACS.NET applications.
    /// </summary>
    public static class Security
    {
        /// <summary>
        /// Create a MD5 hash from a string.
        /// </summary>
        /// <param name="strValue">string: To be hashed.</param>
        /// <returns>string</returns>
        public static string CreateHash(string strValue)
        {
            byte[] byteSource;
            byte[] byteHashed;

            byteSource = ASCIIEncoding.ASCII.GetBytes(strValue);
            byteHashed = new MD5CryptoServiceProvider().ComputeHash(byteSource);
            StringBuilder strOutput = new StringBuilder(byteHashed.Length);
            for (int i = 0; i < byteHashed.Length; i++)
                strOutput.Append(byteHashed[i].ToString("X2"));
            return strOutput.ToString();
        }

        /// <summary>
        /// Compares a string to a hash for equality.
        /// </summary>
        /// <param name="strValue">string: String to use for comparison.</param>
        /// <param name="hashValue">string: Hash to be compared with.</param>
        /// <returns>bool</returns>
        public static bool CompareHash(string strValue, string hashValue)
        {
            string hashedInString = CreateHash(strValue);
            if (hashedInString == hashValue)
                return true;
            else
                return false;
        }
    }
}
