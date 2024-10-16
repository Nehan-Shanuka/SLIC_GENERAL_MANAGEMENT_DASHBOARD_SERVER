using MANAGEMENT_DASHBOARD_SERVER.Repositories;
using MANAGEMENT_DASHBOARD_SERVER.Repositories.Report_Summary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MANAGEMENT_DASHBOARD_SERVER.Controllers.Report_Summary
{
    public class GENERAL_CUMULATIVE_PL_SUMMARY_Controller : ApiController
    {
        private readonly GENERAL_CUMULATIVE_PL_SUMMARY_Repository _repository;

        public GENERAL_CUMULATIVE_PL_SUMMARY_Controller()
        {
            // Initialize the repository with the connection string to Oracle database
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;
            _repository = new GENERAL_CUMULATIVE_PL_SUMMARY_Repository(connectionString);
        }

        [HttpGet]
        [Route("api/Get_GENERAL_CUMULATIVE_PL_SUMMARY")]
        public IHttpActionResult GetGenCumulativePLSummary([FromUri] int month)
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