using MANAGEMENT_DASHBOARD_SERVER.Repositories;
using MANAGEMENT_DASHBOARD_SERVER.Repositories.Dashboard_Homepage_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MANAGEMENT_DASHBOARD_SERVER.Controllers.Dashboard_Homepage_Data
{
    public class GENERAL_TOTAL_MONTH_Controller : ApiController
    {
        private readonly GENERAL_TOTAL_MONTH_Repository _repository;

        public GENERAL_TOTAL_MONTH_Controller()
        {
            // Initialize the repository with the connection string to Oracle database
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;
            _repository = new GENERAL_TOTAL_MONTH_Repository(connectionString);
        }

        [HttpGet]
        [Route("api/GENERAL_TOTAL_MONTH")]
        public IHttpActionResult GetMotorPerformanceData([FromUri] int month)
        {
            try
            {
                // Call the repository method to get the data
                var data = _repository.CallStoredProcedure(month);

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