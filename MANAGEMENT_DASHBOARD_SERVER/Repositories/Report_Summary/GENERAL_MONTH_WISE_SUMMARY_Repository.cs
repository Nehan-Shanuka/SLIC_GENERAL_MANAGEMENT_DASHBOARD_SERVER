using Dapper;
using Dapper.Oracle;
using MANAGEMENT_DASHBOARD_SERVER.Models.Report_Summary;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MANAGEMENT_DASHBOARD_SERVER.Repositories.Report_Summary
{
    public class GENERAL_MONTH_WISE_SUMMARY_Repository
    {
        private readonly string _connectionString;

        public GENERAL_MONTH_WISE_SUMMARY_Repository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<BasicKpi> CallStoredProcedure(int year)
        {
            using (var conn = new OracleConnection(_connectionString))
            {
                // Define the input and output parameters
                var parameters = new OracleDynamicParameters();
                parameters.Add("p_recordset", dbType: (OracleMappingType?)OracleDbType.RefCursor, direction: ParameterDirection.Output);
                parameters.Add("p_year", year, (OracleMappingType?)OracleDbType.Int64, ParameterDirection.Input);

                // Execute the stored procedure and map the result to the respective model
                var result = conn.Query<BasicKpi>(
                    "SLIC_AGENT.GENERAL_MONTH_WISE_SUMMARY",
                    parameters,
                    commandType: CommandType.StoredProcedure).ToList();

                return result;
            }
        }
    }
}