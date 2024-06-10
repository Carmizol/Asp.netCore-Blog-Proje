using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;

namespace Core.Controllers
{    
    [AllowAnonymous]
    public class BlogController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new ECategoryRepository());
        BlogManager blogManager = new BlogManager(new EBlogRepository()); 
        Context context = new Context();
		[AllowAnonymous]
		public IActionResult Index()
        {
            var values = blogManager.GetBlogListWithCategory();
            return View(values);
        }
        [AllowAnonymous]
        public IActionResult BlogRead(int id)
        {
            ViewBag.x = id;
            var values = blogManager.GetBlogId(id);
            return View(values);
        }
        public IActionResult BlogListByWriter()
        {
            var username = User.Identity.Name;
            var usermail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = context.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterId).FirstOrDefault();
            var values = blogManager.GetListWithCategoryByWriterBlog(writerID);
            return View(values);
        }
		[AllowAnonymous]
		[HttpGet]
        public IActionResult BlogAdd()
        {
            List<SelectListItem> categoryList = (from x in categoryManager.GetAll()
                                                 select new SelectListItem
                                                 { Text = x.CatergoryName, Value = x.CategoryId.ToString() }).ToList();
            ViewBag.cl = categoryList;
            return View();
        }
		[AllowAnonymous]
		[HttpPost]
        public IActionResult BlogAdd(Blog p)
        {
            var username = User.Identity.Name;
            var usermail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = context.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterId).FirstOrDefault();
            BlogValidatior validations = new BlogValidatior();
            ValidationResult validationResult = validations.Validate(p);
            if (validationResult.IsValid)
            {
                p.BlogStatus = true;
                p.BCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.WriterId = writerID;
                blogManager.TAdd(p);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
            return View();
        }
        public IActionResult DelBlog(int id)
        {
            var value = blogManager.TGetById(id);
            blogManager.TDel(value);
            return RedirectToAction("BlogListByWriter");
        }
		[AllowAnonymous]
		[HttpGet]
        public IActionResult EditBlog(int id)
        {
            var value = blogManager.TGetById(id);
            List<SelectListItem> categoryList = (from x in categoryManager.GetAll()
                                                 select new SelectListItem
                                                 { Text = x.CatergoryName, Value = x.CategoryId.ToString() }).ToList();
            ViewBag.cl = categoryList;
            return View(value);
        }
		[AllowAnonymous]
		[HttpPost]
        public IActionResult EditBlog(Blog p)
        {
            var username = User.Identity.Name;
            var usermail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = context.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterId).FirstOrDefault();
            p.WriterId = writerID;
            p.BCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.BlogStatus = true;
            blogManager.TUpdate(p);
            return RedirectToAction("BlogListByWriter");
        }
    }
}
