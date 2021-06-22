using System;
using Application.Models;
using Application.Validators.Interfaces;

namespace Application.Validators {
    public class UserValidator : IUserValidator {
        public string Validate (UserModel user) {
            return "test";
        }

        public void ValidateClaimId(string modelId, string claimId)
        {
            if (modelId == claimId)
            {
                throw new UnauthorizedAccessException();
            }
        }
    }
}