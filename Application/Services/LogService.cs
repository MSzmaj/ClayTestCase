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
    public class LogService : ILogService
    {
        private readonly ILogRepository _logRepository;
        private readonly ILogValidator _logValidator;
        private readonly IUserValidator _userValidator;
        private readonly ITokenValidator _tokenValidator;
        private readonly ILockValidator _lockValidator;

        private readonly IMapper _mapper;

        public LogService(ILogRepository logRepository, 
                            IMapper mapper, 
                            ILogValidator logValidator,
                            IUserValidator userValidator,
                            ITokenValidator tokenValidator,
                            ILockValidator lockValidator)
        {
            _logRepository = logRepository;
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
            var inputModel = _mapper.Map<Log>(log);
            return _logRepository.Add(inputModel).ToString();
        }
    }
}
