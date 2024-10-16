namespace MANAGEMENT_DASHBOARD_SERVER.Models.FireApp_Homepage_Data
{
    public class GeneralAmpDataRM
    {
        public int AGENCY { get; set; }
        public string AGENT_NAME { get; set; }
        public int BRANCH_CODE { get; set; }
        public string BRANCH_NAME { get; set; }
        public double NEW_PREMIUM { get; set; }
        public int NEW_COUNT { get; set; }
        public double GWP_G { get; set; }
        public double GWP_3_MONTHS { get; set; }
        public int GENERAL_ACTIVE { get; set; }
        public string AS_AT_DATE { get; set; }
    }
}