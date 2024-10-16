using System.ComponentModel.DataAnnotations;

namespace MANAGEMENT_DASHBOARD_SERVER.Models.FireApp_RM_Detail
{
    public class GeneralRmBmDetailsData
    {
        [Key]
        public virtual int ROW_ID { get; set; }
        public virtual int BRANCH_CODE { get; set; }
        public virtual string BRANCH_NAME { get; set; }
        public virtual string REGION { get; set; }
        public virtual int EPF { get; set; }
        public virtual string STATUS { get; set; }
        public virtual string NAME { get; set; }
        public virtual string FULL_NAME { get; set; }
        public virtual string MOBILE { get; set; }
        public virtual string TYP { get; set; }
    }
}