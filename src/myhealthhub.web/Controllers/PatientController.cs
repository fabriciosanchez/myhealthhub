using Microsoft.AspNetCore.Mvc;
using myhealthhub.web.Services.PatientRepository;

namespace myhealthhub.web.Controllers
{
    public class PatientController : Controller
    {
        private IConfiguration _config;

        private PatientRepository _patient;

        public PatientController(IConfiguration config, PatientRepository patient)
        {
            _config = config;
            _patient = patient;
        }

        [HttpPost]
        public async Task<JsonResult> GetPatientByInternalId(string patientInternalId)
        {
            var patient = await _patient.GetPatientByInternalIdAsync(patientInternalId);

            if(patient.InternalId != null)
            {
                var returnedObj = Json(new { InternalId = patient.InternalId });
                return returnedObj;
            }

            return Json(new { error = "Patient not found." });
        }
    }
}