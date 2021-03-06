using Microsoft.Extensions.Configuration;
using System;

namespace Common.Config
{
    public sealed class AppConfig : IAppConfig
    {
        private readonly IConfiguration _configuration;

        public AppConfig(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetDbConnectionString ()
        {
            var connectionString = _configuration["ConnectionStrings:DefaultConnection"];
            var connectionPassword = $"Password={_configuration["ConnectionStringPassword"]}";
            return $"{connectionString}{connectionPassword}";
        }
    }

    public interface IAppConfig {
        string GetDbConnectionString();
    }
}
