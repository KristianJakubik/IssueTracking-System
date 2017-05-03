using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Riganti.Utils.Infrastructure.Core;

namespace DAL.Entities
{
   public class Project : IEntity<int>
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string Name { get; set; }
 
        public virtual Customer Customer { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        public virtual List<Issue> Issues { get; set; }

        public override string ToString()
        {
            return $"{Name} {Customer}";
        }

        public Project()
        {
            Issues = new List<Issue>();
        }

    }
}
