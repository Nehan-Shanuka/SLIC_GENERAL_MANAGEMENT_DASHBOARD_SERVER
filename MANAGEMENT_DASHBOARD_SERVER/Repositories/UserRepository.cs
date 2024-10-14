using Dapper;
using Dapper.Oracle;
using MANAGEMENT_DASHBOARD_SERVER.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace MANAGEMENT_DASHBOARD_SERVER.Repositories
{
    public class UserRepository
    {
        private readonly string _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["OracleDbConnection"].ConnectionString;

        public User GetUserByUsername(string username)
        {
            using (IDbConnection conn = new OracleConnection(_connectionString))
            {
                var query = "SELECT * FROM NEHAN.USER_DETAILS WHERE USERNAME = :USERNAME";
                Debug.WriteLine(username);
                return conn.QuerySingleOrDefault<User>(query, new { USERNAME = username });
            }
        }

        public User VlidateUsername(string username)
        {
            using (IDbConnection conn = new OracleConnection(_connectionString))
            {
                var query = "SELECT USERNAME FROM NEHAN.USER_DETAILS WHERE USERNAME = :USERNAME";
                Debug.WriteLine(username);
                return conn.QuerySingleOrDefault<User>(query, new { USERNAME = username });
            }
        }

        public void AddUser(User user)
        {
            using (IDbConnection conn = new OracleConnection(_connectionString))
            {
                var query = @"
            INSERT INTO NEHAN.USER_DETAILS (USER_ID, USERNAME, PASSWORD, NAME, CONTACT_NO, CATOGERY)
            VALUES (:USER_ID, :USERNAME, :PASSWORD, :NAME, :CONTACT_NO, :CATOGERY)";

                conn.Execute(query, user);

            }
        }

        public void UpdateUserPassword(User user)
        {
            using (IDbConnection conn = new OracleConnection(_connectionString))
            {
                var query = @"
                            UPDATE NEHAN.USER_DETAILS
                            SET PASSWORD = :PASSWORD, UPDATED_AT = :UPDATED_AT
                            WHERE USERNAME = :USERNAME";

                conn.Execute(query, user);
            }
        }
    }
}