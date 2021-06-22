using Application.Models;
using AutoMapper;
using Domain.Models;

namespace Application.TypeMappings
{
    public class LockToLockModel : Profile
    {
        public LockToLockModel()
        {
            CreateMap<Lock, LockModel>();
        }
    }
}
