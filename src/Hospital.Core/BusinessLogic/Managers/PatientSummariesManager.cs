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
    public class PatientSummariesManager : IPatientSummariesManager
    {
        private readonly HospitalDbContext _hospitalDbContext;

        public PatientSummariesManager(HospitalDbContext hospitalDbContext)
        {
            _hospitalDbContext = hospitalDbContext;
        }

        public async Task<PatientSummary> Create(PatientSummary patientSummary)
        {
            await _hospitalDbContext.PatientSummaries.AddAsync(patientSummary);
            await _hospitalDbContext.SaveChangesAsync();

            return patientSummary;
        }

        public async Task Delete(int id)
        {
            var patientSummary = await _hospitalDbContext.PatientSummaries.FirstOrDefaultAsync(x => x.Id == id);
            if (patientSummary != null)
            {
                throw new NotImplementedException();
            }
            _hospitalDbContext.PatientSummaries.Remove(patientSummary);
            _hospitalDbContext.SaveChanges();
        }

        public async Task<IEnumerable<PatientSummary>> Get()
        {
            var patientSummaries = _hospitalDbContext.PatientSummaries.AsQueryable();
            var result = await patientSummaries.ToListAsync();

            return result;
        }

        public async Task<PatientSummary> GetById(int id)
        {
            var patientSummary = await _hospitalDbContext.PatientSummaries.FirstOrDefaultAsync(x => x.Id == id);
            if (patientSummary is null)
            {
                throw new NotImplementedException();
            }

            return patientSummary;
        }
    }
}
