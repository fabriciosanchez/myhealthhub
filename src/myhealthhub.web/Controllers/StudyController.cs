using Microsoft.AspNetCore.Mvc;
using myhealthhub.web.Services.PhysicianRepository;

namespace myhealthhub.web.Controllers
{
    public class StudyController : Controller
    {
        private IConfiguration _config;

        private StudyRepository _study;

        public StudyController(IConfiguration config, StudyRepository study)
        {
            _config = config;
            _study = study;
        }

        [HttpGet]
        public async Task<JsonResult> GetStudiesForCurrentPhysician(string physicianEmail)
        {
            var studies = await _study.GetStudiesForCurrentPhysician(physicianEmail);

            if(studies != null)
            {
                return Json(studies);
            }

            return Json(new { error = "Current physician has no studies tied to them." });
        }
    }
}