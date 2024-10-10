using MANAGEMENT_DASHBOARD_SERVER.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MANAGEMENT_DASHBOARD_SERVER.Controllers
{
    public class GENERAL_NMOTOR_PERF_BRMONTH_Controller: ApiController
    {
        private readonly GENERAL_NMOTOR_PERF_BRMONTH_Repository _repository;

        public GENERAL_NMOTOR_PERF_BRMONTH_Controller()
        {
            // Initialize the repository with a connection string to your Oracle database
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;
            _repository = new GENERAL_NMOTOR_PERF_BRMONTH_Repository(connectionString);
        }

        [HttpGet]
        [Route("api/GENERAL_NMOTOR_PERF_BRMONTH")]
        public IHttpActionResult GetMotorPerformanceData([FromUri] int month)
        {
            try
            {
                // Call the repository method to get the motor performance data
                var performanceData = _repository.CallStoredProcedure(month);

                // Return the data as a JSON response
                return Ok(performanceData);
            }
            catch (Exception ex)
            {
                // Log the error (implement logging as needed) and return a 500 Internal Server Error response
                return InternalServerError(ex);
            }
        }
    }
}