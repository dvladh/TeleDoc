using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Entities.Dtos
{
    public class AppointmentDto
    {
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int Duration { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public AppointmentStatus Status { get; set; }
    }
}
