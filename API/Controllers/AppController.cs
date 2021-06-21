using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    public class AppController : ControllerBase
    {
        private readonly ILogger<TokenController> _logger;

        public AppController(ILogger<TokenController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string HealthCheck()
        {
            return "API is running";
        }
    }
}
