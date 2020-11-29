using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TeleDocServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public AppointmentController(IRepositoryWrapper repository, UserManager<User> userManager, IMapper mapper)
        {
            _repository = repository;
            _userManager = userManager;
            _mapper = mapper;

        }

        [HttpGet("{patientId}/{doctorId}", Name = "GetAppointment")]
        public async Task<IActionResult> GetAppointment(string patientId, string doctorId)
        {
            var appointmentsFromDb = await _repository.Appointment
                    .FindByCondition(a => a.Doctor.Id == doctorId && 
                                              a.Patient.Id == patientId)
                    .Include(d => d.Doctor)
                    .Include(p => p.Patient)
                    .ToListAsync();

            if (appointmentsFromDb == null)
                return NotFound();

            var appointments = _mapper.Map<List<AppointmentDto>>(appointmentsFromDb);
            
            
            return Ok(appointments);
        }

        [HttpGet("{patientId}", Name = "GetAllPatientAppointments")]
        public async Task<IActionResult> GetAllPatientAppointments(string patientId)
        {
            var appointmentsFromDb = await _repository.Appointment
                    .FindByCondition(a => a.Patient.Id == patientId)
                    .Include(d => d.Doctor)
                    .Include(p => p.Patient)
                    .ToListAsync();

            var appointments = _mapper.Map<AppointmentDto>(appointmentsFromDb);

            return Ok(appointments);
        }

        [HttpGet("{doctorId}", Name = "GetAllDoctorAppointments")]
        public async Task<IActionResult> GetAllDoctorAppointments(string doctorId)
        {
            var appointmentsFromDb = await _repository.Appointment
                .FindByCondition(a => a.Doctor.Id == doctorId)
                .Include(d => d.Doctor)
                .Include(p => p.Patient)
                .ToListAsync();

            var appointments = _mapper.Map<AppointmentDto>(appointmentsFromDb);

            return Ok(appointments);
        }

        [HttpPost("{patientId}/{doctorId}", Name = "CreateAppointment")]
        public async Task<ActionResult> CreateAppointment(string patientId, string doctorId,
            [FromBody] AppointmentForCreationDto appointmentForCreationDto)
        {
            var patientFromDb = await _repository.Patient.FindByCondition(p => p.Id == patientId).FirstOrDefaultAsync();
            var doctorFromDb = await _repository.Doctor.FindByCondition(d => d.Id == doctorId).FirstOrDefaultAsync();
            var appointmentStatusFromDb = await _repository.Appointment.GetAppointmentStatusById(appointmentForCreationDto.StatusId);

            if (patientFromDb == null)
                return BadRequest("Patient not found!");

            if (doctorFromDb == null)
                return BadRequest("Doctor not found!");

            if (appointmentStatusFromDb == null)
                return BadRequest("Appointment status not found!");

            var appointment = _mapper.Map<Appointment>(appointmentForCreationDto);

            appointment.PatientId = patientFromDb.Id;
            appointment.DoctorId = doctorFromDb.Id;
            appointment.StatusId = appointmentStatusFromDb.Id;

            _repository.Appointment.Create(appointment);
            _repository.SaveAsync();

            return CreatedAtRoute("GetAppointment", new { patientId, doctorId }, appointment );
        }

        [HttpGet("GetAppointmentStatus")]
        public async Task<IActionResult> GetAppointmentStatus()
        {
            var result = await _repository.Appointment.GetAppointmentStatus();

            if (result == null)
                NotFound();

            return Ok(result);
        }
    }
}
