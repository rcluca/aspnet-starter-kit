using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet("profile/{id}")]
        public async Task<IActionResult> GetProfile(int id)
        {
            return Ok(new Profile { Name = "Getting profile..." });
        }

        class Profile
        {
            public string Name { get; set; }
        }
    }
}
