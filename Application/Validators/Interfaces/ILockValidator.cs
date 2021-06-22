using Application.Models;

namespace Application.Validators.Interfaces {
    public interface ILockValidator {
        void ValidateLockId (int lockId);
    }
}