using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MANAGEMENT_DASHBOARD_SERVER.Models
{
    public class SummaryDetail
    {
        public string Kpi { get; set; }
        public int Last_year { get; set; }
        public int Target { get; set; }
        public int Achievement { get; set; }
        public int Ach_presentage { get; set; }
        public int Growth_presentage { get; set; }
    }
}