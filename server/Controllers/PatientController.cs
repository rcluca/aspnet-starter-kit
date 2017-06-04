using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class PatientController : Controller
    {
        private readonly ILogger _logger;

        public PatientController(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<PatientController>();
        }

        [HttpGet("profile/{id}")]
        public async Task<IActionResult> GetProfile(int id)
        {
            var hasAuthCookie = HttpContext.Request.Cookies.Any(w => w.Key == ".AspNetCore.Identity.Application");

            _logger.LogInformation(1, "Has auth cookie: " + hasAuthCookie);
            _logger.LogInformation(1, "Cookie count: " + HttpContext.Request.Cookies.Count);
            return Ok(new Profile { Name = "Getting profile..." });
        }

        class Profile
        {
            public string Name { get; set; }
        }
    }
}
