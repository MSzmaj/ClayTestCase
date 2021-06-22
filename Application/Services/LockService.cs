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
    public class LockService : ILockService
    {
        private readonly ILockRepository _lockRepository;
        private readonly ILockValidator _lockValidator;
        private readonly IUserValidator _userValidator;

        private readonly IMapper _mapper;

        public LockService(ILockRepository lockRepository, 
                            IMapper mapper, 
                            ILockValidator lockValidator,
                            IUserValidator userValidator)
        {
            _lockRepository = lockRepository;
            _mapper = mapper;
            _lockValidator = lockValidator;
            _userValidator = userValidator;
        }

        public IEnumerable<LockModel> GetAllLocks()
        {
            var locks = _lockRepository.GetLocks();
            return locks.Select(x => _mapper.Map<LockModel>(x)).ToList();
        }

        public string AddLock(LockModel lockModel)
        {
            _userValidator.ValidateUserId(lockModel.OwnerId);
            var inputModel = _mapper.Map<Lock>(lockModel);
            return _lockRepository.Add(inputModel).ToString();
        }
    }
}
