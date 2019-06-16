using Hospital.Core.BusinessLogic.Managers.Abstractions;
using Hospital.Core.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HospitalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientsManager _patientsManager;

        public PatientsController(IPatientsManager patientsManager)
        {
            _patientsManager = patientsManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var doctors = await _patientsManager.Get();
            return Ok(doctors);
        }

        [HttpGet("id:int")]
        public async Task<IActionResult> GetById(int id)
        {
            var patient = await _patientsManager.GetById(id);
            return Ok(patient);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Patient patient)
        {
            var newPatient = await _patientsManager.Create(patient);
            return Ok(patient);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _patientsManager.Delete(id);
            return NoContent();
        }

    }
}
