using System.Collections.Generic;
using System.Web.Mvc;
using BL.DTOs;

namespace PL.Models
{
    public class ProjectCreateViewModel
    {
        public ProjectDTO Project { get; set; }

        public SelectList AvailableCustomers { get; set; }
        public int SelectedCustomerId { get; set; }

        public ProjectCreateViewModel()
        {
            AvailableCustomers = new SelectList(new List<CustomerDTO>());
        }

        public ProjectCreateViewModel(int id) : this()
        {
            SelectedCustomerId = id;
        }
    }
}