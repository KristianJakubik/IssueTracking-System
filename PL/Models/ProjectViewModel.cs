using System.Collections.Generic;
using BL.DTOs;

namespace PL.Models
{
    public class ProjectViewModel
    {
        public List<ProjectDTO> Projects { get; set; }
        public int CustomerId { get; set; }
        public ProjectViewModel()
        {
            Projects = new List<ProjectDTO>();
        }
    }
}