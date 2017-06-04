using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using server.Constants;
using server.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class PhysicianController : Controller
    {
        public PhysicianController(ILoggerFactory loggerFactory, IPhysicianService physicianService)
        {
            _logger = loggerFactory.CreateLogger<PatientController>();
            _physicianService = physicianService;
        }

        [HttpGet("patients")]
        [Authorize(Roles = Roles.Physician)]
        public IActionResult GetPatients()
        {
            var patients = _physicianService.GetPatients();

            return Ok(patients);
        }

        [HttpGet("names")]
        public IActionResult GetNames()
        {
            var names = _physicianService.GetNames();

            return Ok(names);
        }

        private readonly ILogger _logger;
        private readonly IPhysicianService _physicianService;
    }
}
