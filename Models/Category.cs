using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RealEstateMVC.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public virtual ICollection<Property> Properties { get; set; }
    }
}