using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Entities.Dtos;
using Entities.Models;

namespace Entities.Profiles
{
    public class PatientProfile : Profile
    {
        public PatientProfile()
        {
            CreateMap<Patient, PatientForCreationDto>().ReverseMap();
            CreateMap<Patient, PatientDto>().ReverseMap();
        }
    }
}
