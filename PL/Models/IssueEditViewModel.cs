using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;
using BL.DTOs;

namespace PL.Models
{
    public class IssueEditViewModel
    {
        public IssueDTO Issue { get; set; }

        public int? SelectedProjectId { get; set; }
        public int? SelectedEmployeeId { get; set; }

        public SelectList AvailableEmployees { get; set; }

        [DisplayName("Employee")]
        public int? NewEmployeeId { get; set; } = 0;

        public IssueEditViewModel()
        {
            AvailableEmployees = new SelectList(new List<EmployeeDTO>());
        }

        public IssueEditViewModel(int? projectId, int? employeeId) : this()
        {
            SelectedProjectId = projectId;
            SelectedEmployeeId = employeeId;
        }
    }
}