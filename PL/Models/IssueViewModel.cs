using System.Collections.Generic;
using BL.DTOs;

namespace PL.Models
{
    public class IssueViewModel
    {
        public List<IssueDTO> Issues { get; set; }
        public int? ProjectId { get; set; }
        public int? EmployeeId { get; set; }
        public IssueViewModel()
        {
            Issues = new List<IssueDTO>();
        }
    }
}