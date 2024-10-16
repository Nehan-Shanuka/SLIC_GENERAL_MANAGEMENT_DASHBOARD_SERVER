using MANAGEMENT_DASHBOARD_SERVER.Models;
using MANAGEMENT_DASHBOARD_SERVER.Repositories;
using MANAGEMENT_DASHBOARD_SERVER.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MANAGEMENT_DASHBOARD_SERVER.Controllers
{
    [RoutePrefix("api/auth")]
    public class LoginController : ApiController
    {
        private readonly AuthService _authService;

        public LoginController()
        {
            var userRepository = new UserRepository();
            _authService = new AuthService(userRepository);
        }

        [HttpGet]
        [Route("test")]
        [AllowAnonymous]
        public IHttpActionResult Test()
        {
            //Debug.WriteLine("TEST_4");
            return Ok("Pass");
        }

        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public IHttpActionResult Register([FromBody] UserRequest userRequest)
        {
            User user = _authService.Register(userRequest.USER_ID, userRequest.USERNAME, userRequest.PASSWORD, userRequest.NAME, userRequest.CONTACT_NO, userRequest.CATOGERY);
            if (user == null)
            {
                return BadRequest();
            }
            return Ok(user);
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public IHttpActionResult Login([FromBody] LoginRequest loginRequest)
        {
            //Debug.WriteLine("TEST_3");
            var token = _authService.Authenticate(loginRequest.USERNAME, loginRequest.PASSWORD);
            if (token == null)
                return Unauthorized();

            return Ok(new { Token = token });
        }

        [HttpPut]
        [Route("pswUpdate")]
        //[Authorize]
        public IHttpActionResult UpdatePassword([FromBody] UpdatePasswordRequest request)
        {
            try
            {
                //Debug.WriteLine("ENTER_UpdatePassword");

                if (request == null)
                    return BadRequest("Invalid request payload.");

                // Call the AuthService to update the password.
                _authService.UpdatePassword(request.USERNAME, request.OLD_PASSWORD, request.NEW_PASSWORD);

                return Ok("Password successfully updated.");
            }
            catch (ArgumentException ex)
            {
                // Handle validation errors from AuthService (e.g., incorrect old password).
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                // Handle unexpected errors.
                return InternalServerError(ex);
            }
        }
    }
}