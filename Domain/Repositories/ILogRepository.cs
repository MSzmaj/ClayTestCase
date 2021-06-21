using System.Collections.Generic;
using Domain.Models;

namespace Domain.Repositories
{
    public interface ILogRepository
    {
        IEnumerable<Log> GetLogs();
        int Add(Log inputModel);
    }
}
