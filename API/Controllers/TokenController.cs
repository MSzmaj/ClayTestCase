using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Application.Models;
using System.Collections.Generic;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class TokenController : ControllerBase
    {
        private readonly ILogger<TokenController> _logger;
        private readonly ITokenService _tokenService;

        public TokenController(ILogger<TokenController> logger,
                                ITokenService tokenService)
        {
            _logger = logger;
            _tokenService = tokenService;
        }

        [HttpGet]
        [Route("api/get-all-tokens")]
        [AllowAnonymous]
        public IEnumerable<TokenModel> GetAllTokens()
        {
            return _tokenService.GetAllTokens();
        }

        [HttpPost]
        [Route("api/add")]
        [Authorize(Policy = "Admin")]
        public void AddToken (TokenModel inputModel)
        {
            _tokenService.AddToken(inputModel);
        }
    }
}
