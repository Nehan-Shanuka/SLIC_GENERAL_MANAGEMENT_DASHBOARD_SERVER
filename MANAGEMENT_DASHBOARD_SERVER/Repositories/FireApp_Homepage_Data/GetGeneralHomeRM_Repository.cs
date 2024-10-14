using Dapper;
using Dapper.Oracle;
using MANAGEMENT_DASHBOARD_SERVER.Models.FireApp_Homepage_Data;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MANAGEMENT_DASHBOARD_SERVER.Repositories.FireApp_Homepage_Data
{
    public class GetGeneralHomeRM_Repository
    {
        private readonly string _connectionString;

        public GetGeneralHomeRM_Repository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<GeneralRegionalSummary> CallStoredProcedureMotorRegionalSummary(string year, string month, string region)
        {
            using (var conn = new OracleConnection(_connectionString))
            {
                // Define the input and output parameters
                var parameters = new OracleDynamicParameters();
                parameters.Add("p_recordset", dbType: (OracleMappingType?)OracleDbType.RefCursor, direction: ParameterDirection.Output);
                parameters.Add("p_year", year, (OracleMappingType?)OracleDbType.Varchar2, ParameterDirection.Input);
                parameters.Add("p_month", month, (OracleMappingType?)OracleDbType.Varchar2, ParameterDirection.Input);
                parameters.Add("p_region", region, (OracleMappingType?)OracleDbType.Varchar2, ParameterDirection.Input);

                // Execute the stored procedure and map the result to the respective model
                var result = conn.Query<GeneralRegionalSummary>(
                    "SLIC_RMBM.MOTOR_REGIONAL_SUMMARY",
                    parameters,
                    commandType: CommandType.StoredProcedure).ToList();

                return result;
            }
        }

        public List<GeneralKPI> CallStoredProcedureGetKpiMonthRMData(string p_month, string p_region)
        {
            using (var conn = new OracleConnection(_connectionString))
            {
                // Define the input and output parameters
                var parameters = new OracleDynamicParameters();
                parameters.Add("p_recordset", dbType: (OracleMappingType?)OracleDbType.RefCursor, direction: ParameterDirection.Output);
                parameters.Add("p_month", p_month, (OracleMappingType?)OracleDbType.Varchar2, ParameterDirection.Input);
                parameters.Add("p_region", p_region, (OracleMappingType?)OracleDbType.Varchar2, ParameterDirection.Input);

                // Execute the stored procedure and map the result to the respective model
                var result = conn.Query<GeneralKPI>(
                    "SLIC_RMBM.KPI_MONTH_RM",
                    parameters,
                    commandType: CommandType.StoredProcedure).ToList();

                return result;
            }
        }

        public List<GeneralAmpDataRM> CallStoredProcedureGetAmpRMData(string p_region, string p_category)
        {
            using (var conn = new OracleConnection(_connectionString))
            {
                // Define the input and output parameters
                var parameters = new OracleDynamicParameters();
                parameters.Add("p_recordset", dbType: (OracleMappingType?)OracleDbType.RefCursor, direction: ParameterDirection.Output);
                parameters.Add("p_region", p_region, (OracleMappingType?)OracleDbType.Varchar2, ParameterDirection.Input);
                parameters.Add("p_category", p_category, (OracleMappingType?)OracleDbType.Varchar2, ParameterDirection.Input);

                // Execute the stored procedure and map the result to the respective model
                var result = conn.Query<GeneralAmpDataRM>(
                    "SLIC_RMBM.ACTIVE_MANPOWER_RM",
                    parameters,
                    commandType: CommandType.StoredProcedure).ToList();

                return result;
            }
        }

        public List<GeneralNewRecruitmentRM> CallStoredProcedureGeneralNewRecruitmentRM(string p_month, string p_region)
        {
            using (var conn = new OracleConnection(_connectionString))
            {
                // Define the input and output parameters
                var parameters = new OracleDynamicParameters();
                parameters.Add("p_recordset", dbType: (OracleMappingType?)OracleDbType.RefCursor, direction: ParameterDirection.Output);
                parameters.Add("p_month", p_month, (OracleMappingType?)OracleDbType.Varchar2, ParameterDirection.Input);
                parameters.Add("p_region", p_region, (OracleMappingType?)OracleDbType.Varchar2, ParameterDirection.Input);

                // Execute the stored procedure and map the result to the respective model
                var result = conn.Query<GeneralNewRecruitmentRM>(
                    "SLIC_RMBM.NEW_RECRUITMENT_RM",
                    parameters,
                    commandType: CommandType.StoredProcedure).ToList();

                return result;
            }
        }

        public GenTarAchChartCumuData CallStoredProcedureGeneralTarAchRMData(string p_region)
        {
            using (var conn = new OracleConnection(_connectionString))
            {
                // Define the input and output parameters
                var parameters = new OracleDynamicParameters();
                parameters.Add("p_recordset", dbType: (OracleMappingType?)OracleDbType.RefCursor, direction: ParameterDirection.Output);
                parameters.Add("p_region", p_region, (OracleMappingType?)OracleDbType.Varchar2, ParameterDirection.Input);

                // Execute the stored procedure and map the result to the respective model
                var result = conn.Query<GenTarAchChartCumuData>(
                    "SLIC_RMBM.GENERAL_ACH_CUMULATIVE_RM",
                    parameters,
                    commandType: CommandType.StoredProcedure).FirstOrDefault();

                return result;
            }
        }
    }
}