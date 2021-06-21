using System.Collections.Generic;
using Common.Config;
using Domain.Models;
using Domain.Repositories;
using Npgsql;
using Dapper;
using Infrastructure.DatabaseAccess.Queries;

namespace Infratructure.Repositories
{
    public class UserRepository : IUserRepository {
        private readonly AppConfig _appConfig;

        public UserRepository(AppConfig appConfig)
        {
            _appConfig = appConfig;
        }

        public IEnumerable<User> GetUsers()
        {
            using var connection = new NpgsqlConnection(_appConfig.GetDbConnectionString());
            var query = string.Format(UserQuery.BaseQuery, string.Join(",", UserQuery.Columns));
            var commandDefinition = new CommandDefinition(query);
            return connection.Query<User>(commandDefinition);
        }

        public int Add(User inputModel)
        {
            using var connection = new NpgsqlConnection(_appConfig.GetDbConnectionString());

            var columns = new string[] {  };
            var parameters = new string[] { };

            var query = string.Format(UserQuery.Insert, string.Join(",", columns), string.Join(",", parameters));

            var queryParameters = new
            {
            };

            var commandDefinition = new CommandDefinition(query, queryParameters);

            return connection.Execute(commandDefinition);
        }
    }
}