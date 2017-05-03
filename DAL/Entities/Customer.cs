using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Riganti.Utils.Infrastructure.Core;
namespace DAL.Entities
{
    public class Customer : IEntity<int>
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Contact { get; set; }

        public virtual List<Project> Projects { get; set; }

        public Customer()
        {
            Projects = new List<Project>();
        }
    }
}
