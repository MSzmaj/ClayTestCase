using System.Collections.Generic;
using Common.Config;
using Domain.Models;
using Domain.Repositories;
using Npgsql;
using Dapper;
using Infrastructure.DatabaseAccess.Queries;

namespace Infratructure.Repositories
{
    public class LogRepository : ILogRepository {
        private readonly AppConfig _appConfig;

        public LogRepository(AppConfig appConfig)
        {
            _appConfig = appConfig;
        }

        public IEnumerable<Log> GetLogs()
        {
            using var connection = new NpgsqlConnection(_appConfig.GetDbConnectionString());
            var query = string.Format(LogQuery.BaseQuery, string.Join(",", LogQuery.Columns));
            var commandDefinition = new CommandDefinition(query);
            return connection.Query<Log>(commandDefinition);
        }

        public int Add(Log inputModel)
        {
            using var connection = new NpgsqlConnection(_appConfig.GetDbConnectionString());

            var parameters = new string[] { 
                LogQuery.Parameter.LockId,
                LogQuery.Parameter.UserId,
                LogQuery.Parameter.TokenId,
                LogQuery.Parameter.Succcess,
                LogQuery.Parameter.EntryDate,
            };

            var query = string.Format(LogQuery.Insert, string.Join(",", LogQuery.Columns), string.Join(",", parameters));

            var queryParameters = new
            {
                inputModel.LockId,
                inputModel.UserId,
                inputModel.TokenId,
                inputModel.Success,
                inputModel.EntryDate
            };

            var commandDefinition = new CommandDefinition(query, queryParameters);

            return connection.Execute(commandDefinition);
        }
    }
}