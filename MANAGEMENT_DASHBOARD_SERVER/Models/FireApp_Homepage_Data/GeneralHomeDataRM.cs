using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MANAGEMENT_DASHBOARD_SERVER.Models.FireApp_Homepage_Data
{
    public class GeneralHomeDataRM
    {
        public IList<GeneralRegionalSummary> regionalSummaryList { get; set; }
        public IList<GeneralKPI> regionalKpiList { get; set; }
        public IList<GeneralAmpDataRM> regionalAmpList { get; set; }
        public IList<GeneralNewRecruitmentRM> regionalNewRecList { get; set; }
        public GenTarAchChartCumuData achievementCumulative { get; set; }
    }
}