using Application.Models;
using AutoMapper;
using Domain.Models;

namespace Application.TypeMappings
{
    public class UserToUserModel : Profile
    {
        public UserToUserModel()
        {
            CreateMap<User, UserModel>();
        }
    }
}
