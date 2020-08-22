using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("patients")]
    public class Patient
    {
        [ForeignKey(nameof(User))]
        public string Id { get; set; }
        public int Age { get; set; }
        public char Sex { get; set; }

        [Column(TypeName = "decimal(16, 2)")]
        public decimal Height { get; set; }

        [Column(TypeName = "decimal(16, 2)")]
        public decimal Weight { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string BloodType { get; set; }
        public User User { get; set; }
    }
}