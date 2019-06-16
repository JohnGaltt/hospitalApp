using Hospital.Core.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.BusinessLogic.Managers.Abstractions
{
    public interface IPatientSummariesManager
    {
        Task<IEnumerable<PatientSummary>> Get();
        Task<PatientSummary> GetById(int id);
        Task<PatientSummary> Create(PatientSummary patient);
        Task Delete(int id);
    }
}
