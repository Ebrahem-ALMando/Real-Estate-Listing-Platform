using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;

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
        [Precision(18, 2)]
        public decimal Price { get; set; }

        [Required]
        public string Address { get; set; }

        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public int Area { get; set; }

        [ValidateNever]
        public string MainImageUrl { get; set; }

        // لن يُخزن، فقط لاستقبال الصورة وقت الإرسال
        [NotMapped]
        public IFormFile MainImage { get; set; }

        public bool IsFeatured { get; set; }

        public int CategoryId { get; set; }

        [ValidateNever]
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        [ValidateNever]
        public virtual ICollection<PropertyImage> PropertyImages { get; set; }
    }
}
