using Dapper;
using Dapper.Oracle;
using MANAGEMENT_DASHBOARD_SERVER.Models.Report_Non_Motor_Summary;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MANAGEMENT_DASHBOARD_SERVER.Repositories.Report_Non_Motor_Summary
{
    public class GENERAL_NMOTOR_MONTH_SUMMARY_N_Repository
    {
        private readonly string _connectionString;

        public GENERAL_NMOTOR_MONTH_SUMMARY_N_Repository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<NonMotorSummary> CallStoredProcedure(int month)
        {
            using (var conn = new OracleConnection(_connectionString))
            {
                // Define the input and output parameters
                var parameters = new OracleDynamicParameters();
                parameters.Add("p_recordset", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
                parameters.Add("p_month", month, OracleMappingType.Int32, ParameterDirection.Input);

                // Execute the stored procedure and map the result to the respective model
                var result = conn.Query<NonMotorSummary>(
                    "SLIC_AGENT.GENERAL_NMOTOR_MONTH_SUMMARY_N",
                    parameters,
                    commandType: CommandType.StoredProcedure).ToList();

                return result;
            }
        }
    }
}