using MANAGEMENT_DASHBOARD_SERVER.Repositories.FireApp_Regional_Due_Summary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MANAGEMENT_DASHBOARD_SERVER.Controllers.FireApp_Regional_Due_Summary
{
    public class GeneralBranchDueForRegionalSummary_Controller : ApiController
    {
        private readonly GeneralBranchDueForRegionalSummary_Repository _repository;

        public GeneralBranchDueForRegionalSummary_Controller()
        {
            // Initialize the connection string to Oracle database
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;
            _repository = new GeneralBranchDueForRegionalSummary_Repository(connectionString);
        }

        [HttpGet]
        [Route("api/GetGeneralBranchDueForRegionalSummary")]
        public IHttpActionResult GetGeneralBranchDueForRegionalSummary([FromUri] string p_year, string p_month, string p_region)
        {
            try
            {
                // Call the repository method to get the data
                var data = _repository.CallStoredProcedure(p_year, p_month, p_region);

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