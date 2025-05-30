using AutoMapper;
using Entity.Dtos;
using Entity.Dtos.RolFormPermission;
using Entity.Dtos.User;
using Entity.Dtos.UserRol;
using Entity.Model;

namespace Helper.autoMapper
{
    public class MapeoObject : Profile
    {
        public MapeoObject()
        {
            CreateMap<Person, PersonDto>().ReverseMap();

            CreateMap<User, UserDto>()
                 .ForMember(dest => dest.PersonName, opt => opt.MapFrom(src => src.Person.Name))
                 .ReverseMap()
                 .ForPath(dest => dest.Person.Name, opt => opt.Ignore())
                 .ForPath(dest => dest.Id, opt => opt.Ignore());

            CreateMap<RolFormPermission, RolFormPermissionDto>()
                .ForMember(dest => dest.RolName, opt => opt.MapFrom(src => src.Rol.Name))
                 .ForMember(dest => dest.FormName, opt => opt.MapFrom(src => src.Form.Name))
                 .ForMember(dest => dest.PermissionName, opt => opt.MapFrom(src => src.Permission.Name));

            CreateMap<UserRol, UserRolDto>()
               .ForMember(dest => dest.NameUser, opt => opt.MapFrom(src => src.User.UserName))
               .ForMember(dest => dest.RolName, opt => opt.MapFrom(src => src.Rol.Name));



            CreateMap<UserRol, UserRolCreateDtos>().ReverseMap();
            CreateMap<RolFormPermission, RolFormPermissionCreateDto>().ReverseMap();
        }
    }
}
