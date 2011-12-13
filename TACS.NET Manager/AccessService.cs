using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

using iCampaign.TACS;
using iCampaign.TACS.Data;

namespace TACS.NET_Manager
{
    internal class AccessService
    {
        /// <summary>
        /// Retrieves a data table filled with users under the specified account id.
        /// </summary>
        /// <param name="acctId">long: Account id.</param>
        /// <returns>iCampaign.TACS.Data.UserDs.UsersDataTable</returns>
        internal iCampaign.TACS.Data.UserDs.UsersDataTable GetUsers(long acctId)
        {
            //  Instantiate the data objects
            iCampaign.TACS.Data.UserDs.UsersDataTable dataTable = new UserDs.UsersDataTable();
            iCampaign.TACS.Data.UserDsTableAdapters.UsersTableAdapter tableAdapter =
                new iCampaign.TACS.Data.UserDsTableAdapters.UsersTableAdapter();
            tableAdapter.Connection = new SqlConnection(TacsSession.ConnectionString);

            //  Try to get the records from the database
            try
            {
                tableAdapter.Connection.Open();
                tableAdapter.FillByAcctId(dataTable, acctId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                tableAdapter.Connection.Close();
            }

            return dataTable;
        }
    }
}
