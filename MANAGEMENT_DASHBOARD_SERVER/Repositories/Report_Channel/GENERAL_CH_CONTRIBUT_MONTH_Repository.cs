﻿using Dapper;
using Dapper.Oracle;
using MANAGEMENT_DASHBOARD_SERVER.Models.Report_Channel;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MANAGEMENT_DASHBOARD_SERVER.Repositories.Report_Channel
{
    public class GENERAL_CH_CONTRIBUT_MONTH_Repository
    {
        private readonly string _connectionString;

        public GENERAL_CH_CONTRIBUT_MONTH_Repository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<ChPerformance> CallStoredProcedure(int month)
        {
            using (var conn = new OracleConnection(_connectionString))
            {
                // Define the input and output parameters
                var parameters = new OracleDynamicParameters();
                parameters.Add("p_recordset", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
                parameters.Add("p_month", month, OracleMappingType.Int32, ParameterDirection.Input);

                // Execute the stored procedure and map the result to the respective model
                var result = conn.Query<ChPerformance>(
                    "SLIC_AGENT.GENERAL_CH_CONTRIBUT_MONTH",
                    parameters,
                    commandType: CommandType.StoredProcedure).ToList();

                return result;
            }
        }
    }
}