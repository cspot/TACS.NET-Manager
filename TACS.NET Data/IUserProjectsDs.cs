//	iCampaign.TACS.Data.IUserProjectsDs
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
namespace iCampaign.TACS.Data
{
    /// <summary>
    /// Describes the interface used to implement the user projects dataset.
    /// </summary>
    public interface IUserProjectsDs
    {
        System.Data.DataSet Clone();
        System.Data.DataRelationCollection Relations { get; }
        System.Data.SchemaSerializationMode SchemaSerializationMode { get; set; }
        System.Data.DataTableCollection Tables { get; }
        UserProjectsDs.UserProjectsDataTable UserProjects { get; }
    }
}
