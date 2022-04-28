using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using myhealthhub.web.Services.FormLabelRepository;
using myhealthhub.web.Services.PhysicianRepository;
using myhealthhub.web.Services.VisitRepository;

namespace myhealthhub.web.Controllers
{
    [Authorize]
    public class FormLabelController : Controller
    {
        private IConfiguration _config;

        private FormLabelRepository _formLabel;

        public FormLabelController(IConfiguration config, FormLabelRepository formLabel)
        {
            _config = config;
            _formLabel = formLabel;
        }

        [HttpGet]
        public async Task<JsonResult> GetFormLabelsPerSelectedVisit(Guid visitId)
        {
            var formLabels = await _formLabel.GetFormLabelsPerSelectedVisit(visitId);

            if(formLabels != null)
            {
                return Json(formLabels);
            }

            return Json(new { error = "Current visit has no form(s) tied to it." });
        }
    }
}