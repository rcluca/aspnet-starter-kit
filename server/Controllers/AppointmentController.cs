using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using server.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class AppointmentController : Controller
    {
        public AppointmentController(ILoggerFactory loggerFactory, IAppointmentService appointmentService)
        {
            _logger = loggerFactory.CreateLogger<PatientController>();
            _appointmentService = appointmentService;
        }

        [HttpGet("profile")]
        public IActionResult GetProfile()
        {
            return Ok();
        }

        private readonly ILogger _logger;
        private readonly IAppointmentService _appointmentService;
    }
}
