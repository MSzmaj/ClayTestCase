using System.Collections.Generic;
using Domain.Models;

namespace Domain.Repositories
{
    public interface ILockRepository
    {
        IEnumerable<Lock> GetLocks();
        int Add(Lock inputModel);
    }
}
