using AutoMapper;
using DebraAPI.Model;
using DebraAPI.DTO;
namespace DebraAPI.Profiles
{
    public class CreateEventProfile : Profile
    {
        public CreateEventProfile()
        {
            CreateMap<CreateEvent, CreateEventReadDTO>();
            CreateMap<CreateEventCreateDTO, CreateEvent>();

        }
    }
}
