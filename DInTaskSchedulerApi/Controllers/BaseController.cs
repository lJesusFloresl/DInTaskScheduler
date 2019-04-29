using DInTaskSchedulerApi.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;

namespace DInTaskSchedulerApi.Controllers
{
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// Get user credentials from token
        /// </summary>
        /// <returns>User information</returns>
        internal UserViewModel GetUserIdentity()
        {
            return new UserViewModel()
            {
                Id = GetIntClaim("Id"),
                Username = GetClaim("Username"),
                Name = GetClaim("Name"),
                Lastname = GetClaim("Lastname"),
                SecondLastname = GetClaim("SecondLastname")
            };
        }

        /// <summary>
        /// Get a 500 response from server
        /// </summary>
        /// <param name="result">Result from server</param>
        /// <returns>Internal Server Error</returns>
        internal ObjectResult InternalServerError(object result)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, result);
        }

        /// <summary>
        /// Get user claim by name (claim type)
        /// </summary>
        /// <param name="name">Claim name</param>
        /// <returns>Claim if exists or empty</returns>
        private string GetClaim(string name)
        {
            return User.Claims.Any(e => e.Type.Equals(name)) ? User.Claims.Single(e => e.Type.Equals(name)).Value : string.Empty;
        }

        /// <summary>
        /// Get int value from claim
        /// </summary>
        /// <param name="name">Claim name</param>
        /// <returns>Int claim value</returns>
        private int GetIntClaim(string name)
        {
            var claim = GetClaim(name);
            return !string.IsNullOrEmpty(claim) ? Convert.ToInt32(claim) : 0;
        }
    }
}
