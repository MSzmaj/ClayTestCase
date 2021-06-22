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

        public TokenController(ILogger<TokenController> logger, ITokenService tokenService)
        {
            _logger = logger;
            _tokenService = tokenService;
        }

        [HttpGet]
        [Route("api/request-token")]
        [Authorize(Policy = "User")]
        public IActionResult RequestToken (TokenRequestModel tokenRequest) {
            TokenReturnModel returnToken;
            try {
                returnToken = _tokenService.AddToken(tokenRequest);
            } catch (ModelValidationException exception) {
                return BadRequest(exception.Message);
            }
            return Ok(returnToken);
        }
    
        [HttpGet]
        [Route("api/get-all-tokens")]
        [Authorize(Policy = "Admin")]
        public IActionResult GetAllTokens()
        {
            var tokens = _tokenService.GetAllTokens();
           return tokens.Any() ? Ok(_tokenService.GetAllTokens()) : BadRequest();
        }
    }
}
