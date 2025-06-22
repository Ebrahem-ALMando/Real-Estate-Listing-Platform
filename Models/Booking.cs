using System;
using System.ComponentModel.DataAnnotations.Schema;
using RealEstateMVC.Models;

namespace RealEstateMVC.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime BookingDate { get; set; }
        public string Status { get; set; } // e.g., "Pending", "Confirmed", "Cancelled"
        public string Message { get; set; }

        // Foreign key to the requested property
        public int PropertyId { get; set; }
        [ForeignKey("PropertyId")]
        public virtual Property Property { get; set; }

        // Foreign key to the user who made the booking
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
    }
}