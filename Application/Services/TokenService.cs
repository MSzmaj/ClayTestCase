using Domain.Repositories;
using Application.Services.Interfaces;
using System.Collections.Generic;
using Application.Models;
using AutoMapper;
using System.Linq;
using Domain.Models;
using Application.Validators.Interfaces;

namespace Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly ITokenRepository _tokenRepository;
        private readonly ITokenValidator _tokenValidator;

        private readonly IMapper _mapper;

        public TokenService(ITokenRepository tokenRepository, IMapper mapper, ITokenValidator tokenValidator)
        {
            _tokenRepository = tokenRepository;
            _mapper = mapper;
            _tokenValidator = tokenValidator;
        }

        public IEnumerable<TokenModel> GetAllTokens()
        {
            var tokens = _tokenRepository.GetTokens();
            return tokens.Select(x => _mapper.Map<TokenModel>(x)).ToList();
        }

        public string AddToken(TokenModel token)
        {
            token.Validate(_tokenValidator);
            var inputModel = _mapper.Map<Token>(token);
            return _tokenRepository.Add(inputModel).ToString();
        }
    }
}
