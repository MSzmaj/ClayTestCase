using Application.Models;
using AutoMapper;
using Domain.Models;

namespace Application.TypeMappings
{
    public class LockModelToLock : Profile
    {
        public LockModelToLock()
        {
            CreateMap<LockModel, Lock>();
        }
    }
}
