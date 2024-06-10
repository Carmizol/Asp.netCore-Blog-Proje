using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core.ViewComponents.Writer
{
    public class WriterNotification : ViewComponent
    {
        NotificationManager notificationManager = new NotificationManager(new ENotificationRepository());
        public IViewComponentResult Invoke()
        {
            var value = notificationManager.GetAll();
            return View(value);
        }
    }
}
