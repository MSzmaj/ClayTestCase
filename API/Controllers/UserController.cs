using System.Linq;
using Application.Models;
using Application.Services.Interfaces;
using Common.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers {

    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class UserController : ControllerBase {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController (IUserService userService, ILogger<UserController> logger) {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost]
        [Route("api/register-user")]
        [Authorize(Policy = "User")]
        public IActionResult RegisterUser (UserModel user) {
            var userId = string.Empty;
            try {
                userId = _userService.AddUser(user);
            } catch (ModelValidationException exception) {
                return BadRequest(exception.Message);
            }
            return Ok(userId);
        }

        [HttpGet]
        [Route("api/get-all-users")]
        [Authorize(Policy = "Admin")]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return users.Any() ? Ok(users) : BadRequest();
        }
    }
}