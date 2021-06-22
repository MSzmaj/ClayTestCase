using Application.Models;

namespace Application.Validators.Interfaces {
    public interface ITokenValidator {
       void ValidateTokenId (int tokenId);
    }
}