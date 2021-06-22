using System.ComponentModel.DataAnnotations;
using Application.Validators.Interfaces;

namespace Application.Models
{
    public class TokenRequestModel
    {
        [Required]
        public int LockId { get; set; }
        [Required]
        public string PublicKey { get; set; }
        [Required]
        public int OwnerId { get; set; }

        public virtual void Validate(ILockValidator lockValidator, IUserValidator userValidator) {
            lockValidator.ValidateLockId(LockId);
            userValidator.ValidateUserId(OwnerId);
        }
    }
}
