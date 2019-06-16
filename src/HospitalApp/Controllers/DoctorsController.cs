using Hospital.Core.BusinessLogic.Managers.Abstractions;
using Hospital.Core.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HospitalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorsManager _doctorManager;

        public DoctorsController(IDoctorsManager doctorManager)
        {
            _doctorManager = doctorManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var doctors = await _doctorManager.Get();
            return Ok(doctors);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var doctor = await _doctorManager.GetById(id);
            return Ok(doctor);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Doctor doctor)
        {
            var newDoctor = await _doctorManager.Create(doctor);
            return Ok(newDoctor);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _doctorManager.Delete(id);
            return NoContent();
        }
    }
}
