using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Entities.Models;

namespace Entities.Dtos
{
    public class AppointmentForCreationDto
    {
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
    }
}
