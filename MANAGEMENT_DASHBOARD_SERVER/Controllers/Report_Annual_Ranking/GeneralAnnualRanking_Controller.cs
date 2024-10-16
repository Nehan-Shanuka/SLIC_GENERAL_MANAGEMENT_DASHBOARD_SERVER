using MANAGEMENT_DASHBOARD_SERVER.Models.Report_Annual_Ranking;
using MANAGEMENT_DASHBOARD_SERVER.Repositories;
using MANAGEMENT_DASHBOARD_SERVER.Repositories.Report_Annual_Ranking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MANAGEMENT_DASHBOARD_SERVER.Controllers.Report_Annual_Ranking
{
    public class GeneralAnnualRanking_Controller : ApiController
    {
        private readonly GeneralAnnualRanking_Repository _repository;

        public GeneralAnnualRanking_Controller()
        {
            // Initialize the repository with the connection string to Oracle database
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;
            _repository = new GeneralAnnualRanking_Repository(connectionString);
        }

        [HttpGet]
        [Route("api/GetGeneralAnnualRanking")]
        public IHttpActionResult GetMotorPerformanceData()
        {
            try
            {
                GeneralAnnualAward data = new GeneralAnnualAward();
                // Call the repository method to get the data
                data.rmList = _repository.CallStoredProcedureRMRankingData();
                data.bmList = _repository.CallStoredProcedureBMRankingData();

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