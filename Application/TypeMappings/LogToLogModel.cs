using Application.Models;
using AutoMapper;
using Domain.Models;

namespace Application.TypeMappings
{
    public class LogToLogModel : Profile
    {
        public LogToLogModel()
        {
            CreateMap<Log, LogModel>();
        }
    }
}
