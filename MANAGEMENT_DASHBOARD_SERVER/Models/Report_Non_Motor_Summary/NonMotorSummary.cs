namespace MANAGEMENT_DASHBOARD_SERVER.Models.Report_Non_Motor_Summary
{
    public class NonMotorSummary
    {
        public string KPI { get; set; }
        public double LAST_YEAR { get; set; }
        public double TARGET { get; set; }
        public double ACHIEVEMENT { get; set; }
        public double ACH_PRESENTAGE { get; set; }
        public double GROWTH_PRESENTAGE { get; set; }
    }
}