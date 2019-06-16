using Hospital.Core.BusinessLogic.Managers.Abstractions;
using Hospital.Core.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
    }
}
