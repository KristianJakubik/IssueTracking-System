using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace BL.DTOs
{
   public class CompanyDTO : CustomerDTO
    {
        [MaxLength(20, ErrorMessage = "MaxLength is 20")]
        [Required]
        public string Name { get; set; }

        [StringLength(8, ErrorMessage = "Length is only 8")]
        [RegularExpression(@"[0-9]*", ErrorMessage = "Can contain only numbers")]
        public string ICO { get; set; }

        public override string ToString()
        {
            return $"{Name} ICO: {ICO}";
        }
    }
}
