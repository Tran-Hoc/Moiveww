using Microsoft.AspNetCore.Mvc;

namespace Web_xemphim.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Area("Admin")]

        public IActionResult Index()
        {
            return View();
        }
    }
}
