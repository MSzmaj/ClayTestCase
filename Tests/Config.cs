using Microsoft.Extensions.Configuration;

namespace Tests {
    public static class Config {
        public static string GetUnitTestConnectionString() {
            var config = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json")
                        .Build();

            var unitTestDb = "Server=claytestdb.postgres.database.azure.com;Database=unittest;Port=5432;User Id=testclay@claytestdb;Ssl Mode=Require;" ;
            var unitTestPassword = "Password=Test";
            return $"{unitTestDb}{unitTestPassword}";;
        }
    }
}
