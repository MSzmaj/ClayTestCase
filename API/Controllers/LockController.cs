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
    public class LockController : ControllerBase {
        private readonly ILogger<LockController> _logger;
        private readonly ILockService _lockService;

        public LockController (ILockService lockService, ILogger<LockController> logger) {
            _lockService = lockService;
            _logger = logger;
        }

        [HttpPost]
        [Route("api/register-lock")]
        [Authorize(Policy = "User")]
        public IActionResult RegisterLock (LockModel lockModel) {
            var lockId = string.Empty;
            try {
                lockId = _lockService.AddLock(lockModel);
            } catch (ModelValidationException exception) {
                return BadRequest(exception.Message);
            }
            return Ok(lockId);
        }

        [HttpGet]
        [Route("api/get-all-locks")]
        [Authorize(Policy = "Admin")]
        public IActionResult GetAllLocks()
        {
            var locks = _lockService.GetAllLocks();
            return locks.Any() ? Ok(locks) : BadRequest();
        }
    }
}