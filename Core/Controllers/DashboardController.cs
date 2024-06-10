using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public class DashboardController : Controller
    {
		[Authorize(Roles = "Admin,Moderator,Writer")]
		public IActionResult Index()
        {
            Context context = new Context();
            var username = User.Identity.Name;
            var usermail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerid=context.Writers.Where(x => x.WriterMail==usermail).Select(y => y.WriterId).FirstOrDefault();

            ViewBag.TotalBlogs=context.Blogs.Count().ToString();
            ViewBag.YourBlogs=context.Blogs.Where(x=>x.WriterId==writerid).Count().ToString();
            ViewBag.TotalCatagories=context.Categories.Count().ToString();
            return View();
        }
    }
}
