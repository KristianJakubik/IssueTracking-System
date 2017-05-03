using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.Entities;
namespace BL.DTOs
{
   public class ProjectDTO
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string Name { get; set; }
  
        [Required]
        public CustomerDTO Customer { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }

    }
}
