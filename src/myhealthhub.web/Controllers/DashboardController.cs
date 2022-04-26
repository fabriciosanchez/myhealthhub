using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace myhealthhub.web.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        public DashboardController()
        {
            //
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}