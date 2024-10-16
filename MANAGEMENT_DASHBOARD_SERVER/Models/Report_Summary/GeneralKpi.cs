namespace MANAGEMENT_DASHBOARD_SERVER.Models.Report_Summary
{
    public class GeneralKpi
    {
        public string Kpi { get; set; }
        public double Last_year { get; set; }
        public double Target { get; set; }
        public double Achievement { get; set; }
        public double Ach_presentage { get; set; }
        public double Growth_presentage { get; set; }
    }
}