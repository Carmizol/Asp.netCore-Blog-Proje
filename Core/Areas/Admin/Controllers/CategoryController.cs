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
using X.PagedList;

namespace Core.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class CategoryController : Controller
    {
        CategoryManager manager = new CategoryManager(new ECategoryRepository());
        Context context= new Context();
        public IActionResult Index(int page = 1)
        {
            var value = manager.GetAll().ToPagedList(page, 3);
            return View(value);
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category p)
        {
            CategoryValidatior validations = new CategoryValidatior();
            ValidationResult validationResult = validations.Validate(p);
            if (validationResult.IsValid)
            {
                p.CategoryStatus = true;
                manager.TAdd(p);
                return RedirectToAction("Index", "Category");
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
        public IActionResult DelCategory(int id)
        {
            var value = manager.TGetById(id);
            manager.TDel(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            var value = manager.TGetById(id);
            List<SelectListItem> categoryList = (from x in manager.GetAll()
                                                 select new SelectListItem
                                                 { Text = x.CatergoryName, Value = x.CategoryId.ToString() }).ToList();
            ViewBag.cl = categoryList;
            return View(value);
        }
        [HttpPost]
        public IActionResult EditCategory(Category p)
        {
            var username = User.Identity.Name;
            var usermail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = context.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterId).FirstOrDefault();
            p.CategoryId = writerID;
            p.CategoryStatus = true;
            manager.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}
