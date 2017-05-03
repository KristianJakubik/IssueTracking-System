using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DAL.Entities;
namespace BL.DTOs
{
    public class CustomerDTO 
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "MaxLengh is 200")]
        public string Contact { get; set; }

    }
}
