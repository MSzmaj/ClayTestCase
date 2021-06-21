using System.Collections.Generic;
using Common.Config;
using Domain.Models;
using Domain.Repositories;
using Npgsql;
using Dapper;
using Infrastructure.DatabaseAccess.Queries;

namespace Infratructure.Repositories
{
    public class LockRepository : ILockRepository {
        private readonly AppConfig _appConfig;

        public LockRepository(AppConfig appConfig)
        {
            _appConfig = appConfig;
        }

        public IEnumerable<Lock> GetLocks()
        {
            using var connection = new NpgsqlConnection(_appConfig.GetDbConnectionString());
            var query = string.Format(LockQuery.BaseQuery, string.Join(",", LockQuery.Columns));
            var commandDefinition = new CommandDefinition(query);
            return connection.Query<Lock>(commandDefinition);
        }

        public int Add(Lock inputModel)
        {
            using var connection = new NpgsqlConnection(_appConfig.GetDbConnectionString());

            var columns = new string[] { LockQuery.Column.OwnerId };
            var parameters = new string[] { LockQuery.Parameter.OwnerId };

            var query = string.Format(LockQuery.Insert, string.Join(",", columns), string.Join(",", parameters));

            var queryParameters = new
            {
            };

            var commandDefinition = new CommandDefinition(query, queryParameters);

            return connection.Execute(commandDefinition);
        }
    }
}