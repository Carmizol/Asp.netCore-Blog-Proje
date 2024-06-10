using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core.ViewComponents.Blog
{
    public class BlogListDashboard : ViewComponent
    {
        BlogManager blogManager = new BlogManager(new EBlogRepository());
        public IViewComponentResult Invoke()
        {
            var value = blogManager.GetBlogListWithCategory();
            return View(value);
        }
    }
}
