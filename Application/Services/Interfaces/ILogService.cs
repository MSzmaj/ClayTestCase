using System.Collections.Generic;
using Application.Models;

namespace Application.Services.Interfaces
{
    public interface ILogService
    {
        IEnumerable<LogModel> GetAllLogs();
        string AddLog(LogModel log);
        IEnumerable<LogModel> GetLockLogs(LogModel log);
    }
}
