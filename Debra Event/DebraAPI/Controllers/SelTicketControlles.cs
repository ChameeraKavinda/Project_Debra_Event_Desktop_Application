using AutoMapper;
using DebraAPI.Data;
using DebraAPI.DTO;
using DebraAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DebraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SelTicketControlles : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISelTicketRepo _selTicketRepo;

        public SelTicketControlles(ISelTicketRepo selTicketRepo, IMapper mapper)
        {
            _selTicketRepo = selTicketRepo;
            _mapper = mapper;

        }


        [HttpPost]
        public ActionResult CreateSelTicket(SelTicketCreateDTO createDTO, int eventId)
        {
            var model = _mapper.Map<SelTicket>(createDTO);
            model.Commision = model.Price * 0.20m;//20% Commission calculate
            model.EventId= eventId;
            if (_selTicketRepo.CreateSelTicket(model))
                return Ok();
            else
                return BadRequest();
        }


        [HttpGet("event/{eventId}")]
        public ActionResult<IEnumerable<SelTicketReadDTO>> GetSelTicketsByEventId(int eventId)
        {
            var selTicket = _selTicketRepo.GetSelTicketsByEventId(eventId);
            return Ok(_mapper.Map<IEnumerable<SelTicketReadDTO>>(selTicket));
        }

        [HttpPost("{id}")]
        public ActionResult SellTicket(int id)
        {
            var selTicket = _selTicketRepo.GetSelTicket(id);
            if (selTicket != null && !selTicket.IsSold)
            {
                selTicket.IsSold = true;
                selTicket.SelDate = DateTime.Now;
                if (_selTicketRepo.UpdateSelTicket(selTicket))
                    return Ok("Ticket Sold Successfully");
                else
                    return BadRequest("Error Updating Ticket Status");
            }
            else
            {
                return NotFound("Ticket Not Found Already Sold.");
            }
        }


        [HttpGet]
        public ActionResult<IEnumerable<SelTicketReadDTO>> GetSelTicket()
        {
            var SelTickets = _selTicketRepo.GetAllSelTickets();
            return Ok(_mapper.Map<IEnumerable<SelTicketReadDTO>>(SelTickets));
        }
        [HttpPut("{id}")]
        public ActionResult UpdateSelTicket(int id, SelTicketCreateDTO selTicketUpdate)
        {
            var selTicket = _mapper.Map<SelTicket>(selTicketUpdate);
            selTicket.Id = id;
            if (_selTicketRepo.UpdateSelTicket(selTicket))
                return Ok();
            else
                return NotFound();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteSelTicket(int id)
        {
            var selTicket = _selTicketRepo.GetSelTicket(id);

            if (_selTicketRepo.DeleteSelTicket(selTicket))
                return Ok();
            else
                return NotFound();
        }
        [HttpGet("{id}", Name = "GetBysID1")]
        public ActionResult<SelTicketReadDTO> GetSelTicket(int id)
        {
            var selTicket = _selTicketRepo.GetSelTicket(id);
            if (selTicket != null)
            {
                return Ok(_mapper.Map<SelTicketReadDTO>(selTicket));
            }
            else
            {
                return NotFound();

            }
        }


    }
}
