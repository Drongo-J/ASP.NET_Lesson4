using ASPLesson4.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASPLesson4.Controllers
{
    public class HomeController : Controller
    {
      private readonly ProductDbContext _context;
        public HomeController(ProductDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Categories()
        {
            return Json(_context.Categories);
        }
    }
}