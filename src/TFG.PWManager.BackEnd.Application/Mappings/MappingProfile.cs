using AutoMapper;
using TFG.PWManager.BackEnd.Application.Mappings.Resolvers;
using TFG.PWManager.BackEnd.Domain.Commons;
using TFG.PWManager.BackEnd.Domain.Models;

namespace TFG.PWManager.BackEnd.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserModel>()
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.UserRole))
                .ForMember(dest => dest.LanguageCode, opt => opt.MapFrom(src => src.Language!.Code))
                .ForMember(dest => dest.LanguageDesc, opt => opt.MapFrom(src => src.Language!.Description))
                .ReverseMap()
                .ForMember(dest => dest.IdentifierType, opt => opt.Ignore())
                .ForMember(dest => dest.UserRole, opt => opt.Ignore())
                .ForMember(dest => dest.Language, opt => opt.Ignore());

            CreateMap<UserRole, RoleModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Role!.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Role!.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Role!.Description))
                .ReverseMap();

            CreateMap<Token, TokenModel>()
                .ForMember(dest => dest.ExpiredDate, opt => opt.MapFrom<DateTimeResolver, DateTime>(src => src.ExpiredDate))
                .ForMember(dest => dest.RefreshToken, opt => opt.Ignore()).ForMember(dest => dest.RefreshToken, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(dest => dest.ExpiredDate, opt => opt.MapFrom<DateTimeResolver, string>(src => src.ExpiredDate!));

            CreateMap<TokenConfig, TokenConfigModel>()
                .ReverseMap();

            //CreateMap<Role, RoleModel>()
            //    .ForMember(dest => dest.Order, opt => opt.MapFrom(src => src.Order == 0 ? 99 : src.Order))
            //    .ReverseMap()
            //    .ForMember(dest => dest.Order, opt => opt.MapFrom(src => src.Order ?? 99));         

            CreateMap<UserKey, UserKeyModel>()
              .ReverseMap();
        }
    }
}
