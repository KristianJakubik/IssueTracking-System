using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BL.DTOs
{
   public class IssueFilter
    {
        public IssueType? Type { get; set; }
        public int? ProjectId { get; set; }
        public State? State { get; set; }
        public int? EmployeeId { get; set; }
    }
}
