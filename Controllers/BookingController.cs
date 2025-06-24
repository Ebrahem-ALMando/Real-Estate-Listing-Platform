using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstateMVC.Data;
using RealEstateMVC.Models;
using System.Security.Claims;

namespace RealEstateMVC.Controllers
{
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookingController(ApplicationDbContext context)
        {
            _context = context;
        }


        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var bookings = _context.Bookings
                .Include(b => b.Property)
                .Include(b => b.User)
                .ToList();
            return View(bookings);
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult UpdateStatus(int id, string status)
        {
            var booking = _context.Bookings.Find(id);
            if (booking == null) return NotFound();

            booking.Status = status;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        [Authorize]
        public IActionResult MyBookings()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var bookings = _context.Bookings
                .Include(b => b.Property)
                .Where(b => b.UserId == userId)
                .ToList();
            return View(bookings);
        }

 
        [Authorize]
        [HttpPost]
        public IActionResult Create(int PropertyId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var exists = _context.Bookings.Any(b => b.UserId == userId && b.PropertyId == PropertyId);
            if (exists)
            {
                TempData["Success"] = "لقد قمت بطلب هذا العقار مسبقاً.";
                return RedirectToAction("Details", "Properties", new { id = PropertyId });
            }

            var booking = new Booking
            {
                PropertyId = PropertyId,
                UserId = userId,
                BookingDate = DateTime.Now,
                Status = "Pending"
            };

            _context.Bookings.Add(booking);
            _context.SaveChanges();

            TempData["Success"] = "تم تقديم طلبك بنجاح!";
            return RedirectToAction("MyBookings", "Booking");
        }
        [HttpPost]
        [Authorize]
        public IActionResult Cancel(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var booking = _context.Bookings.FirstOrDefault(b => b.Id == id && b.UserId == userId);

            if (booking == null || booking.Status != "Pending")
                return Unauthorized();

            _context.Bookings.Remove(booking);
            _context.SaveChanges();

            TempData["Success"] = "تم إلغاء الحجز بنجاح.";
            return RedirectToAction("MyBookings");
        }

    }
}
