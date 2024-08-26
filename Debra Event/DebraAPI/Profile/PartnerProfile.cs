using AutoMapper;
using DebraAPI.Model;
using DebraAPI.DTO;
namespace DebraAPI.Profiles
{
    public class PartnerProfile : Profile
    {
        public PartnerProfile()
        {
            CreateMap<Partner, PartnerReadDTO>();
            CreateMap<PartnerCreateDTO, Partner>();

        }
    }
}
