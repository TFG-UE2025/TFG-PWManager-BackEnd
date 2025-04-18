using AutoMapper;
using TFG.PWManager.BackEnd.Application.Mappings.Resolvers;
using TFG.PWManager.BackEnd.Domain.Commons;
using TFG.PWManager.BackEnd.Domain.Entities;
using TFG.PWManager.BackEnd.Domain.Models;

namespace TFG.PWManager.BackEnd.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserModel>()
                .ForMember(dest => dest.LanguageCode, opt => opt.MapFrom(src => src.Language!.Code))
                .ReverseMap()
                .ForMember(dest => dest.Language, opt => opt.Ignore());

            CreateMap<Token, TokenModel>()
                .ForMember(dest => dest.ExpiredDate, opt => opt.MapFrom<DateTimeResolver, DateTime>(src => src.ExpiredDate))
                .ForMember(dest => dest.RefreshToken, opt => opt.Ignore()).ForMember(dest => dest.RefreshToken, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(dest => dest.ExpiredDate, opt => opt.MapFrom<DateTimeResolver, string>(src => src.ExpiredDate!));

            CreateMap<TokenConfig, TokenConfigModel>()
                .ReverseMap();      
        }
    }
}
