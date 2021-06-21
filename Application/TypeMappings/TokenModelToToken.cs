using Application.Models;
using AutoMapper;
using Domain.Models;

namespace Application.TypeMappings
{
    public class TokenModelToToken : Profile
    {
        public TokenModelToToken()
        {
            CreateMap<TokenModel, Token>();
        }
    }
}
