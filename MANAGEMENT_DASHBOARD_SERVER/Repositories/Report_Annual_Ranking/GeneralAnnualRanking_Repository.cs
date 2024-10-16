using Dapper;
using Dapper.Oracle;
using MANAGEMENT_DASHBOARD_SERVER.Models.Report_Annual_Ranking;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MANAGEMENT_DASHBOARD_SERVER.Repositories.Report_Annual_Ranking
{
    public class GeneralAnnualRanking_Repository
    {
        private readonly string _connectionString;

        public GeneralAnnualRanking_Repository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<GeneralAnnualAwardRankingRMData> CallStoredProcedureRMRankingData()
        {
            using (var conn = new OracleConnection(_connectionString))
            {
                // Define the input and output parameters
                var parameters = new OracleDynamicParameters();
                parameters.Add("p_recordset", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

                // Execute the stored procedure and map the result to the respective model
                var result = conn.Query<GeneralAnnualAwardRankingRMData>(
                    "SLIC_RMBM.ANNUAL_AWARD_RM",
                    parameters,
                    commandType: CommandType.StoredProcedure).ToList();

                return result;
            }
        }

        public List<GeneralAnnualAwardRankingBMData> CallStoredProcedureBMRankingData()
        {
            using (var conn = new OracleConnection(_connectionString))
            {
                // Define the input and output parameters
                var parameters = new OracleDynamicParameters();
                parameters.Add("p_recordset", dbType: (OracleMappingType?)OracleDbType.RefCursor, direction: ParameterDirection.Output);

                // Execute the stored procedure and map the result to the respective model
                var result = conn.Query<GeneralAnnualAwardRankingBMData>(
                    "SLIC_RMBM.ANNUAL_AWARD_BM",
                    parameters,
                    commandType: CommandType.StoredProcedure).ToList();

                return result;
            }
        }
    }
}