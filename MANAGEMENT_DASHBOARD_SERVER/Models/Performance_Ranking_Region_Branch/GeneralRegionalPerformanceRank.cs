namespace MANAGEMENT_DASHBOARD_SERVER.Models.Performance_Ranking_Region_Branch
{
    public class GeneralRegionalPerformanceRank
    {
        public int rank { get; set; }
        public string region { get; set; }
        public double Last_year { get; set; }
        public double Achievement { get; set; }
        public double Target { get; set; }
        public double Ach_presentage { get; set; }
        public double Growth_presentage { get; set; }
    }
}