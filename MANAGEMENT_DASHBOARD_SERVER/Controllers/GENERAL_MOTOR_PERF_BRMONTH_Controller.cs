﻿using MANAGEMENT_DASHBOARD_SERVER.Repositories;
using System;
using System.Web.Http;

namespace MANAGEMENT_DASHBOARD_SERVER.Controllers
{
    public class GENERAL_MOTOR_PERF_BRMONTH_Controller: ApiController
    {
        private readonly GENERAL_MOTOR_PERF_BRMONTH_Repository _repository;

        public GENERAL_MOTOR_PERF_BRMONTH_Controller()
        {
            // Initialize the repository with a connection string to your Oracle database
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;
            _repository = new GENERAL_MOTOR_PERF_BRMONTH_Repository(connectionString);
        }

        [HttpGet]
        [Route("api/GENERAL_MOTOR_PERF_BRMONTH")]
        public IHttpActionResult GetMotorPerformanceData([FromUri] int month)
        {
            try
            {
                // Call the repository method to get the motor performance data
                var performanceData = _repository.CallStoredProcedure(month);

                // Return the data as a JSON response
                return Ok(performanceData);
            }
            catch (Exception ex)
            {
                // Log the error (implement logging as needed) and return a 500 Internal Server Error response
                return InternalServerError(ex);
            }
        }
    }
}