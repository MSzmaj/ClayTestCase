using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Authorize]
    public class AppController : ControllerBase
    {
        private readonly ILogger<TokenController> _logger;

        public AppController(ILogger<TokenController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("api/healthcheck")]
        [AllowAnonymous]
        public string HealthCheck()
        {
            return "API is running";
        }
    }
}
