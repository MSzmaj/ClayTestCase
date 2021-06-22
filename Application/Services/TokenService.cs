using Domain.Repositories;
using Application.Services.Interfaces;
using System.Collections.Generic;
using Application.Models;
using AutoMapper;
using System.Linq;
using Domain.Models;
using Application.Validators.Interfaces;
using Common;
using System;

namespace Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly ITokenRepository _tokenRepository;
        private readonly ILockValidator _lockValidator;
        private readonly IUserValidator _userValidator;

        private readonly IMapper _mapper;

        public TokenService(ITokenRepository tokenRepository, 
                            IMapper mapper, 
                            ILockValidator lockValidator,
                            IUserValidator userValidator)
        {
            _tokenRepository = tokenRepository;
            _mapper = mapper;
            _lockValidator = lockValidator;
            _userValidator = userValidator;
        }

        public IEnumerable<TokenModel> GetAllTokens()
        {
            var tokens = _tokenRepository.GetTokens();
            return tokens.Select(x => _mapper.Map<TokenModel>(x)).ToList();
        }

        public TokenReturnModel AddToken(TokenRequestModel token)
        {
            token.Validate(_lockValidator, _userValidator);
            var inputModel = _mapper.Map<TokenRequest>(token);
            var tokenId = _tokenRepository.Add(inputModel);

            var data = new {
                TokenId = tokenId,
                LockId = token.LockId,
                OwnerId = token.OwnerId,
                Expiry = DateTime.Now.AddDays(1)
            };

            var returnToken = new TokenReturnModel {
                TokenId = tokenId,
                Token = CryptoUtil.Encrypt(data.ToString(), token.PublicKey)
            };

            return returnToken;
        }
    }
}
