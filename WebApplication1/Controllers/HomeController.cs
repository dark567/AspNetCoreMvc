using BuissnesLayer;
using BuissnesLayer.Interfaces;
using DataLayer;
using DataLayer.Entityes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PresentationLayer;
using PresentationLayer.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        //private EFDBContext _context;
        //private IDirectorysRepository _dirRep;

        private DataManager _dataManager;
        private ServicesManager _servicesmanger;

        public HomeController(/*EFDBContext context, IDirectorysRepository dirRep,*/ DataManager dataManager)
        {
            //_context = context;
            //dirRep = _dirRep;

            _dataManager = dataManager;
            _servicesmanger = new ServicesManager(_dataManager);
        }

        public IActionResult Index()
        {
            //HelloModel _model = new HelloModel() { HelloMessage = "Hi, Serge" };
            //return View(_model);

            //List<Directory> _dirs = _context.Directory.Include(x=>x.Materials).ToList();

            //List<Directory> _dirs =_dirRep.GetAllDirectorys().ToList();

            //List<Directory> _dirs = _dataManager.Directorys.GetAllDirectorys(true).ToList();

            List<DirectoryViewModel> _dirs = _servicesmanger.Directorys.GetDirectoryList();
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
