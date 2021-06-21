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

        private readonly IMapper _mapper;

        public LockService(ILockRepository lockRepository, IMapper mapper, ILockValidator lockValidator)
        {
            _lockRepository = lockRepository;
            _mapper = mapper;
            _lockValidator = lockValidator;
        }

        public IEnumerable<LockModel> GetAllLocks()
        {
            var locks = _lockRepository.GetLocks();
            return locks.Select(x => _mapper.Map<LockModel>(x)).ToList();
        }

        public string AddLock(LockModel lockModel)
        {
            lockModel.Validate(_lockValidator);
            var inputModel = _mapper.Map<Lock>(lockModel);
            return _lockRepository.Add(inputModel).ToString();
        }
    }
}
