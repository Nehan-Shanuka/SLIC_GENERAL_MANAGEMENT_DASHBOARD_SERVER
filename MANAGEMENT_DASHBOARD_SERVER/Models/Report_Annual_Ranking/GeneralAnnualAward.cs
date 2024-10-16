using System.Collections.Generic;

namespace MANAGEMENT_DASHBOARD_SERVER.Models.Report_Annual_Ranking
{
    public class GeneralAnnualAward
    {
        public IList<GeneralAnnualAwardRankingRMData> rmList { get; set; }
        public IList<GeneralAnnualAwardRankingBMData> bmList { get; set; }
    }
}