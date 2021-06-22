using Application.Validators.Interfaces;

namespace Application.Models
{
    public class LockModel
    {
        public int Id { get; set; }

        public int OwnerId { get; set; }

        public virtual void Validate(ILockValidator lockValidator,
                                    IUserValidator userValidator) {
            lockValidator.ValidateLockId(Id);
            userValidator.ValidateUserId(OwnerId);
        }
    }
}
