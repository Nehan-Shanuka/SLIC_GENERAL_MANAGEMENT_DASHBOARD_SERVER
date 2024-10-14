using MANAGEMENT_DASHBOARD_SERVER.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MANAGEMENT_DASHBOARD_SERVER.Controllers
{
    public class GENERAL_GENERAL_PERF_BRMONTH_Controller: ApiController
    {
        private readonly GENERAL_GENERAL_PERF_BRMONTH_Repository _repository;

        public GENERAL_GENERAL_PERF_BRMONTH_Controller()
        {
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;
            _repository = new GENERAL_GENERAL_PERF_BRMONTH_Repository(connectionString);
        }

        [HttpGet]
        [Route("api/GENERAL_GENERAL_PERF_BRMONTH")]
        public IHttpActionResult GetMotorPerformanceData([FromUri] int month)
        {
            try
            {
                var performanceData = _repository.CallStoredProcedure(month);
                return Ok(performanceData);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}