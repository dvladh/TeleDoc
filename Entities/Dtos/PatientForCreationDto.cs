using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class PatientForCreationDto
    {
        public int Age { get; set; }
        public char Sex { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string BloodType { get; set; }
    }
}
