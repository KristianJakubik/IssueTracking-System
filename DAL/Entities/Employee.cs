using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Riganti.Utils.Infrastructure.Core;
namespace DAL.Entities
{
   public class Employee : IEntity<int>
    {
        public int Id { get; set; }

        [MaxLength(30)]
        public string FirstName { get; set; }

        [MaxLength(30)]
        public string LastName { get; set; }

        public virtual List<Issue> Issues { get; set; }

        public Employee()
        {
            Issues = new List<Issue>();
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
