using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Dapper.Oracle;
using MANAGEMENT_DASHBOARD_SERVER.Models.Performance_Ranking_Region_Branch;
using Oracle.ManagedDataAccess.Client;

public class GENERAL_MOTOR_PERF_BRCMLTV_Repository
{
    private readonly string _connectionString;

    public GENERAL_MOTOR_PERF_BRCMLTV_Repository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<GeneralBranchPerformanceRank> CallStoredProcedure(int month)
    {
        using (var conn = new OracleConnection(_connectionString))
        {
            // Define the input and output parameters
            var parameters = new OracleDynamicParameters();
            parameters.Add("p_recordset", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
            parameters.Add("p_month", month, OracleMappingType.Int32, ParameterDirection.Input);

            // Execute the stored procedure and map the result to the MotorPerformanceData model
            var result = conn.Query<GeneralBranchPerformanceRank>(
                "SLIC_AGENT.GENERAL_MOTOR_PERF_BRCMLTV",
                parameters,
                commandType: CommandType.StoredProcedure).ToList();

            return result;
        }
    }
}
