using Hospital.Core.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hospital.Core.BusinessLogic.Managers.Abstractions
{
    public interface IPatientsManager
    {
        Task<IEnumerable<Patient>> Get();
        Task<Patient> GetById(int id);
        Task<Patient> Create(Patient patient);
        Task Delete(int id);
    }
}
