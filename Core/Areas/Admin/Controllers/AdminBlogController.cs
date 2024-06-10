using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core.Areas.Admin.Controllers
{
    public class AdminBlogController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            BlogManager blogManager = new BlogManager(new EBlogRepository());
            var values = blogManager.GetBlogListWithCategory();
            return View(values);
        }
    }
}
