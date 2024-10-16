using Dapper;
using MANAGEMENT_DASHBOARD_SERVER.Models.FireApp_RM_Detail;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;

namespace MANAGEMENT_DASHBOARD_SERVER.Repositories.FireApp_RM_Detail
{
    public class GetGeneralListRMBM_Repository
    {
        private readonly string _connectionString;

        public GetGeneralListRMBM_Repository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<GeneralRmBmDetailsData> CallStoredProcedure(string type)
        {
            using (var conn = new OracleConnection(_connectionString))
            {
                // Query to retrieve data from the table
                string query = @"SELECT ROW_ID, BRANCH_CODE, BRANCH_NAME, REGION, EPF, STATUS, NAME, MOBILE, TYP 
                             FROM SLIC_AGENT.MGT_DASHBOARD_RMBM WHERE TYP = :TYP";

                // Use Dapper to execute the query and map the result to the BranchDetails model
                IEnumerable<GeneralRmBmDetailsData> result = conn.Query<GeneralRmBmDetailsData>(query, new { TYP = type });

                foreach (GeneralRmBmDetailsData manager in result)
                {
                    manager.FULL_NAME = manager.STATUS + manager.NAME;
                }

                return result;
            }
        }
    }
}