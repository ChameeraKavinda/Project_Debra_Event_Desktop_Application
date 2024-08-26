using Microsoft.AspNetCore.Mvc;
using DebraAPI.Model;
using DebraAPI.DTO;
using DebraAPI.Data;
using AutoMapper;

namespace DebraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DebraAdminController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IDebraAdminRepo _debraAdminRepo;

        public DebraAdminController(IDebraAdminRepo debraAdminRepo, IMapper mapper)
        {
            _debraAdminRepo = debraAdminRepo;
            _mapper = mapper;
        }

        [HttpPost("Login")]
        public ActionResult<DebraAdminReadDTO> DebraAdminLogin(LogingDebraAdminDTO loginDTO)
        {
            var debraAdmin = _debraAdminRepo.DebraAdminLogin(loginDTO.AdminEmail, loginDTO.AdminPassword);
            if (debraAdmin == null)
            {
                return Unauthorized();
            }
            return Ok(_mapper.Map<DebraAdminReadDTO>(debraAdmin));
        }



        [HttpPost]
        public ActionResult CreateDebraAdmin(DebraAdminCreateDTO createDTO)
        {
            var model = _mapper.Map<DebraAdmin>(createDTO);
            if (_debraAdminRepo.CreateDebraAdmin(model))
                return Ok();
            else
                return BadRequest();
        }
        [HttpGet]
        public ActionResult<IEnumerable<DebraAdminReadDTO>> GetDebraAdmin()
        {
            var debraAdmins = _debraAdminRepo.GetAllDebraAdmins();
            return Ok(_mapper.Map<IEnumerable<DebraAdminReadDTO>>(debraAdmins));
        }
        [HttpPut("{id}")]
        public ActionResult UpdateDebraAdmin(int id, DebraAdminCreateDTO debraAdminUpdate)
        {
            var debraAdmin = _mapper.Map<DebraAdmin>(debraAdminUpdate);
            debraAdmin.AdminId = id;
            if (_debraAdminRepo.UpdateDebraAdmin(debraAdmin))
                return Ok();
            else
                return NotFound();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteDebraAdmin(int id)
        {
            var debraAdmin = _debraAdminRepo.GetDebraAdmin(id);

            if (_debraAdminRepo.DeleteDebraAdmin(debraAdmin))
                return Ok();
            else
                return NotFound();
        }
        [HttpGet("{id}", Name = "GetByID1")]
        public ActionResult<DebraAdminReadDTO> GetDebraAdmin(int id)
        {
            var debraAdmin = _debraAdminRepo.GetDebraAdmin(id);
            if (debraAdmin != null)
            {
                return Ok(_mapper.Map<DebraAdminReadDTO>(debraAdmin));
            }
            else
            {
                return NotFound();

            }
        }
    }
}
