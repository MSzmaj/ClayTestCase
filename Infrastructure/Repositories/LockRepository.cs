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
        private readonly IAppConfig _appConfig;

        public LockRepository(IAppConfig appConfig)
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

            var query = string.Format(LockQuery.Insert, LockQuery.Column.OwnerId, LockQuery.Parameter.OwnerId);

            var queryParameters = new
            {
                inputModel.OwnerId
            };

            var commandDefinition = new CommandDefinition(query, queryParameters);

            return connection.ExecuteScalar<int>(commandDefinition);
        }

        public Lock FindById(int id) {
            using var connection = new NpgsqlConnection(_appConfig.GetDbConnectionString());

            var query = string.Format(LockQuery.FindById, LockQuery.Parameter.Id);

            var queryParameters = new
            {
                id
            };

            var commandDefinition = new CommandDefinition(query, queryParameters);

            return connection.QueryFirstOrDefault<Lock>(commandDefinition); 
        }
    }
}