using System.Collections.Generic;
using Domain.Models;

namespace Domain.Repositories
{
    public interface ITokenRepository
    {
        IEnumerable<Token> GetTokens();
        int Add(TokenRequest inputModel);
        Token FindById(int id);
    }
}
