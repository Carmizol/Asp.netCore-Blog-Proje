using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public class NotificationController : Controller
    {
        NotificationManager notificationManager=new NotificationManager(new ENotificationRepository());
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult GetAllNotification()
        {
            var value = notificationManager.GetAll();
            return View(value);
        }
    }
}
