using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Entities.Dtos;
using Entities.Models;

namespace Entities.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserRegistrationDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
