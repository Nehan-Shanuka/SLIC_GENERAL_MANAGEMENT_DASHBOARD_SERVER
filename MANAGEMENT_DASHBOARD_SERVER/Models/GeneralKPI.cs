using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MANAGEMENT_DASHBOARD_SERVER.Models
{
    public class GeneralKPI
    {
        public string KPI { get; set; }
        public double Last_year { get; set; }
        public double Target { get; set; }
        public double Achievement { get; set; }
        public double Ach_percentage { get; set; }
        public double Growth_percentage { get; set; }
    }
}