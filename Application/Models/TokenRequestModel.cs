using System;
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

        public virtual void Validate(ILockValidator lockValidator) {
            lockValidator.Validate(new LockModel { Id = LockId });
        }
    }
}
