using Dapper;
using Dapper.Oracle;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MANAGEMENT_DASHBOARD_SERVER.Repositories
{
    public class GENERAL_GENERAL_PERF_BRMONTH_Repository
    {
        private readonly string _connectionString;

        public GENERAL_GENERAL_PERF_BRMONTH_Repository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<BRANCH_TEMPLATE_FOR_BRANCH_RANK> CallStoredProcedure(int month)
        {
            using (var conn = new OracleConnection(_connectionString))
            {
                var parameters = new OracleDynamicParameters();
                parameters.Add("p_recordset", dbType: (OracleMappingType?)OracleDbType.RefCursor, direction: ParameterDirection.Output);
                parameters.Add("p_month", month, (OracleMappingType?)OracleDbType.Int32, ParameterDirection.Input);

                var result = conn.Query<BRANCH_TEMPLATE_FOR_BRANCH_RANK>(
                    "SLIC_AGENT.GENERAL_GENERAL_PERF_BRMONTH",
                    parameters,
                    commandType: CommandType.StoredProcedure).ToList();

                return result;
            }
        }
    }
}