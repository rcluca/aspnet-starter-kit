using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Controllers
{
    [Authorize(Roles = "Patient")]
    [Route("api/[controller]")]
    public class PatientController : Controller
    {
        private readonly ILogger _logger;

        public PatientController(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<PatientController>();
        }

        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile()
        {
            return Ok(new { Name = "Getting profile..." });
        }
    }
}
