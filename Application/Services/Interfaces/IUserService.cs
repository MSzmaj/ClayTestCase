using System.Collections.Generic;
using Application.Models;

namespace Application.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserModel> GetAllUsers();
        string AddUser(UserModel user);
    }
}
