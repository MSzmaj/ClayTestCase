using Domain.Repositories;
using Application.Services.Interfaces;
using System.Collections.Generic;
using Application.Models;
using AutoMapper;
using System.Linq;
using Domain.Models;

namespace Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly ITokenRepository _tokenRepository;

        private readonly IMapper _mapper;

        public TokenService(ITokenRepository tokenRepository,
                            IMapper mapper)
        {
            _tokenRepository = tokenRepository;
            _mapper = mapper;
        }

        public IEnumerable<TokenModel> GetAllTokens()
        {
            var tokens = _tokenRepository.GetTokens();
            return tokens.Select(x => _mapper.Map<TokenModel>(x)).ToList();
        }

        public void AddToken(TokenModel token)
        {
            var inputModel = _mapper.Map<Token>(token);
            _tokenRepository.Add(inputModel);
        }
    }
}
