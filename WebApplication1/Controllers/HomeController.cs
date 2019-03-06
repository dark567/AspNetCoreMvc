using DataLayer;
using DataLayer.Entityes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private EFDBContext _context;
        public HomeController(EFDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //HelloModel _model = new HelloModel() { HelloMessage = "Hi, Serge" };
            //return View(_model);
            List<Directory> _dirs = _context.Directory.Include(x=>x.Materials).ToList();
            return View(_dirs);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
