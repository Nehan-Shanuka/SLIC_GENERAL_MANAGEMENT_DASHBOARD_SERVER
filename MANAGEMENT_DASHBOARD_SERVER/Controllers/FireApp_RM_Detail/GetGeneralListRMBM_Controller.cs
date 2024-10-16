using MANAGEMENT_DASHBOARD_SERVER.Repositories;
using MANAGEMENT_DASHBOARD_SERVER.Repositories.FireApp_RM_Detail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MANAGEMENT_DASHBOARD_SERVER.Controllers.FireApp_RM_Detail
{
    public class GetGeneralListRMBM_Controller : ApiController
    {
        private readonly GetGeneralListRMBM_Repository _repository;

        public GetGeneralListRMBM_Controller()
        {
            // Initialize the repository with the connection string to Oracle database
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;
            _repository = new GetGeneralListRMBM_Repository(connectionString);
        }

        [HttpGet]
        [Route("api/GetGeneralListRMBM")]
        public IHttpActionResult GetMotorPerformanceData([FromUri] string type)
        {
            try
            {
                // Call the repository method to get the data
                var data = _repository.CallStoredProcedure(type);

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