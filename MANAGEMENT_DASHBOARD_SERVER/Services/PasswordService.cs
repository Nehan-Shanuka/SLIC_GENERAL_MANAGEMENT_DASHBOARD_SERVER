using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using BCrypt.Net;

namespace MANAGEMENT_DASHBOARD_SERVER.Services
{
    public class PasswordService
    {
        /// <summary>
        /// Hashes a plain text password using BCrypt.
        /// </summary>
        /// <param name="password">Plain text password.</param>
        /// <returns>Hashed password.</returns>
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, workFactor: 12);
        }

        /// <summary>
        /// Verifies a plain text password against the stored hashed password.
        /// </summary>
        /// <param name="inputPassword">Plain text password.</param>
        /// <param name="storedHashedPassword">Hashed password from the database.</param>
        /// <returns>True if passwords match, false otherwise.</returns>
        public bool VerifyPassword(string inputPassword, string storedHashedPassword)
        {
            Debug.WriteLine("PSW VERIFICATION PASS");
            return BCrypt.Net.BCrypt.Verify(inputPassword, storedHashedPassword);
        }
    }
}