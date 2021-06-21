using System.Collections.Generic;
using Domain.Models;

namespace Domain.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        int Add(User inputModel);
    }
}
