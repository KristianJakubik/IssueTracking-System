using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
   public class Company : Customer
    {
        [MaxLength(20)]
        [Required]
        public string Name { get; set; }

        [StringLength(8)]
        [RegularExpression(@"[0-9]*")]
        public string ICO { get; set; }

        public override string ToString()
        {
            return $"{Name} ICO: {ICO}";
        }
    }
}
