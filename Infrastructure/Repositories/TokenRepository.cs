using System;
using System.Collections.Generic;
using Domain.Models;
using Domain.Repositories;

namespace Infratructure.Repositories
{
    public class TokenRepository : ITokenRepository {
        public IEnumerable<Token> GetTokens()
        {
            return new List<Token>
            {
                new Token
                {
                    Id = "ID",
                    Expiry = DateTime.Now.AddDays(1),
                    OwnerId = "OwnerID"
                }
            };
        }
    }
}