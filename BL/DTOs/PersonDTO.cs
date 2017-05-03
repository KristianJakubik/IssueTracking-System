using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace BL.DTOs
{
   public class PersonDTO : CustomerDTO
    {
        [Required]
        public string FirstName{ get; set; }
        [Required]
        public string LastName { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
