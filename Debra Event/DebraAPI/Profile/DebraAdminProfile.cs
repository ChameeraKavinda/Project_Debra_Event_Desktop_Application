using AutoMapper;
using DebraAPI.Model;
using DebraAPI.DTO;
namespace DebraAPI.Profiles
{
    public class DebraAdminProfile : Profile
    {
        public DebraAdminProfile()
        {
            CreateMap<DebraAdmin, DebraAdminReadDTO>();
            CreateMap<DebraAdminCreateDTO, DebraAdmin>();

        }
    }
}
