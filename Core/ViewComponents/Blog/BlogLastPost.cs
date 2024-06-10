using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core.ViewComponents.Blog
{
    public class BlogLastPost : ViewComponent
    {
        BlogManager blogManager = new BlogManager(new EBlogRepository());
        public IViewComponentResult Invoke()
        {
            var values = blogManager.GetLastBlogPost();
            return View(values);
        }
    }
}
