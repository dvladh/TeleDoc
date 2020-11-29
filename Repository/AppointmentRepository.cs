using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Repository
{
    public class AppointmentRepository : RepositoryBase<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public async Task<List<AppointmentStatus>> GetAppointmentStatus()
        {
            return await RepositoryContext.AppointmentStatus.ToListAsync();
        }

        public async Task<AppointmentStatus> GetAppointmentStatusById(int id)
        {
            return await RepositoryContext.AppointmentStatus.Where(a => a.Id == id).FirstOrDefaultAsync();
        }
    }
}
