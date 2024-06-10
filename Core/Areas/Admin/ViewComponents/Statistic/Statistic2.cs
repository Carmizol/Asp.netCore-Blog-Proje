using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2 : ViewComponent
    {
        Context context=new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = context.Blogs.OrderByDescending(x=>x.BlogId).Select(x=>x.BlogTitle).Take(1).FirstOrDefault();
            //ViewBag.v2 = context.Blogs.OrderByDescending(x=>x.BlogId).Select(x=>x.BlogContent).Take(1).FirstOrDefault();
            return View();
        }
    }
}
