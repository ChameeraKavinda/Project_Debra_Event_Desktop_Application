using Microsoft.AspNetCore.Mvc;
using DebraAPI.Model;
using DebraAPI.DTO;
using DebraAPI.Data;
using AutoMapper;

namespace DebraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnerController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPartnerRepo _partnerRepo;

        public PartnerController(IPartnerRepo partnerRepo, IMapper mapper)
        {
            _partnerRepo = partnerRepo;
            _mapper = mapper;
        }

        [HttpPost("Login")]
        public ActionResult<PartnerReadDTO> Login(LoginPartnerDTO loginDTO)
        {
            var partner= _partnerRepo.Login(loginDTO.Email, loginDTO.Password);
            if(partner == null)
            {
                return Unauthorized();
            }
            return Ok(_mapper.Map<PartnerReadDTO>(partner));
        }



        [HttpPost]
        public ActionResult CreatePartner(PartnerCreateDTO createDTO)
        {
            var model = _mapper.Map<Partner>(createDTO);
            if (_partnerRepo.CreatePartner(model))
                return Ok();
            else
                return BadRequest();
        }
        [HttpGet]
        public ActionResult<IEnumerable<PartnerReadDTO>> GetPartner()
        {
            var partners = _partnerRepo.GetAllPartners();
            return Ok(_mapper.Map<IEnumerable<PartnerReadDTO>>(partners));
        }
        [HttpPut("{id}")]
        public ActionResult UpdatePartner(int id, PartnerCreateDTO partnerUpdate)
        {
            var partner = _mapper.Map<Partner>(partnerUpdate);
            partner.Id = id;
            if (_partnerRepo.UpdatePartner(partner))
                return Ok();
            else
                return NotFound();
        }
        [HttpDelete("{id}")]
        public ActionResult DeletePartner(int id)
        {
            var partner = _partnerRepo.GetPartner(id);

            if (_partnerRepo.DeletePartner(partner))
                return Ok();
            else
                return NotFound();
        }
        [HttpGet("{id}", Name = "GetByID")]
        public ActionResult<PartnerReadDTO> GetPartner(int id)
        {
            var partner = _partnerRepo.GetPartner(id);
            if (partner != null)
            {
                return Ok(_mapper.Map<PartnerReadDTO>(partner));
            }
            else
            {
                return NotFound();

            }
        }
    }
}
