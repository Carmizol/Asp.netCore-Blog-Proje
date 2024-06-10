using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Core.Controllers
{
	[Authorize(Roles = "Admin,Moderator,Writer,Member")]
	public class MessageController : Controller
    {
        MessageRelationManager relationManager = new MessageRelationManager(new EMessageRelationRepository());
        Context context = new Context();
        public IActionResult InBox()
        {
            var username = User.Identity.Name;
            var usermail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = context.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterId).FirstOrDefault();
            var value = relationManager.GetInboxAllWithWriter(writerID);
            return View(value);
        }
        public IActionResult MessageDetails(int id)
        {
            var value = relationManager.TGetById(id);

            return View(value);
        }
        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendMessage(MessageRelation p)
        {
            var username = User.Identity.Name;
            var usermail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = context.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterId).FirstOrDefault();

            p.SenderId= writerID;
            p.RecevierId = 2;
            p.MessageStatus = true;
            relationManager.TAdd(p);
            return RedirectToAction("Inbox");
        }
    }
}
