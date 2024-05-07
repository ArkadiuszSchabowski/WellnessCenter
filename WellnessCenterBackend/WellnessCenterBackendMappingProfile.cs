using AutoMapper;
using WellnessCenterBackend.Entities;
using WellnessCenterBackend.Models;

namespace SpaSalon
{
    public class WellnessCenterBackendMappingProfile : Profile
    {
        public WellnessCenterBackendMappingProfile()
        {
            CreateMap<CreateMassageDto, MassageName>();
            CreateMap<RegisterUserDto, User>()
              .ForMember(u => u.HashPassword, options => options.MapFrom(dto => dto.Password));
            CreateMap<UpdateMassageDto, MassageName>();
            CreateMap<RegisterUserDto, AdminAccountDto>();
            CreateMap<UpdateRoleDto, User>();
            CreateMap<User, UserDto>();
        }
    }
}
