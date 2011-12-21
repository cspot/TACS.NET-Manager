//	iCampaign.TACS.Client.AccessException
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
using System.Globalization;
using System.Runtime.Serialization;
using System.Security;
using System.Text;

namespace iCampaign.TACS.Client
{
    /// <summary>
    /// Represents the exception that is thrown when an error occurs in the access client.
    /// </summary>
    [Serializable()]
    public class AccessException : Exception
    {
        #region Fields
        /// <summary>
        /// Message property.
        /// </summary>
        private string _Message;
        /// <summary>
        /// Project property.
        /// </summary>
        private string _Project;
        /// <summary>
        /// Username property.
        /// </summary>
        private string _Username;
        /// <summary>
        /// RawData property.
        /// </summary>
        private string _RawData;
        #endregion

        #region Constructors
        /// <summary>
        /// Overloaded. Initialize instance of AccessException class.
        /// </summary>
        public AccessException() 
            : this(null, null)
        {
        }

        /// <summary>
        /// Overloaded. Initialize instance of AccessException class.
        /// </summary>
        /// <param name="message"></param>
        public AccessException(string message)
            : this(message, null)
        {
        }

        /// <summary>
        /// Overloaded. Initialize instance of AccessException class.
        /// </summary>
        /// <param name="message">string: The message that describes the error.</param>
        /// <param name="innerException">Exception: Actual exception that occurred.</param>
        public AccessException(string message, Exception innerException)
        {
            _Message = (message == null ? string.Empty : message);
            _RawData = String.Empty;
            _Project = String.Empty;
            _Username = String.Empty;
        }

        /// <summary>
        /// Overloaded. Initialize instance of AccessException class.
        /// </summary>
        /// <param name="rawdata">string: Raw data.</param>
        /// <param name="project">string: Project name.</param>
        /// <param name="username">string: Username.</param>
        /// <param name="innerException">Exception: Actual exception that occurred.</param>
        public AccessException(string rawdata, string project, string username, Exception innerException)
            : base(String.Empty, innerException)
        {
            _RawData = (rawdata == null ? string.Empty : rawdata);
            _Project = project;
            _Username = username;
            _Message = String.Format(CultureInfo.InvariantCulture, ExceptionMessage.AccessServerException, _Project, _Username, _RawData);
        }

        /// <summary>
		/// Initializes a new instance of the MalformedCsvException class with serialized data.
		/// </summary>
		/// <param name="info">The <see cref="T:SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
		/// <param name="context">The <see cref="T:StreamingContext"/> that contains contextual information about the source or destination.</param>
		protected AccessException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			_Message = info.GetString("MyMessage");

			_RawData = info.GetString("RawData");
            _Project = info.GetString("Project");
            _Username = info.GetString("Username");
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the exception message string.
        /// </summary>
        public string MyMessage
        {
            get { return _Message; }
        }

        /// <summary>
        /// Gets the project name string.
        /// </summary>
        public string Project
        {
            get { return _Project; }
        }

        /// <summary>
        /// Gets the username string.
        /// </summary>
        public string Username
        {
            get { return _Username; }
        }

        /// <summary>
        /// Gets the raw data string.
        /// </summary>
        public string RawData
        {
            get { return _RawData; }
        }
        #endregion
    }
}
