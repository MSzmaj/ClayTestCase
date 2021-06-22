using Application.Models;
using AutoMapper;
using Domain.Models;

namespace Application.TypeMappings
{
    public class UserModelToUser : Profile
    {
        public UserModelToUser()
        {
            CreateMap<UserModel, User>();
        }
    }
}
