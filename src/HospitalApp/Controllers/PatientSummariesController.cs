using Hospital.Core.BusinessLogic.Managers.Abstractions;
using Hospital.Core.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HospitalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientSummariesController : ControllerBase
    {
        private readonly IPatientSummariesManager _patientSummariesManager;

        public PatientSummariesController(IPatientSummariesManager patientSummariesManager)
        {
            _patientSummariesManager = patientSummariesManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var patientSummaries = await _patientSummariesManager.Get();
            return Ok(patientSummaries);
        }

        [HttpGet("id:int")]
        public async Task<IActionResult> GetById(int id)
        {
            var patientSummary = await _patientSummariesManager.GetById(id);
            return Ok(patientSummary);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PatientSummary patientSummary)
        {
            var newPatientSummary = await _patientSummariesManager.Create(patientSummary);
            return Ok(patientSummary);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _patientSummariesManager.Delete(id);
            return NoContent();
        }
    }
}
