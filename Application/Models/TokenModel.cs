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

        public virtual void Validate(ITokenValidator tokenValidator) {
            tokenValidator.Validate(this);
        }
    }
}
