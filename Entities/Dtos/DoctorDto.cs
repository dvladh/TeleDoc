using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class DoctorDto
    {
        public string Specialty { get; set; }
        public string Sn { get; set; }
        public string References { get; set; }
        public UserDto User { get; set; }
    }
}
