using System.Diagnostics;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace MANAGEMENT_DASHBOARD_SERVER.Middlewares
{
    public class JwtAuthHandler : AuthorizationFilterAttribute
    {
        private readonly string _jwtSecret;

        //public JwtAuthHandler() { }

        public JwtAuthHandler(string jwtSecret)
        {
            _jwtSecret = jwtSecret;
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            // Check if the action has the AllowAnonymous attribute
            var allowAnonymous = actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
            {
                return; // Skip authorization
            }

            //Debug.WriteLine("TEST_AUTH_1");

            // Check for Authorization header
            if (actionContext.Request.Headers.Authorization == null ||
                actionContext.Request.Headers.Authorization.Scheme != "Bearer")
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                return;
            }

            //Debug.WriteLine("TEST_AUTH_2");

            var token = actionContext.Request.Headers.Authorization.Parameter;
            if (string.IsNullOrEmpty(token))
            {
                //Debug.WriteLine("Token validation failed: Empty token.");
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                return;
            }

            //Debug.WriteLine("TEST_AUTH_3");

            try
            {
                // Validate the token
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_jwtSecret);

                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    RequireExpirationTime = true, // Ensure expiration time is validated
                    ValidateLifetime = true // Ensure the token has not expired
                }, out var validatedToken);

                //Debug.WriteLine("TEST_AUTH_4");

                var jwtToken = (JwtSecurityToken)validatedToken;
                var username = jwtToken.Claims.FirstOrDefault(x => x.Type == "unique_name");
                var role = jwtToken.Claims.FirstOrDefault(x => x.Type == "role");

                if (username == null || string.IsNullOrEmpty(username.Value))
                {
                    //Debug.WriteLine("Token validation failed: Username claim is missing or empty.");
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                    return;
                }

                if (role == null || string.IsNullOrEmpty(role.Value))
                {
                    //Debug.WriteLine("Token validation failed: Role claim is missing or empty.");
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                    return;
                }

                //Debug.WriteLine("TEST_AUTH_5");

                //Debug.WriteLine(username.Value + " - " + role.Value);

                // Create principal and set it to the current context
                //var identity = new GenericIdentity(username.Value, role.Value);
                //var principal = new GenericPrincipal(identity, new string[] { });
                var identity = new GenericIdentity(username.Value);
                var principal = new GenericPrincipal(identity, new[] { role.Value });
                //Debug.WriteLine("TEST_AUTH_6");
                Thread.CurrentPrincipal = principal;
            }
            catch (Exception ex)
            {
                // Log exception details for debugging
                //Debug.WriteLine($"Token validation failed: {ex.Message}");
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                return;
            }
        }
    }
}