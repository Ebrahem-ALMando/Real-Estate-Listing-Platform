using Microsoft.AspNetCore.Mvc;
using RealEstateMVC.Data;
using RealEstateMVC.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using RealEstateMVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace RealEstateMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DashboardController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var model = new DashboardViewModel
            {
                PropertiesCount = _context.Properties.Count(),
                CategoriesCount = _context.Categories.Count(),
                MessagesCount = _context.Messages.Count(),
                UsersCount = _userManager.Users.Count(),
                BookingsCount = _context.Bookings.Count()
            };

            return View(model);
        }

    }
}
