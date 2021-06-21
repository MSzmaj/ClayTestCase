using System.Collections.Generic;
using Application.Models;

namespace Application.Services.Interfaces
{
    public interface ILockService
    {
        IEnumerable<LockModel> GetAllLocks();
        string AddLock(LockModel lockModel);
    }
}
