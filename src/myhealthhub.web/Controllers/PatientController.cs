using Microsoft.AspNetCore.Mvc;
using myhealthhub.web.Models.Patient;
using myhealthhub.web.Services.PatientRepository;

namespace myhealthhub.web.Controllers
{
    public class PatientController : Controller
    {
        private IConfiguration _config;

        private readonly PatientRepository _patient;

        public PatientController(IConfiguration config, PatientRepository patient)
        {
            _config = config;
            _patient = patient;
        }

        public async Task<IActionResult> GetPatientByInternalId([FromForm]PatientByInternalIdViewModel patientForm)
        {
            var patient = await _patient.GetPatientAsync(patientForm.PatientInternalId);

            if(patient != null)
            {
                return View(patient);
            }

            TempData["Message"] = "Patient not found. Double check internal code.";
            TempData["MessageType"] = "error";
            return RedirectToAction("Index");
        }
    }
}