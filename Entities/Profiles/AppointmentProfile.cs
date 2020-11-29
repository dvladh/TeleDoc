using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Entities.Dtos;
using Entities.Models;

namespace Entities.Profiles
{
    public class AppointmentProfile : Profile
    {
        public AppointmentProfile()
        {
            CreateMap<Appointment, AppointmentDto>().ReverseMap();
            CreateMap<Appointment, AppointmentForCreationDto>().ReverseMap();
        }
    }
}
