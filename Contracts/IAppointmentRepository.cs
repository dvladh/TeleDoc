using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IAppointmentRepository : IRepositoryBase<Appointment>
    {
        Task<List<AppointmentStatus>> GetAppointmentStatus();
        Task<AppointmentStatus> GetAppointmentStatusById(int id);
    }
}
