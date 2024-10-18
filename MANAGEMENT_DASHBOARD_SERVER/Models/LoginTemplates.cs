using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MANAGEMENT_DASHBOARD_SERVER.Models
{
    public class User
    {
        public int USER_ID { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string NAME { get; set; }
        public string CONTACT_NO { get; set; }
        public int CATOGERY { get; set; }
        //public string CREATED_AT { get; set; }
        //public string UPDATED_AT { get; set; }
    }

    public class LoginRequest
    {
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
    }

    public class LoginResult
    {
        public string ACCESS_TOKEN { get; set; }
        public string USERNAME { get; set; }
        public int CATOGERY { get; set; }
    }

    public class UserRequest
    {
        public int USER_ID { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string NAME { get; set; }
        public string CONTACT_NO { get; set; }
        public int CATOGERY { get; set; }
    }

    public class UpdatePasswordRequest
    {
        public string USERNAME { get; set; }  // Username of the user
        public string OLD_PASSWORD { get; set; }  // Old password for verification
        public string NEW_PASSWORD { get; set; }  // New password to be set
    }
}