using System;
using System.Collections.Generic;
using System.Text;
using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly RepositoryContext _repoContext;
        private IDoctorRepository _doctor;
        private IPatientRepository _patient;
        private IAppointmentRepository _appointment;

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public IDoctorRepository Doctor
        {
            get
            {
                if (_doctor == null)
                {
                    _doctor = new DoctorRepository(_repoContext);
                }

                return _doctor;
            }
        }

        public IPatientRepository Patient
        {
            get
            {
                if (_patient == null)
                {
                    _patient = new PatientRepository(_repoContext);
                }

                return _patient;
            }
        }

        public IAppointmentRepository Appointment
        {
            get
            {
                if (_appointment == null)
                {
                    _appointment = new AppointmentRepository(_repoContext);
                }

                return _appointment;
            }
        }

        public void Save()
        {
           _repoContext.SaveChanges();
        }

        public void SaveAsync()
        {
            _repoContext.SaveChangesAsync();
        }
    }
}
