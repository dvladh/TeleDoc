using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class DoctorForCreationDto
    { 
        public string Specialty { get; set; }
        public string Sn { get; set; }
        public string References { get; set; }
    }
}
