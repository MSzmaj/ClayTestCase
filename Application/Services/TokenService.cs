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
        private readonly ILockValidator _lockValidator;

        private readonly IMapper _mapper;

        public TokenService(ITokenRepository tokenRepository, 
                            IMapper mapper, 
                            ITokenValidator 
                            tokenValidator, 
                            ILockValidator lockValidator)
        {
            _tokenRepository = tokenRepository;
            _mapper = mapper;
            _tokenValidator = tokenValidator;
            _lockValidator = lockValidator;
        }

        public IEnumerable<TokenModel> GetAllTokens()
        {
            var tokens = _tokenRepository.GetTokens();
            return tokens.Select(x => _mapper.Map<TokenModel>(x)).ToList();
        }

        public string AddToken(TokenRequestModel token)
        {
            token.Validate(_lockValidator);
            var inputModel = _mapper.Map<TokenRequest>(token);
            var tokenId = _tokenRepository.Add(inputModel).ToString();
            var bytes = System.Text.Encoding.UTF8.GetBytes(tokenId);
            return System.Convert.ToBase64String(bytes);
        }
    }
}
