using AutoMapper;
using DebraAPI.Model;
using DebraAPI.DTO;
namespace DebraAPI.Profiles
{
    public class SelTicketProfile : Profile
    {
        public SelTicketProfile()
        {
            CreateMap<SelTicket, SelTicketReadDTO>();
            CreateMap<SelTicketCreateDTO, SelTicket>();

        }
    }
}
