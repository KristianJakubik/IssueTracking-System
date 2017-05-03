using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DAL.Entities;
namespace BL.DTOs
{
   public class EmployeeDTO 
    {
        public int Id { get; set; }

        [MaxLength(30, ErrorMessage = "MaxLength is 30")]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(30, ErrorMessage = "MaxLength is 30")]
        [Required]
        public string LastName { get; set; }

        public string GetFullName => ToString();

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
