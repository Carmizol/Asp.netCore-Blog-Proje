using Microsoft.AspNetCore.Mvc;

namespace Core.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
