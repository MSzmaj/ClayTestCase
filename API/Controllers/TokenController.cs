using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Application.Models;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Common;
using Common.Exceptions;
using System.Linq;

namespace API.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = Constants.Auth.Bearer)]
    public class TokenController : ControllerBase
    {
        private readonly ILogger<TokenController> _logger;
        private readonly ITokenService _tokenService;
        private readonly ILogService _logService;

        public TokenController(ILogger<TokenController> logger, 
                                ITokenService tokenService,
                                ILogService logService)
        {
            _logger = logger;
            _tokenService = tokenService;
            _logService = logService;
        }

        [HttpGet]
        [Route("api/request-token")]
        [Authorize(Policy = "User")]
        public IActionResult RequestToken (TokenRequestModel tokenRequest) {
            _logger.LogInformation($"RequestToken called {tokenRequest.ToString()}");
            TokenReturnModel returnToken;
            try {
                returnToken = _tokenService.AddToken(tokenRequest);
            } catch (ModelValidationException exception) {
                return BadRequest(exception.Message);
            }

            var log = new LogModel {
                LockId = tokenRequest.LockId,
                UserId = tokenRequest.OwnerId,
                TokenId = returnToken.TokenId,
                Success = false,
                EntryDate = System.DateTime.Now
            };

            _logService.AddLog(log);

            return Ok(returnToken);
        }
    
        [HttpGet]
        [Route("api/get-all-tokens")]
        [Authorize(Policy = "Admin")]
        public IActionResult GetAllTokens()
        {
            _logger.LogInformation("GetAllTokens called");
            var tokens = _tokenService.GetAllTokens();
           return tokens.Any() ? Ok(_tokenService.GetAllTokens()) : BadRequest();
        }
    }
}
