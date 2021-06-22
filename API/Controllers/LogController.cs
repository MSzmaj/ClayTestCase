using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Application.Models;
using Application.Services.Interfaces;
using Application.Validators.Interfaces;
using Common;
using Common.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers {

    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class LogController : ControllerBase {
        private readonly ILogger<LogController> _logger;
        private readonly ILogService _logService;

        private readonly ILockValidator _lockValidator;
        private readonly IUserValidator _userValidator;

        public LogController (ILogService logService, 
                                ILogger<LogController> logger,
                                ILockValidator lockValidator,
                                IUserValidator userValidator) {
            _logService = logService;
            _logger = logger;
            _lockValidator = lockValidator;
            _userValidator = userValidator;
        }

        [HttpPost]
        [Route("api/log-entry")]
        [Authorize(Policy = "User")]
        public IActionResult LogEntry (LogModel log) {
            _logger.LogInformation($"LogEntry called with {log.ToString()}");
            try {
                _userValidator.ValidateClaimId(log.UserId.ToString(), 
                                            User.Identity.GetClaimId().ToString());
                _logService.AddLog(log);
            } catch (ValidationException exception) {
                return BadRequest(exception.Message);
            } catch (UnauthorizedAccessException exception) {
                return Unauthorized(exception.Message);
            }
            return Ok();
        }

        [HttpGet]
        [Route("api/get-lock-logs")]
        [Authorize(Policy = "User")]
        public IActionResult GetLockLogs (LogModel log) {
            _logger.LogInformation($"GetLockLogs called with {log.ToString()}");
            
            IEnumerable<LogModel> logs;
            try {
                _userValidator.ValidateClaimId(log.UserId.ToString(), 
                                            User.Identity.GetClaimId().ToString());
                logs = _logService.GetLockLogs(log);
            } catch (ModelValidationException exception) {
                return BadRequest(exception.Message);
            } catch (UnauthorizedAccessException exception) {
                return Unauthorized(exception.Message);
            } catch (KeyNotFoundException exception) {
                return NotFound(exception.Message);
            }

            return Ok(logs);
        }

        [HttpGet]
        [Route("api/get-all-logs")]
        [Authorize(Policy = "Admin")]
        public IActionResult GetAllLogs()
        {
            _logger.LogInformation("GetAllLogs called");
            var logs = _logService.GetAllLogs();
            return logs.Any() ? Ok(logs) : BadRequest();
        }
    }
}