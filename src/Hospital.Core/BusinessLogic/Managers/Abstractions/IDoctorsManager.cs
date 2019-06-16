using Hospital.Core.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hospital.Core.BusinessLogic.Managers.Abstractions
{
    public interface IDoctorsManager
    {
        Task<IEnumerable<Doctor>> Get();
        Task<Doctor> GetById(int id);
        Task<Doctor> Create(Doctor doctor);
        Task Delete(int id);
    }
}
