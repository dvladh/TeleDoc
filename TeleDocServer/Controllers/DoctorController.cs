using AutoMapper;
using Contracts;
using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TeleDocServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public DoctorController(IRepositoryWrapper _repository, UserManager<User> userManager, IMapper mapper)
        {
            this._repository = _repository;
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpGet("GetDoctors")]
        public async Task<IActionResult> GetDoctors()
        {
            var doctorFromRepo = await _repository.Doctor.FindAll().Include(p => p.User)
                .ToListAsync();

            var doctor = _mapper.Map<List<DoctorDto>>(doctorFromRepo);

            if (doctor == null)
            {
                return NotFound();
            }

            return Ok(doctor);
        }

        [HttpGet("{id}", Name = "GetDoctor")]
        public async Task<IActionResult> GetDoctor(string id)
        {
            var doctorFromRepo = await _repository.Doctor.FindByCondition(p => p.Id == id).Include(p => p.User).FirstOrDefaultAsync();

            var doctor = _mapper.Map<DoctorDto>(doctorFromRepo);

            if (doctor == null)
            {
                return NotFound();
            }

            return Ok(doctor);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> CreateDoctor(string id, [FromBody] DoctorForCreationDto doctorForCreation)
        {
            var userFromRepo = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (userFromRepo == null)
            {
                return BadRequest(new { Message = "User doesn't exist." });
            }

            var doctorFromRepo = await _repository.Doctor.FindByCondition(p => p.Id == id).FirstOrDefaultAsync();

            if (doctorFromRepo != null)
            {
                return BadRequest(new { Message = "Doctor already exist." });
            }

            var doctor = _mapper.Map<Doctor>(doctorForCreation);
            doctor.Id = id;

            _repository.Doctor.Create(doctor);
            _repository.SaveAsync();

            return CreatedAtRoute("GetDoctor", new { id }, doctor);
        }
    }
}
