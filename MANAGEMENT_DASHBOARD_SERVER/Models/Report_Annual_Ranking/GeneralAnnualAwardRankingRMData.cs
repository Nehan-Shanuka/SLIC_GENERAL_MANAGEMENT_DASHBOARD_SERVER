namespace MANAGEMENT_DASHBOARD_SERVER.Models.Report_Annual_Ranking
{
    public class GeneralAnnualAwardRankingRMData
    {
        public string REGION { get; set; }
        public string BUSINESS_UNIT { get; set; }
        public double MOTOR_ACHIVEMENT { get; set; }
        public double MOTOR_TARGET { get; set; }
        public double MOTOR_ACH_P { get; set; }
        public double NON_MOTOR_ACHIVEMENT { get; set; }
        public double NON_MOTOR_TARGET { get; set; }
        public double NON_MOTOR_ACH_P { get; set; }
        public double MOTOR_NEW_ACHIVEMENT { get; set; }
        public double MOTOR_NEW_TARGET { get; set; }
        public double MOTOR_NEW_ACH_P { get; set; }
        public double NON_MOTOR_NEW_ACHIVEMENT { get; set; }
        public double NON_MOTOR_NEW_TARGET { get; set; }
        public double NON_MOTOR_NEW_ACH_P { get; set; }
        public int AMP_COUNT { get; set; }
        public int AMP_TARGET { get; set; }
        public double AMP_ACH_P { get; set; }
        public int MOTOR_RANK_VAL { get; set; }
        public int NON_MOTOR_RANK_VAL { get; set; }
        public int MOTOR_NEW_RANK_VAL { get; set; }
        public int NON_MOTOR_NEW_RANK_VAL { get; set; }
        public int MOTOR_ACH_P_RANK_VAL { get; set; }
        public int NON_MOTOR_ACH_P_RANK_VAL { get; set; }
        public int MOTOR__NEW_ACH_P_RANK_VAL { get; set; }
        public int NON_MOTOR_NEW_ACH_P_RANK_VAL { get; set; }
        public int AMP_RANK_VAL { get; set; }
        public int AMP_ACH_P_RANK_VAL { get; set; }
        public double SCORE { get; set; }
        public int RANK { get; set; }
    }
}