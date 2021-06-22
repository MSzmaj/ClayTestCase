using System;
using Application.Validators.Interfaces;

namespace Application.Models
{
    public class LogModel
    {
        public int Id { get; set; }
        public int LockId { get; set; }
        public int UserId { get; set; }
        public int TokenId { get; set; }
        public bool Success { get; set; }
        public DateTime EntryDate { get; set; }

        public virtual void Validate(ILogValidator logValidator,
                                    IUserValidator userValidator,
                                    ITokenValidator tokenValidator,
                                    ILockValidator lockValidator) {
            
            userValidator.ValidateUserId(UserId);
            tokenValidator.ValidateTokenId(TokenId);
            lockValidator.ValidateLockId(LockId);
        }
    }
}
