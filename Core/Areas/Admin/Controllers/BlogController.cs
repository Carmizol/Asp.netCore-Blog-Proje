using ClosedXML.Excel;
using Core.Areas.Admin.Models;
using DocumentFormat.OpenXml.InkML;
using Microsoft.AspNetCore.Authorization;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class BlogController : Controller
    {
        [AllowAnonymous]
        public IActionResult ExportDynamicExcelBlog()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Bloglar");
                worksheet.Cell(1, 1).Value = "Blog Id";
                worksheet.Cell(1, 2).Value = "Blog Adı";
                int BlogCount = 2;
                foreach (var item in BlogTitleList())
                {
                    worksheet.Cell(BlogCount, 1).Value = item.ID;
                    worksheet.Cell(BlogCount, 2).Value = item.BlogName;
                    BlogCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "1.Rapor.xlsx");
                }
            }
        }
        public List<BlogModel> BlogTitleList()
        {
            List<BlogModel> model = new List<BlogModel>();
            using (var context = new DataAccessLayer.Concrete.Context())
            {
                model = context.Blogs.Select(x => new BlogModel { 
                    ID=x.BlogId,
                    BlogName=x.BlogTitle
                }).ToList();
            }
            return model;
        }
        public IActionResult BlogTitleListExcel()
        {
            return View();
        }
    }
}
