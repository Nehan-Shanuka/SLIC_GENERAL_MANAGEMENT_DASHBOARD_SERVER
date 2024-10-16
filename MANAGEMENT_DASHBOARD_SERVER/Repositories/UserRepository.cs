using Dapper;
using MANAGEMENT_DASHBOARD_SERVER.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Diagnostics;

namespace MANAGEMENT_DASHBOARD_SERVER.Repositories
{
    public class UserRepository
    {
        private readonly string _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;

        public User GetUserByUsername(string username)
        {
            using (IDbConnection conn = new OracleConnection(_connectionString))
            {
                var query = "SELECT * FROM SLIC_AGENT.MGT_DASHBOARD_USERS WHERE USERNAME = :USERNAME";
                Debug.WriteLine(username);
                return conn.QuerySingleOrDefault<User>(query, new { USERNAME = username });
            }
        }

        public User VlidateUsername(string username)
        {
            using (IDbConnection conn = new OracleConnection(_connectionString))
            {
                var query = "SELECT USERNAME FROM SLIC_AGENT.MGT_DASHBOARD_USERS WHERE USERNAME = :USERNAME";
                Debug.WriteLine(username);
                return conn.QuerySingleOrDefault<User>(query, new { USERNAME = username });
            }
        }

        public void AddUser(User user)
        {
            using (IDbConnection conn = new OracleConnection(_connectionString))
            {
                var query = @"
            INSERT INTO SLIC_AGENT.MGT_DASHBOARD_USERS (USER_ID, USERNAME, PASSWORD, NAME, CONTACT_NO, CATOGERY)
            VALUES (:USER_ID, :USERNAME, :PASSWORD, :NAME, :CONTACT_NO, :CATOGERY)";

                conn.Execute(query, user);

            }
        }

        public void UpdateUserPassword(User user)
        {
            using (IDbConnection conn = new OracleConnection(_connectionString))
            {
                var query = @"
                            UPDATE SLIC_AGENT.MGT_DASHBOARD_USERS
                            SET PASSWORD = :PASSWORD, UPDATED_AT = :UPDATED_AT
                            WHERE USERNAME = :USERNAME";

                conn.Execute(query, user);
            }
        }
    }
}