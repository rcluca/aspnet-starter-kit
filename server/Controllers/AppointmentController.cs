using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using server.Dtos;
using server.Services.Interfaces;
using Server.Models;
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
        public AppointmentController(
            ILoggerFactory loggerFactory,
            IAppointmentService appointmentService,
            UserManager<User> userManager)
        {
            _logger = loggerFactory.CreateLogger<PatientController>();
            _appointmentService = appointmentService;
            _userManager = userManager;
        }

        [HttpGet("purposes")]
        public IActionResult GetPurposes()
        {
            _logger.LogInformation("Getting purposes.");
            var purposes = _appointmentService.GetPurposes();

            return Ok(purposes);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] AppointmentDto appointment)
        {
            _logger.LogInformation("Creating appointment.");
            _logger.LogInformation("PhysicianId: " + appointment.PhysicianId);
            _logger.LogInformation("PurposeId: " + appointment.PurposeId);

            if (!ModelState.IsValid)
                return BadRequest();

            var user = await _userManager.FindByEmailAsync(HttpContext.User.Identity.Name);
            var roles = await _userManager.GetRolesAsync(user);

            _appointmentService.Create(appointment, user.Email, roles.First());

            return Ok();
        }

        [HttpPut("cancel")]
        public IActionResult Cancel([FromBody] AppointmentCancellationDto appointmentCancellation)
        {
            _logger.LogInformation("Canceling appointment.");
            _logger.LogInformation("Cancellation Reason: " + appointmentCancellation.CancellationReason);

            _appointmentService.Cancel(appointmentCancellation);

            return Ok();
        }

        [HttpPut("approve/{id}")]
        public async Task<IActionResult> Approve(int id)
        {
            _logger.LogInformation("Approving appointment.");

            var user = await _userManager.FindByEmailAsync(HttpContext.User.Identity.Name);
            var roles = await _userManager.GetRolesAsync(user);

            _appointmentService.Approve(id, roles.First());

            return Ok();
        }

        private readonly ILogger _logger;
        private readonly IAppointmentService _appointmentService;
        private readonly UserManager<User> _userManager;
    }
}
