﻿using Microsoft.AspNetCore.Authorization;
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
    public class PatientController : Controller
    {
        public PatientController(ILoggerFactory loggerFactory, IPatientService patientService)
        {
            _logger = loggerFactory.CreateLogger<PatientController>();
            _patientService = patientService;
        }

        [HttpGet("profile")]
        public IActionResult GetProfile()
        {
            var profile = _patientService.GetProfile(HttpContext.User.Identity.Name);

            return Ok(profile);
        }

        [HttpGet("profile/{id}")]
        [Authorize(Roles = Roles.Physician)]
        public IActionResult GetProfile(int id)
        {
            _logger.LogInformation("Patient Id: " + id);

            var profile = _patientService.GetProfile(2, HttpContext.User.Identity.Name);

            return Ok(profile);
        }
            
        [HttpGet("names")]
        public IActionResult GetNames()
        {
            var names = _patientService.GetNames();

            return Ok(names);
        }

        private readonly ILogger _logger;
        private readonly IPatientService _patientService;
    }
}
