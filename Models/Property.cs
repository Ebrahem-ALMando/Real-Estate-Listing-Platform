using RealEstateMVC.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateMVC.Models
{
    public class Property
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Address { get; set; }

        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }

        // المساحة بالمتر المربع
        public int Area { get; set; }
        public string ImageUrl { get; set; }

        // الحقل الذي أضفته لتمييز العقار
        public bool IsFeatured { get; set; }

        // --- هنا نحدد العلاقة مع جدول الفئات ---

        // 1. هذا هو المفتاح الخارجي (Foreign Key)
        public int CategoryId { get; set; }

        // 2. هذه الخاصية تربط المفتاح الخارجي بجدول الفئات مباشرة
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
    }
}