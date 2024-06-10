using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
	[AllowAnonymous]
	public class RegisterController : Controller
	{
		WriterManager writerManager = new WriterManager(new EWriterRepository());

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(Writer p)
		{
			WriterValidatior validations = new WriterValidatior();
			ValidationResult validationResult = validations.Validate(p);
			if (validationResult.IsValid)
			{
                p.WriterStatus = true;
                p.WriterAbout = "Test";
                writerManager.TAdd(p);
                return RedirectToAction("Index", "Blog");
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
	}
}
