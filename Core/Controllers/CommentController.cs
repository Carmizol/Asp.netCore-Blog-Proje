using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
	[Authorize(Roles = "Admin,Moderator,Writer")]

	[AllowAnonymous]
	public class CommentController : Controller
    {
        CommentManager commentManager = new CommentManager(new ECommentRepository());
        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult CommentListBlog(int id)
        {
            var values = commentManager.GetAll(id);
            return PartialView(values);
        }
        [HttpGet]
        public PartialViewResult PartialAddComment()
        {

            return PartialView();
        }
        [HttpPost]
        public PartialViewResult PartialAddComment(Comment p)
        {
            p.CommentDate = DateTime.Parse(DateTime.Now.ToLongDateString());
            p.CommentStatus = true;
            p.BlogId = 2;
            commentManager.CommentAdd(p);
            return PartialView();
        }
    }
}
