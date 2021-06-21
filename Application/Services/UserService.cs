using Domain.Repositories;
using Application.Services.Interfaces;
using System.Collections.Generic;
using Application.Models;
using AutoMapper;
using System.Linq;
using Domain.Models;
using Application.Validators.Interfaces;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserValidator _userValidator;

        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper, IUserValidator userValidator)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userValidator = userValidator;
        }

        public IEnumerable<UserModel> GetAllUsers()
        {
            var users = _userRepository.GetUsers();
            return users.Select(x => _mapper.Map<UserModel>(x)).ToList();
        }

        public string AddUser(UserModel user)
        {
            user.Validate(_userValidator);
            var inputModel = _mapper.Map<User>(user);
            return _userRepository.Add(inputModel).ToString();
        }
    }
}
