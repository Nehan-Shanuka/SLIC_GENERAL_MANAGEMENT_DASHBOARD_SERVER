namespace MANAGEMENT_DASHBOARD_SERVER.Models.Performance_Ranking_Region_Branch
{
    public class GeneralBranchPerformanceRank
    {
        public int Rank { get; set; }
        public string BRANCH_NAME { get; set; }
        public double Last_Year { get; set; }
        public double Achievement { get; set; }
        public double Target { get; set; }
        public double Ach_presentage { get; set; }
        public double Growth_presentage { get; set; }
    }
}

