using Microsoft.Extensions.Configuration;

namespace Common.Config
{
    public sealed class AppConfig
    {
        private readonly IConfiguration _configuration;

        public AppConfig(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetDbConnectionString ()
        {
            var connectionString = _configuration["ConnectionStrings:DefaultConnection"];
            var connectionPassword = $"Password= {_configuration["ConnectionStringPassword"]}";
            Console.WriteLine($"{connectionString}{connectionPassword}");
            return $"{connectionString}{connectionPassword}";
        }
    }
}
