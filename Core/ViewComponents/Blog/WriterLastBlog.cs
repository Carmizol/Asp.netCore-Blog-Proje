using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core.ViewComponents.Blog
{
    public class WriterLastBlog : ViewComponent
    {
        BlogManager blogManager = new BlogManager(new EBlogRepository());
        public IViewComponentResult Invoke()
        {
            var values = blogManager.GetBlogListWithWriter(1);
            return View(values);
        }
    }
}
