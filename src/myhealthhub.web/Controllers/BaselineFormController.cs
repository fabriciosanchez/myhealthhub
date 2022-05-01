using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using myhealthhub.web.Models.Baseline;

namespace myhealthhub.web.Controllers
{
    [Authorize]
    public class BaselineFormController : Controller
    {
        public BaselineFormController()
        {
            // Dependency injection here
        }

        public async Task<IActionResult> Index([FromQuery] string pid, string phe, string vid, string flid)
        {
            if(pid == "" || phe == "" || vid == "" || flid == "")
            {
                ViewBag.ErrorMessage = "Critical information needed to load the form is missing. Please, start the process again. If the error continues, please, inform the administrator.";
                return View();
            }
            else
            {
                ViewBag.ErrorMessage = "ok";
                var baselineQueryString = new BaselineQueryStringModel();
                baselineQueryString.PatientInternalId = pid;
                baselineQueryString.VisitId = Guid.Parse(vid);
                baselineQueryString.FormLabelId = Guid.Parse(flid);
                baselineQueryString.PhysicianEmail = phe;

                return View(baselineQueryString);
            }
        }
    } 
}