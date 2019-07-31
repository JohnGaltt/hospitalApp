using Hospital.Core.BusinessLogic.Managers.Abstractions;
using Hospital.Core.DataAccess;
using Hospital.Core.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Core.BusinessLogic.Managers
{
    public class PatientsManager : IPatientsManager
    {
        private readonly HospitalDbContext _hospitalDbContext;

        public PatientsManager(HospitalDbContext hospitalDbContext)
        {
            _hospitalDbContext = hospitalDbContext;
        }
        public async Task<Patient> Create(Patient patient)
        {
            await _hospitalDbContext.Patients.AddAsync(patient);
            await _hospitalDbContext.SaveChangesAsync();

            return patient;
        }

        public async Task Delete(int id)
        {
            var patient = await _hospitalDbContext.Patients.FirstOrDefaultAsync(x => x.Id == id);
            if (patient is null)
            {
                throw new NotImplementedException();
            }
            _hospitalDbContext.Patients.Remove(patient);
            _hospitalDbContext.SaveChanges();
        }

        public async Task<IEnumerable<Patient>> Get()
        {
            var patients = _hospitalDbContext.Patients.AsQueryable();
            var result = await patients.ToListAsync();

            return result;
        }

        public async Task<Patient> GetById(int id)
        {
            var patient = await _hospitalDbContext.Patients.FirstOrDefaultAsync(x => x.Id == id);
            if (patient is null)
            {
                throw new NotImplementedException();
            }

            return patient;
        }
    }
}
