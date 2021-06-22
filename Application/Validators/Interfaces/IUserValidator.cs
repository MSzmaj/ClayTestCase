using Application.Models;

namespace Application.Validators.Interfaces {
    public interface IUserValidator {
        string Validate (UserModel user);
        void ValidateClaimId(string modelId, string claimId);
    }
}