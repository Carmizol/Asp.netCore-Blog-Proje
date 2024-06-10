using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
	[AllowAnonymous]
	public class NewsLetterController : Controller
	{
		NewsLetterManager manager = new NewsLetterManager(new ENewsLetterRepository());

		[HttpGet]
		public PartialViewResult SubscribeMail()
		{
			return PartialView();
		}

		[HttpPost]
		public IActionResult SubscribeMail(NewsLetter newsLetter)
		{
			newsLetter.MailStatus = true;
			manager.AddNewsLetter(newsLetter);
			return PartialView(newsLetter);
		}
	}
}
