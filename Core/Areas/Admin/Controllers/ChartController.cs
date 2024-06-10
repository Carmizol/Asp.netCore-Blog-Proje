using Core.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]

	public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
      
        public IActionResult CategoryChart()
        {
            List<CategoryClass> list=new List<CategoryClass>();
            list.Add(new CategoryClass { categoryName="Yazılım",categoryCount=14});
            list.Add(new CategoryClass { categoryName="Spor",categoryCount=10});
            list.Add(new CategoryClass { categoryName="Teknoloji",categoryCount=7});
            list.Add(new CategoryClass { categoryName= "Film & Dizi", categoryCount=11});
            list.Add(new CategoryClass { categoryName= "Oyun", categoryCount=9});
            list.Add(new CategoryClass { categoryName= "Haber", categoryCount=8});
            list.Add(new CategoryClass { categoryName= "Sosyal Medya", categoryCount=15});
            list.Add(new CategoryClass { categoryName= "Seyhat", categoryCount=4});
            return Json(new { jsonlist = list });
        }
    }
}
