using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MANAGEMENT_DASHBOARD_SERVER.Models
{
    public class BasicKPI
    {
        public string KPI { get; set; }
        public double Last_year { get; set; }
        public double Achievement { get; set; }
        public int month { get; set; }
    }
}