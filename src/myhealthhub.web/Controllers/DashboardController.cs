using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using myhealthhub.web.Models.Patient;
using myhealthhub.web.Services.PatientRepository;

namespace myhealthhub.web.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}