using MANAGEMENT_DASHBOARD_SERVER.Repositories.Report_Branch_Ranking_Region_Wise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace MANAGEMENT_DASHBOARD_SERVER.Controllers.Report_Branch_Ranking_Region_Wise
{
    public class GENERAL_NMOTOR_PERF_RGBRCMLTV_Controller : ApiController
    {
        public IHttpActionResult Get(int month, string region)
        {
            var _repository = new GENERAL_NMOTOR_PERF_RGBRCMLTV_Repository(System.Configuration.ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString);
            var performanceData = _repository.CallStoredProcedure(month, region);
            return Ok(performanceData);
        }
    }
}