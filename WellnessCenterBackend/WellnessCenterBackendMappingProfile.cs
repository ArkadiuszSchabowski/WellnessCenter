using AutoMapper;
using WellnessCenterBackend.Database.Entities;
using WellnessCenterBackend.Models;

namespace SpaSalon
{
    public class WellnessCenterBackendMappingProfile : Profile
    {
        public WellnessCenterBackendMappingProfile()
        {
            CreateMap<CreateMassageDto, Massage>();
            CreateMap<RegisterUserDto, User>()
              .ForMember(u => u.HashPassword, options => options.MapFrom(dto => dto.Password));
            CreateMap<UpdateMassageDto, Massage>();
            CreateMap<RegisterUserDto, AdminAccountDto>();
            CreateMap<UpdateRoleDto, User>();
            CreateMap<User, UserDto>();
            CreateMap<Booking, BookingDto>();
            CreateMap<BookingDto, Booking>();
        }
    }
}
