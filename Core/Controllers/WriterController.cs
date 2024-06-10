using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using Core.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using NuGet.Common;


namespace Core.Controllers
{
	[AllowAnonymous]
	public class WriterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EWriterRepository());
        UserManager userManager = new UserManager(new EUserRepository());
        private readonly UserManager<AppUser> _userManager;

        public WriterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var userMail = User.Identity.Name;
            ViewBag.x = userMail;
            Context context = new Context();
            var writerName = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.Writer = writerName;
            return View();
        }

        public IActionResult WriterProfile()
        {

            return View();
        }

        public IActionResult WriterMail()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public async Task<IActionResult> WriterEditProfile()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdate model = new UserUpdate();
            model.namesurname = value.NameSurname;
            model.mail = value.Email;
            model.username = value.UserName;
            model.ımageurl = value.ImageUrl;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> WriterEditProfile(UserUpdate model)
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            value.NameSurname = model.namesurname;
            value.ImageUrl = model.ımageurl;
            value.Email = model.mail;
            
            value.PasswordHash = _userManager.PasswordHasher.HashPassword(value, model.password);

            var result = await _userManager.UpdateAsync(value);
            return RedirectToAction("Index", "Dashboard");
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage p)
        {
            Writer writer = new Writer();
            if (p.WriterImage != null)
            {
                var ex = Path.GetExtension(p.WriterImage.FileName);
                var newImageName = Guid.NewGuid() + ex;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/writerImageFiles/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                p.WriterImage.CopyTo(stream);
                writer.WriterImage = newImageName;
                writer.WriterMail = p.WriterMail;
                writer.WriterName = p.WriterName;
                writer.WriterPassword = p.WriterPassword;
                writer.WriterAbout = p.WriterAbout;
                writer.WriterStatus = true;
            }
            writerManager.TAdd(writer);
            return RedirectToAction("Index", "Dashboard");
        }

    }
}
