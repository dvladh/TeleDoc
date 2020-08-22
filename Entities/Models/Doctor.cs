using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("doctors")]
    public class Doctor
    {
        [ForeignKey(nameof(User))]
        public string Id { get; set; }
        public string Specialty { get; set; }
        public string Sn { get; set; }
        public string References { get; set; }
        public User User { get; set; }
    }
}