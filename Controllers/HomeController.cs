using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RealEstateMVC.Data;
using RealEstateMVC.Models;

namespace RealEstateMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        public IActionResult Index()
        {
            var featuredProperties = _context.Properties
                .ToList();

            return View(featuredProperties);
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
        [HttpGet]
        public IActionResult Contact()
        {
            return PartialView("Partials/_ContactForm", new Message());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Contact(Message model)
        {
            if (ModelState.IsValid)
            {
                _context.Messages.Add(model); 
                _context.SaveChanges();
                TempData["Success"] = " „ ≈—”«· —”«· ﬂ »‰Ã«Õ!";
                return RedirectToAction("Index");
            }

            return PartialView("Partials/_ContactForm", model);
        }

    }
}
