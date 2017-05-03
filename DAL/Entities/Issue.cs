using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Riganti.Utils.Infrastructure.Core;
namespace DAL.Entities
{
    public class Issue : IEntity<int>
    {
        public int Id { get; set; }

        public IssueType Type { get; set; }
        public State State { get; set; } = State.New;

        public virtual Project Project { get; set; }

        [ForeignKey("Project")]
        public int ProjectId { get; set; }

        [MaxLength(60)]
        public string CustomerName { get; set; }

        public virtual Employee Employee { get; set; }

        [ForeignKey("Employee")]
        public int? EmployeeId { get; set; }

        [MaxLength(200)]
        [Required]
        public string Description { get; set; }

        public DateTime Beginning { get; set; } = DateTime.Now;

        public DateTime? End { get; set; }

        public override string ToString()
        {
            return $"Project: {Project}  Description: {Description}";
        }

    }
}
