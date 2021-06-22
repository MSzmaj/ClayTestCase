using System.ComponentModel.DataAnnotations;
using System.Linq;
using Application.Models;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers {

    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class LogController : ControllerBase {
        private readonly ILogger<LogController> _logger;
        private readonly ILogService _logService;

        public LogController (ILogService logService, ILogger<LogController> logger) {
            _logService = logService;
            _logger = logger;
        }

        [HttpPost]
        [Route("api/log-entry")]
        [Authorize(Policy = "User")]
        public IActionResult LogEntry (LogModel log) {
            _logger.LogInformation($"LogEntry called with {log.ToString()}");
            try {
                _logService.AddLog(log);
            } catch (ValidationException exception) {
                return BadRequest(exception.Message);
            }
            return Ok();
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