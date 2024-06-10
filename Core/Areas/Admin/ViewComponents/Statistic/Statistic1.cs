using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Core.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1 : ViewComponent
    {
        Context Context = new Context();
        public IViewComponentResult Invoke()
        {
            string api = "4f250993fda1519e188980ff1bcc9554";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=%C4%B0stanbul&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument document = XDocument.Load(connection);
            ViewBag.v4 = document.Descendants("temperature").ElementAt(0).Attributes("value").ElementAt(0).Value;
            return View();
        }
    }
}
