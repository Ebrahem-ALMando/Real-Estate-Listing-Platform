using System.ComponentModel.DataAnnotations.Schema;
using RealEstateMVC.Models;

namespace RealEstateMVC.Models
{
    public class PropertyImage
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }

        // Foreign key to link this image to a specific property
        public int PropertyId { get; set; }
        [ForeignKey("PropertyId")]
        public virtual Property Property { get; set; }
    }
}