using Hospital.Core.BusinessLogic.Managers.Abstractions;
using Hospital.Core.DataAccess;
using Hospital.Core.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.BusinessLogic.Managers
{
    public class AppointmentManager : IAppointmentManager
    {
        public AppointmentManager(HospitalDbContext hospitalDbContext)
        {
            _hospitalDbContext = hospitalDbContext;
        }
        private readonly HospitalDbContext _hospitalDbContext;

        public async Task<Appointment> Create(Appointment appointment)
        {
            await _hospitalDbContext.Appointments.AddAsync(appointment);
            await _hospitalDbContext.SaveChangesAsync();

            return appointment;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Appointment>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Appointment> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
