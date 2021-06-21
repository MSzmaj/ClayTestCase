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

        private readonly IMapper _mapper;

        public LogService(ILogRepository logRepository, IMapper mapper, ILogValidator logValidator)
        {
            _logRepository = logRepository;
            _mapper = mapper;
            _logValidator = logValidator;
        }

        public IEnumerable<LogModel> GetAllLogs()
        {
            var logs = _logRepository.GetLogs();
            return logs.Select(x => _mapper.Map<LogModel>(x)).ToList();
        }

        public string AddLog(LogModel log)
        {
            log.Validate(_logValidator);
            var inputModel = _mapper.Map<Log>(log);
            return _logRepository.Add(inputModel).ToString();
        }
    }
}
