using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Entities.Dtos;
using Entities.Models;

namespace Entities.Profiles
{
    public class DoctorProfile : Profile
    {
        public DoctorProfile()
        {
            CreateMap<Doctor, DoctorForCreationDto>().ReverseMap();
            CreateMap<Doctor, DoctorDto>().ReverseMap();
        }
    }
}
