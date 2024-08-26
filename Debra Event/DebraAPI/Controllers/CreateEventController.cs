using AutoMapper;
using DebraAPI.Data;
using DebraAPI.DTO;
using DebraAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace DebraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateEventController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICreateEventRepo _createEventRepo;

        public CreateEventController(ICreateEventRepo createEventRepo, IMapper mapper)
        {
            _createEventRepo = createEventRepo;
            _mapper = mapper;
        }


        [HttpPost]
        public ActionResult CreateCreateEvent(CreateEventCreateDTO createDTO, int partnerId)
        {
            var model = _mapper.Map<CreateEvent>(createDTO);
            model.PartnerId = partnerId;
            if (_createEventRepo.CreateCreateEvent(model))
                return Ok();
            else
                return BadRequest();
        }

        [HttpGet("partner/{partnerId}")]
        public ActionResult<IEnumerable<CreateEventReadDTO>> GetEventsByPartnerId(int partnerId)
        {
            var createEvents = _createEventRepo.GetEventsByPartnerId(partnerId);
            return Ok(_mapper.Map<IEnumerable<CreateEventReadDTO>>(createEvents));
        }






        [HttpGet]
        public ActionResult<IEnumerable<CreateEventReadDTO>> GetCreateEvent()
        {
            var createEvents = _createEventRepo.GetAllCreateEvents();
            return Ok(_mapper.Map<IEnumerable<CreateEventReadDTO>>(createEvents));
        }
        [HttpPut("{id}")]
        public ActionResult UpdateCreateEvent(int id, CreateEventCreateDTO createEventsUpdate)
        {
            var createEvent = _mapper.Map<CreateEvent>(createEventsUpdate);
            createEvent.Id = id;

            try
            {
                if (_createEventRepo.UpdateCreateEvent(createEvent))
                    return Ok();
            }
            
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception )
            {
                return StatusCode(500, "An error Updating the event");
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCreateEvent(int id)
        {
            var createEvent = _createEventRepo.GetCreateEvent(id);

            if (_createEventRepo.DeleteCreateEvent(createEvent))
                return Ok();
            else
                return NotFound();
        }



        [HttpGet("{id}", Name = "GetsByID2")]
        public ActionResult<SelTicketReadDTO> GetCreateEvent(int id)
        {
            var createEvent = _createEventRepo.GetCreateEvent(id);
            if (createEvent != null)
            {
                return Ok(_mapper.Map<CreateEventReadDTO>(createEvent));
            }
            else
            {
                return NotFound();

            }
        }
    }
}

