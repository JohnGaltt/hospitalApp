using Hospital.Core.BusinessLogic.Managers.Abstractions;
using Hospital.Core.DataAccess;
using Hospital.Core.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Core.BusinessLogic
{
    public class DoctorsManager : IDoctorsManager
    {
        private readonly HospitalDbContext _hospitalDbContext;

        public DoctorsManager(HospitalDbContext hospitalDbContext)
        {
            _hospitalDbContext = hospitalDbContext;
        }
        public async Task<Doctor> Create(Doctor doctor)
        {
            await _hospitalDbContext.Doctors.AddAsync(doctor);
            await _hospitalDbContext.SaveChangesAsync();

            return doctor;
        }

        public async Task Delete(int id)
        {
            var doctor = await _hospitalDbContext.Doctors.FirstOrDefaultAsync(x => x.Id == id);
            if(doctor is null)
            {
                throw new NotImplementedException();
            }
            _hospitalDbContext.Doctors.Remove(doctor);
            _hospitalDbContext.SaveChanges();
        }

        public async Task<IEnumerable<Doctor>> Get()
        {
            var doctors =  _hospitalDbContext.Doctors.Include(x=>x.Department).AsQueryable();
            var result = await doctors.ToListAsync();

            return result;
        }

        public async Task<Doctor> GetById(int id)
        {
            var doctor = await _hospitalDbContext.Doctors.Include(x=>x.Department).FirstOrDefaultAsync(x => x.Id == id);
            if(doctor is null)
            {
                throw new NotImplementedException();
            }

            return doctor;
        }
    }
}
