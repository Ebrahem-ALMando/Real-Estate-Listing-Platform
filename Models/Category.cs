using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace RealEstateMVC.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "الاسم مطلوب")]
        [MinLength(2, ErrorMessage = "الاسم يجب أن لا يقل عن حرفين")]
        [RegularExpression(@"[^\d]+", ErrorMessage = "الاسم لا يمكن أن يكون أرقام فقط")]
        public string Name { get; set; }

        [ValidateNever]
        public virtual ICollection<Property> Properties { get; set; }
    }
}
