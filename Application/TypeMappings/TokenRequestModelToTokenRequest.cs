using Application.Models;
using AutoMapper;
using Domain.Models;

namespace Application.TypeMappings
{
    public class TokenRequestModelToTokenRequest : Profile
    {
        public TokenRequestModelToTokenRequest()
        {
            CreateMap<TokenRequestModel, TokenRequest>();
        }
    }
}
