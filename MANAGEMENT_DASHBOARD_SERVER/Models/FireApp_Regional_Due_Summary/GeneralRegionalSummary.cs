namespace MANAGEMENT_DASHBOARD_SERVER.Models.FireApp_Regional_Due_Summary
{
    public class GeneralRegionalSummary
    {
        public string region { get; set; }
        public int REQUIRED_YEAR { get; set; }
        public int REQUIRED_MONTH { get; set; }
        public int RENEWAL_VEHICLE_COUNT { get; set; }
        public double RENEWAL_TOTAL { get; set; }
        public double RENEWAL_PREMIUM { get; set; }
        public int RENEWED_VEHICLE_COUNT { get; set; }
        public double RENEWED_TOTAL { get; set; }
        public double RENEWED_PREMIUM { get; set; }
        public int VEHICLE_COUNT_TO_BE_RENEWED { get; set; }
        public double RENEWAL_TOTAL_TO_BE_PAID { get; set; }
        public double RENEWAL_PREMIUM_TO_BE_PAID { get; set; }
        public double GENERAL_ACHIVEMENT { get; set; }
        public double GENERAL_TARGET { get; set; }
    }
}