using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core.ViewComponents.Comment
{
    public class CommentListBlog : ViewComponent
    {
        CommentManager commentManager = new CommentManager(new ECommentRepository()); 
        public IViewComponentResult Invoke(int id)
        {
            var values = commentManager.GetAll(id);
            return View(values);
        }
    }
}
