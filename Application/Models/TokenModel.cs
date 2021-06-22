using System;
using System.ComponentModel.DataAnnotations;
using Application.Validators.Interfaces;

namespace Application.Models
{
    public class TokenModel
    {
        public int Id { get; set; }
        [Required]
        public DateTime Expiry { get; set; }
        [Required]
        public int OwnerId { get; set; }
        [Required]
        public int LockId { get; set; }

        public virtual void Validate(ITokenValidator tokenValidator,
                                        IUserValidator userValidator,
                                        ILockValidator lockValidator) {
            tokenValidator.ValidateTokenId(Id);
            userValidator.ValidateUserId(OwnerId);
            lockValidator.ValidateLockId(LockId);
        }
    }
}
