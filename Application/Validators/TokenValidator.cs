using Application.Models;
using Application.Validators.Interfaces;

namespace Application.Validators {
    public class TokenValidator : ITokenValidator {
        public string Validate (TokenModel token) {
            return "test";
        }
    }
}