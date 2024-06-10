using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core.ViewComponents.Category
{
    public class CategoryListDashboard : ViewComponent
    {
        CategoryManager categoryManager = new CategoryManager(new ECategoryRepository());
        public IViewComponentResult Invoke()
        {
            var value = categoryManager.GetAll(); 
            return View(value);
        }
    }
}
