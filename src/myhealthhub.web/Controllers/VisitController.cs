using Microsoft.AspNetCore.Mvc;
using myhealthhub.web.Services.PhysicianRepository;
using myhealthhub.web.Services.VisitRepository;

namespace myhealthhub.web.Controllers
{
    public class VisitController : Controller
    {
        private IConfiguration _config;

        private VisitRepository _visit;

        public VisitController(IConfiguration config, VisitRepository visit)
        {
            _config = config;
            _visit = visit;
        }

        [HttpGet]
        public async Task<JsonResult> GetVisitsPerSelectedStudy(Guid studyId)
        {
            var visits = await _visit.GetVisitsPerSelectedStudy(studyId);

            if(visits != null)
            {
                return Json(visits);
            }

            return Json(new { error = "Current study has no visit types tied to it." });
        }
    }
}