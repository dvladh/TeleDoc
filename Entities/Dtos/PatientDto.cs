using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;

namespace Entities.Dtos
{
    public class PatientDto
    {
        public int Age { get; set; }
        public char Sex { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string BloodType { get; set; }
        public UserDto User { get; set; }
    }
}
