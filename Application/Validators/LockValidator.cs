using Application.Models;
using Application.Validators.Interfaces;
using Common.Exceptions;
using Domain.Repositories;

namespace Application.Validators {
    public class LockValidator : ILockValidator {
        private readonly ILockRepository _lockRepository;

        public LockValidator(ILockRepository lockRepository) {
            _lockRepository = lockRepository;
        }
        public void ValidateLockId (int lockId) {
            var result = _lockRepository.FindById(lockId);
            if (result == null) {
                throw new ModelValidationException($"Lock with id {lockId} does not exist");
            }
        }
    }
}