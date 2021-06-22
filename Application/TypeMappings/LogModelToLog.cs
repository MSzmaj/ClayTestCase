using Application.Models;
using AutoMapper;
using Domain.Models;

namespace Application.TypeMappings
{
    public class LogModelToLog : Profile
    {
        public LogModelToLog()
        {
            CreateMap<LogModel, Log>();
        }
    }
}
