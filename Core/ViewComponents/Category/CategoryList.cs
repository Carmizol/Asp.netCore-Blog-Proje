using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core.ViewComponents.Category
{
	public class CategoryList : ViewComponent
	{
		CategoryManager manager = new CategoryManager(new ECategoryRepository());
		public IViewComponentResult Invoke()
		{
			var values=manager.GetAll();
			return View(values);
		}
	}
}
