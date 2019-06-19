using Hospital.Core.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.BusinessLogic.Managers.Abstractions
{
    public interface IAppointmentManager
    {
        Task<IEnumerable<Appointment>> Get();
        Task<Appointment> GetById(int id);
        Task<Appointment> Create(Appointment doctor);
        Task Delete(int id);
    }
}
