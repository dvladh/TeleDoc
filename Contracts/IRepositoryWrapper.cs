using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IPatientRepository Patient { get; }
        IDoctorRepository Doctor { get;  }
        IAppointmentRepository Appointment { get; }
        void Save();
        void SaveAsync();
    }
}
