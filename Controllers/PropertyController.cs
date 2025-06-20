using Microsoft.AspNetCore.Mvc;
using RealEstateMVC.Models;



namespace RealEstateMVC.Controllers
{
    public class PropertyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details(int id)
        {
            
            var property = new PropertyViewModel
            {
                Id = id,
                Title = "Luxury Villa in Riyadh",
                Price = "1,200,000 SAR",
                Description = "فيلا فاخرة مع مسبح وحديقة في موقع متميز",
                Images = new List<string>
            {
                "/images/property-1.jpg",
                "/images/property-2.jpg",
                "/images/property-3.jpg"
            }
            };

            return View(property);
        }

    }
}
