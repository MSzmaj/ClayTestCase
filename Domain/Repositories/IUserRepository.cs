using System.Collections.Generic;
using Domain.Models;

namespace Domain.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        int Add(User inputModel);
        User FindByCriteria(User user);
        User FindById(int id);

        void Delete(int id);
    }
}
