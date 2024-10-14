using MANAGEMENT_DASHBOARD_SERVER.Repositories;
using MANAGEMENT_DASHBOARD_SERVER.Repositories.FireApp_Regional_Class_Summary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MANAGEMENT_DASHBOARD_SERVER.Controllers.FireApp_Regional_Class_Summary
{
    public class GenNonMotorClassRM_Controller : ApiController
    {
        private readonly GenNonMotorClassRM_Repository _repository;

        public GenNonMotorClassRM_Controller()
        {
            // Initialize the repository with the connection string to Oracle database
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;
            _repository = new GenNonMotorClassRM_Repository(connectionString);
        }

        [HttpGet]
        [Route("api/GetGenNonMotorClassRM")]
        public IHttpActionResult GetGenNonMotorClassRM([FromUri] string year, string month, string region)
        {
            try
            {
                // Call the repository method to get the data
                var data = _repository.CallStoredProcedure(year, month, region);

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