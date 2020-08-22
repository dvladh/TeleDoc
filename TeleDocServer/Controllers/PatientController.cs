using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TeleDocServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public PatientController(IRepositoryWrapper _repository, UserManager<User> userManager, IMapper mapper)
        {
            this._repository = _repository;
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpGet("GetPatients")]
        public async Task<IActionResult> GetPatients()
        {
            var patientFromRepo = await _repository.Patient.FindAll().Include(p => p.User)
                .ToListAsync();

            var patient = _mapper.Map<List<PatientDto>>(patientFromRepo);

            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }

        [HttpGet("{id}", Name = "GetPatient")]
        public async Task<IActionResult> GetPatient(string id)
        {
            var patientFromRepo = await _repository.Patient.FindByCondition(p => p.Id == id).Include(p => p.User).FirstOrDefaultAsync();

            var patient = _mapper.Map<PatientDto>(patientFromRepo);

            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> CreatePatient(string id, [FromBody]PatientForCreationDto patientForCreation)
        {
            var userFromRepo = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (userFromRepo == null)
            {
                return BadRequest(new { Message = "User doesn't exist." });
            }

            var patientFromRepo = await _repository.Patient.FindByCondition(p => p.Id == id).FirstOrDefaultAsync();

            if (patientFromRepo != null)
            {
                return BadRequest(new {Message = "Patient already exist."});
            }

            var patient = _mapper.Map<Patient>(patientForCreation);
            patient.Id = id;

            _repository.Patient.Create(patient);
            _repository.SaveAsync();

            return CreatedAtRoute("GetPatient", new { id }, patient);
        }
    }
}
