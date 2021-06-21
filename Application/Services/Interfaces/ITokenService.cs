using System;
using System.Collections.Generic;
using Application.Models;

namespace Application.Services.Interfaces
{
    public interface ITokenService
    {
        IEnumerable<TokenModel> GetAllTokens();
        void AddToken(TokenModel token);
    }
}
