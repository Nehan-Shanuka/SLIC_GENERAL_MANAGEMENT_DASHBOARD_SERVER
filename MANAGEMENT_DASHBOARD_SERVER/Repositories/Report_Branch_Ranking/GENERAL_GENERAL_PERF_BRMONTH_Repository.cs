using Dapper;
using Dapper.Oracle;
using MANAGEMENT_DASHBOARD_SERVER.Models.Performance_Ranking_Region_Branch;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MANAGEMENT_DASHBOARD_SERVER.Repositories
{
    public class GENERAL_GENERAL_PERF_BRMONTH_Repository
    {
        private readonly string _connectionString;

        public GENERAL_GENERAL_PERF_BRMONTH_Repository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<GeneralBranchPerformanceRank> CallStoredProcedure(int month)
        {
            using (var conn = new OracleConnection(_connectionString))
            {
                var parameters = new OracleDynamicParameters();
                parameters.Add("p_recordset", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
                parameters.Add("p_month", month, OracleMappingType.Int32, ParameterDirection.Input);

                var result = conn.Query<GeneralBranchPerformanceRank>(
                    "SLIC_AGENT.GENERAL_GENERAL_PERF_BRMONTH",
                    parameters,
                    commandType: CommandType.StoredProcedure).ToList();

                return result;
            }
        }
    }
}