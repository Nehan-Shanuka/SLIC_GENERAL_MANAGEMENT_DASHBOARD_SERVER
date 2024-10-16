using MANAGEMENT_DASHBOARD_SERVER.Models;
using MANAGEMENT_DASHBOARD_SERVER.Models.FireApp_Homepage_Data;
using MANAGEMENT_DASHBOARD_SERVER.Repositories;
using MANAGEMENT_DASHBOARD_SERVER.Repositories.FireApp_Homepage_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MANAGEMENT_DASHBOARD_SERVER.Controllers.FireApp_Homepage_Data
{
    public class GetGeneralHomeRM_Controller : ApiController
    {
        private readonly GetGeneralHomeRM_Repository _repository;

        public GetGeneralHomeRM_Controller()
        {
            // Initialize the repository with the connection string to Oracle database
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;
            _repository = new GetGeneralHomeRM_Repository(connectionString);
        }

        [HttpGet]
        [Route("api/GetGeneralHomeRM")]
        public IHttpActionResult GetMotorPerformanceData([FromUri] string year, string month, string region, string category)
        {
            try
            {
                GeneralHomeDataRM data = new GeneralHomeDataRM();
                // Call the repository method to get the data
                data.regionalSummaryList = _repository.CallStoredProcedureMotorRegionalSummary(year, month, region);
                data.regionalKpiList = _repository.CallStoredProcedureGetKpiMonthRMData(month, region);
                data.regionalAmpList = _repository.CallStoredProcedureGetAmpRMData(region, category);
                data.regionalNewRecList = _repository.CallStoredProcedureGeneralNewRecruitmentRM(month, region);
                data.achievementCumulative = _repository.CallStoredProcedureGeneralTarAchRMData(region);

                // Return the data as a JSON response
                return Ok(data);
            }
            catch (Exception ex)
            {
                // Log the error (implement logging as needed) and return a 500 Internal Server Error response
                return InternalServerError(ex);
            }
        }
    }
}