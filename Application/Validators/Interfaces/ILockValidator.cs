using Application.Models;

namespace Application.Validators.Interfaces {
    public interface ILockValidator {
        string Validate (LockModel lockModel);
    }
}