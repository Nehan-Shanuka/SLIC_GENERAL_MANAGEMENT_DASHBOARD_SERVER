using Dapper;
using Dapper.Oracle;
using MANAGEMENT_DASHBOARD_SERVER.Models.FireApp_Regional_Class_Summary;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MANAGEMENT_DASHBOARD_SERVER.Repositories.FireApp_Regional_Class_Summary
{
    public class GenNonMotorClassBranchWiseRM_Repository
    {
        private readonly string _connectionString;

        public GenNonMotorClassBranchWiseRM_Repository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<NonMotorClassRMData> CallStoredProcedure(string p_year, string p_month, string p_region)
        {
            using (var conn = new OracleConnection(_connectionString))
            {
                // Define the input and output parameters
                var parameters = new OracleDynamicParameters();
                parameters.Add("p_recordset", dbType: (OracleMappingType?)OracleDbType.RefCursor, direction: ParameterDirection.Output);
                parameters.Add("p_year", p_year, (OracleMappingType?)OracleDbType.Varchar2, ParameterDirection.Input);
                parameters.Add("p_month", p_month, (OracleMappingType?)OracleDbType.Varchar2, ParameterDirection.Input);
                parameters.Add("p_region", p_region, (OracleMappingType?)OracleDbType.Varchar2, ParameterDirection.Input);

                // Execute the stored procedure and map the result to the respective model
                var result = conn.Query<NonMotorClassRMData>(
                    "SLIC_RMBM.NMOTOR_BREAKDOWN_RM_BRANCH",
                    parameters,
                    commandType: CommandType.StoredProcedure).ToList();

                return result;
            }
        }
    }
}