using Application.Models;
using Application.Validators.Interfaces;
using Common.Exceptions;
using Domain.Repositories;

namespace Application.Validators {
    public class TokenValidator : ITokenValidator {
        private readonly ITokenRepository _tokenRepository;

        public TokenValidator (ITokenRepository tokenRepository) {
            _tokenRepository = tokenRepository;
        }

        public void ValidateTokenId (int tokenId) {
            var token = _tokenRepository.FindById(tokenId);
            if (token == null) {
                throw new ModelValidationException($"Token with id {tokenId} does not exist");
            }
        }
    }
}