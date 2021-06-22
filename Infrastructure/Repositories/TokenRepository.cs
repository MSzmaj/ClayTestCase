using System.Collections.Generic;
using Common.Config;
using Domain.Models;
using Domain.Repositories;
using Npgsql;
using Dapper;
using Infrastructure.DatabaseAccess.Queries;

namespace Infratructure.Repositories
{
    public class TokenRepository : ITokenRepository {
        private readonly AppConfig _appConfig;

        public TokenRepository(AppConfig appConfig)
        {
            _appConfig = appConfig;
        }

        public IEnumerable<Token> GetTokens()
        {
            using var connection = new NpgsqlConnection(_appConfig.GetDbConnectionString());
            var query = string.Format(TokenQuery.BaseQuery, string.Join(",", TokenQuery.Columns));
            var commandDefinition = new CommandDefinition(query);
            return connection.Query<Token>(commandDefinition);
        }

        public int Add(TokenRequest inputModel)
        {
            using var connection = new NpgsqlConnection(_appConfig.GetDbConnectionString());

            var columns = new string[] { TokenQuery.Column.LockId, TokenQuery.Column.OwnerId, TokenQuery.Column.Expiry };
            var parameters = new string[] { TokenQuery.Parameter.LockId, TokenQuery.Parameter.OwnerId, TokenQuery.Parameter.Expiry };

            var query = string.Format(TokenQuery.Insert, string.Join(",", columns), string.Join(",", parameters));

            var queryParameters = new
            {
                inputModel.LockId,
                inputModel.OwnerId,
                inputModel.Expiry
            };

            var commandDefinition = new CommandDefinition(query, queryParameters);

            return connection.ExecuteScalar<int>(commandDefinition);
        }

        public Token FindById(int tokenId) {
            using var connection = new NpgsqlConnection(_appConfig.GetDbConnectionString());

            var query = string.Format(TokenQuery.FindById, TokenQuery.Parameter.Id);

            var queryParameters = new
            {
                tokenId
            };

            var commandDefinition = new CommandDefinition(query, queryParameters);

            return connection.QueryFirstOrDefault<Token>(commandDefinition); 
        }
    }
}