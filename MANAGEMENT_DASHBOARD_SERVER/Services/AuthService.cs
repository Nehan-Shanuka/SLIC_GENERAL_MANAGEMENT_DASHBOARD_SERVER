using MANAGEMENT_DASHBOARD_SERVER.Models;
using MANAGEMENT_DASHBOARD_SERVER.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace MANAGEMENT_DASHBOARD_SERVER.Services
{
    public class AuthService
    {
        private readonly UserRepository _userRepository;
        private readonly PasswordService _passwordService;
        private readonly string _jwtSecret;

        public AuthService(UserRepository userRepository)
        {
            _userRepository = userRepository;
            _passwordService = new PasswordService();
            _jwtSecret = "jkjdlLKHKDlkd226#^&#*@(#(@NDKWDJjksdsfssd556412sflkslkJHDDKEjl#*$($GHD";
        }

        public User Register(int user_id, string username, string password, string name, string contact_no, int category)
        {
            // Validate that the username is not already in use.
            if (_userRepository.VlidateUsername(username) != null)
            {
                throw new ArgumentException("Username already exists. Please choose a different username.");
            }

            // Validate inputs (example checks, you can add more)
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Username and password are required.");
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required.");
            if (string.IsNullOrWhiteSpace(contact_no))
                throw new ArgumentException("Contact number is required.");

            // Hash the password using BCrypt (or another hashing algorithm).
            string hashedPassword = _passwordService.HashPassword(password);

            // Create a new user object with the provided information.
            var newUser = new User
            {
                USER_ID = user_id,
                USERNAME = username,
                PASSWORD = hashedPassword,
                NAME = name,
                CONTACT_NO = contact_no,
                CATOGERY = category,
                //CREATED_AT = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                //UPDATED_AT = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };

            // Insert the new user into the database using the repository.
            _userRepository.AddUser(newUser);

            // Optional: Log the registration event or send a confirmation email.
            Console.WriteLine("User successfully registered.");

            return newUser;
        }

        public string Authenticate(string username, string password)
        {
            var user = _userRepository.GetUserByUsername(username);
            Debug.WriteLine(user);

            // Implement password verification logic (e.g., hashing comparison)
            if (!_passwordService.VerifyPassword(password, user.PASSWORD)) // Simplified for demo
                return null;

            if (user == null)
                return null;

            // Generate JWT token
            return GenerateJwtToken(user);
        }

        public void UpdatePassword(string username, string oldPassword, string newPassword)
        {
            Debug.WriteLine("TEST_UP_1");
            // Validate inputs.
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(oldPassword) || string.IsNullOrWhiteSpace(newPassword))
                throw new ArgumentException("All fields are required.");

            Debug.WriteLine("TEST_UP_2");

            // Retrieve the user from the database.
            var user = _userRepository.GetUserByUsername(username);
            if (user == null)
            {
                throw new ArgumentException("User not found.");
            }

            Debug.WriteLine("TEST_UP_3");

            // Verify that the old password is correct.
            bool isOldPasswordValid = _passwordService.VerifyPassword(oldPassword, user.PASSWORD);
            if (!isOldPasswordValid)
            {
                throw new ArgumentException("The old password is incorrect.");
            }

            Debug.WriteLine("TEST_UP_4");

            // Hash the new password.
            string hashedNewPassword = _passwordService.HashPassword(newPassword);

            Debug.WriteLine("TEST_UP_5");

            // Update the user's password in the database.
            user.PASSWORD = hashedNewPassword;
            //user.UPDATED_AT = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); // Update the timestamp for tracking.

            Debug.WriteLine("TEST_UP_6");

            // Update the user in the database using the repository.
            _userRepository.UpdateUserPassword(user);

            // Optional: Log the password change event or send a notification.
            Console.WriteLine("Password successfully updated.");
        }

        //private bool VerifyPassword(string inputPassword, string storedHashedPassword)
        //{
        //    // Implement a password verification method (e.g., BCrypt.Net)
        //    return inputPassword == storedHashedPassword; // Simplified for demo
        //}

        private string GenerateJwtToken(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user), "User cannot be null.");

            // Ensure the secret key is properly set and of adequate length
            if (string.IsNullOrWhiteSpace(_jwtSecret) || _jwtSecret.Length < 32)
                throw new InvalidOperationException("Invalid secret key. Ensure it is at least 32 characters long.");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSecret); // Secret key for signing

            // Create claims for the token
            var claims = new[]
            {
        new Claim(ClaimTypes.Name, user.USERNAME),
        new Claim(ClaimTypes.Role, user.CATOGERY.ToString()) // Role as a string
    };

            // Define token descriptor
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1), // Set expiration time
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            // Create the token
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // Return the token string
            return tokenHandler.WriteToken(token);
        }


        public static string GenerateRandomKey(int length)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var key = new byte[length];
                rng.GetBytes(key);
                return Convert.ToBase64String(key);
            }
        }
    }
}