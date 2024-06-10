using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        MessageRelationManager messageManager = new MessageRelationManager(new EMessageRelationRepository());
        Context context=new Context();
        public IViewComponentResult Invoke()
        {
            var username = User.Identity.Name;
            var usermail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = context.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterId).FirstOrDefault();
            var value = messageManager.GetInboxAllWithWriter(writerID);
            return View(value);
        }
    }
}
