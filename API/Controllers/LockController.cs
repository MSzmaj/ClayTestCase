using System.Linq;
using Application.Models;
using Application.Services.Interfaces;
using Application.Validators.Interfaces;
using Common.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Common;
using System;

namespace API.Controllers {

    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class LockController : ControllerBase {
        private readonly ILogger<LockController> _logger;
        private readonly ILockService _lockService;
        private readonly IUserValidator _userValidator;

        public LockController (ILockService lockService,
                                ILogger<LockController> logger,
                                IUserValidator userValidator) {
            _lockService = lockService;
            _logger = logger;
            _userValidator = userValidator;
        }

        [HttpPost]
        [Route("api/register-lock")]
        [Authorize(Policy = "User")]
        public IActionResult RegisterLock (LockModel lockModel) {
            _logger.LogInformation($"RegisterLock called with {lockModel.ToString()}");

            string lockId;
            try {
                _userValidator.ValidateClaimId(lockModel.OwnerId.ToString(),
                                                User.Identity.GetClaimId().ToString());
                lockId = _lockService.AddLock(lockModel);
            } catch (ModelValidationException exception) {
                return BadRequest(exception.Message);
            } catch (UnauthorizedAccessException exception) {
                return Unauthorized(exception.Message);
            }
            return Ok(lockId);
        }

        [HttpGet]
        [Route("api/get-all-locks")]
        [Authorize(Policy = "Admin")]
        public IActionResult GetAllLocks()
        {
            _logger.LogInformation("GetAllLocks called");
            var locks = _lockService.GetAllLocks();
            return locks.Any() ? Ok(locks) : BadRequest();
        }
    }
}