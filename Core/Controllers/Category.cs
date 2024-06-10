using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
	[Authorize(Roles = "Admin,Moderator,Writer")]
	public class Category : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new ECategoryRepository());
        public IActionResult Index()
        {
            var values = categoryManager.GetAll();
            return View(values);
        }
    }
}
