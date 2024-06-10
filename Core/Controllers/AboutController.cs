using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
	[AllowAnonymous]
	public class AboutController : Controller
	{
		AboutManager aboutManager = new AboutManager(new EAboutRepository());
		public IActionResult Index()
		{
			var values=aboutManager.GetAll();
			return View(values);
		}
		
	}
}
