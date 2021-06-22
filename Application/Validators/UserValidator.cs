using System;
using Application.Models;
using Application.Validators.Interfaces;
using AutoMapper;
using Common.Exceptions;
using Domain.Models;
using Domain.Repositories;

namespace Application.Validators {
    public class UserValidator : IUserValidator {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserValidator (IUserRepository userRepository, IMapper mapper) {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public string Validate (UserModel user) {
            return string.Empty;
        }

        public void ValidateExistingUser (UserModel user) {
            if (string.IsNullOrEmpty(user.UserName)) {
                throw new ModelValidationException("Username is empty");
            }

            var userId = _userRepository.FindByCriteria(_mapper.Map<User>(user));
            if (userId != null) {
                throw new ModelValidationException("User already exists");
            }
        }

        public void ValidateUserId (int userId) {
            var user = _userRepository.FindById(userId);
            if (user == null) {
                throw new ModelValidationException($"User with id {userId} does not exist");
            }
        }

        public void ValidateClaimId(string modelId, string claimId)
        {
            if (modelId == claimId)
            {
                throw new UnauthorizedAccessException();
            }
        }
    }
}