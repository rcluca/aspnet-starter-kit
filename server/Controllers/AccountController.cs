// Copyright © 2014-present Kriasoft, LLC. All rights reserved.
// This source code is licensed under the MIT license found in the
// LICENSE.txt file in the root directory of this source tree.

using System.Collections.Generic;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Server.Models;
using System.Threading.Tasks;
using System;
using server.Dtos;

namespace Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger _logger;

        public AccountController(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ILoggerFactory loggerFactory)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = loggerFactory.CreateLogger<AccountController>();
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginDto model, [FromBody] string returnUrl = null)
        {
            _logger.LogInformation(1, "Initiating login.");
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation(2, "User logged in.");
                    //return RedirectToLocal(returnUrl);
                    var user = await _userManager.FindByEmailAsync(model.Email);
                    var roles = await _userManager.GetRolesAsync(user);
                    return Ok(new { role = roles.Contains("Patient") ? "patient" : "physician" });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning(3, "User account locked out.");
                    //return View("Lockout");
                    return BadRequest();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return BadRequest();
                }
            }

            _logger.LogInformation(4, "Login modelstate is invalid.");

            // If we got this far, something failed, redisplay form
            return BadRequest();
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation(4, "User logged out.");
            return Ok();
        }

        [HttpGet("user-data")]
        [AllowAnonymous]
        public IActionResult GetUserData()
        {
            if (User.Identity.IsAuthenticated)
                return Ok(new
                {
                    IsUserLoggedIn = true,
                    Email = User.Identity.Name,
                    Role = User.IsInRole("Patient") ? "patient" : "physician"
                });
            else
                return Ok(new
                {
                    IsUserLoggedIn = false,
                    Email = "",
                    Role = ""
                });
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }
    }
}
