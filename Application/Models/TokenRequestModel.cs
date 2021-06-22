using System.ComponentModel.DataAnnotations;
using System.Text;
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

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append($"LockId: {LockId}, ");
            sb.Append($"PublicKey: {PublicKey}, ");
            sb.Append($"OwnerId: {OwnerId}");

            return sb.ToString();
        }
    }
}
