using Application.Models;
using AutoMapper;
using Domain.Models;

namespace Application.TypeMappings
{
    public class TokenToTokenModel : Profile
    {
        public TokenToTokenModel()
        {
            CreateMap<Token, TokenModel>();
        }
    }
}
