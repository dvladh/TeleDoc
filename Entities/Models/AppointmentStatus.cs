using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("appointmentstatus")]
    public class AppointmentStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}