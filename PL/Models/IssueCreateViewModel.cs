using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;
using BL.DTOs;

namespace PL.Models
{
    public class IssueCreateViewModel
    {
        public IssueDTO Issue { get; set; }

        public SelectList AvailableProjects { get; set; }
        public SelectList AvailableEmployees { get; set; }

        public int? SelectedProjectId { get; set; }
        public int? SelectedEmployeeId { get; set; }
        [DisplayName("Employee")]
        public int NewEmployeeId { get; set; }
        [DisplayName("Project")]
        public int NewProjectId { get; set; }

        public IssueCreateViewModel()
        {
            AvailableProjects = new SelectList(new List<ProjectDTO>());
            AvailableEmployees = new SelectList(new List<EmployeeDTO>());

            NewProjectId = 0;
            NewEmployeeId = 0;
        }

        public IssueCreateViewModel(int? projectId, int? employeeId) : this()
        {
            SelectedProjectId = projectId;
            SelectedEmployeeId = employeeId;
        }
    }
}