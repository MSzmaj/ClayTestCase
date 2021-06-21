using Application.Models;
using Application.Validators.Interfaces;

namespace Application.Validators {
    public class LockValidator : ILockValidator {
        public string Validate (LockModel lockModel) {
            return "test";
        }
    }
}