using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class WidgetContoller : Controller
    {
        BlogManager blogManager = new BlogManager(new EBlogRepository());
        Context context = new Context();
        public IActionResult Index()
        {
            ViewBag.v1 = blogManager.GetAll().Count();
            ViewBag.v2=context.Contacts.Count();
            ViewBag.v3=context.Comments.Count();
            return View();
        }
    }
}
