using Domain.Repositories;
using Application.Services.Interfaces;
using System.Collections.Generic;
using Application.Models;
using AutoMapper;
using System.Linq;
using System;
using Domain.Models;
using Application.Validators.Interfaces;

namespace Application.Services
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _logRepository;
        private readonly ILockRepository _lockRepository;
        private readonly ILogValidator _logValidator;
        private readonly IUserValidator _userValidator;
        private readonly ITokenValidator _tokenValidator;
        private readonly ILockValidator _lockValidator;

        private readonly IMapper _mapper;

        public LogService(ILogRepository logRepository, 
                            ILockRepository lockRepository,
                            IMapper mapper, 
                            ILogValidator logValidator,
                            IUserValidator userValidator,
                            ITokenValidator tokenValidator,
                            ILockValidator lockValidator)
        {
            _logRepository = logRepository;
            _lockRepository = lockRepository;
            _mapper = mapper;
            _logValidator = logValidator;
            _userValidator = userValidator;
            _tokenValidator = tokenValidator;
            _lockValidator = lockValidator;
        }

        public IEnumerable<LogModel> GetAllLogs()
        {
            var logs = _logRepository.GetLogs();
            return logs.Select(x => _mapper.Map<LogModel>(x)).ToList();
        }

        public string AddLog(LogModel log)
        {
            log.Validate(_logValidator, _userValidator, _tokenValidator, _lockValidator);
            _tokenValidator.ValidateOwner(log.TokenId, log.UserId);
            var inputModel = _mapper.Map<Log>(log);
            return _logRepository.Add(inputModel).ToString();
        }

        public IEnumerable<LogModel> GetLockLogs(LogModel log) {
            _lockValidator.ValidateLockId(log.LockId);
            var lockModel = _lockRepository.FindById(log.LockId);

            if (lockModel == null) {
                throw new KeyNotFoundException($"Lock with id {log.LockId} not found");
            }

            if (lockModel.OwnerId != log.UserId) {
                throw new UnauthorizedAccessException($"User does not have access to lock ({log.LockId}) logs");
            }

            var logs = _logRepository.GetLogs().ToList();
            logs.RemoveAll(x => x.LockId != log.LockId);
            return logs.Select(x => _mapper.Map<LogModel>(x)).ToList();
        }
    }
}
