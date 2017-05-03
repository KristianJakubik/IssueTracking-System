using System.Collections.Generic;
using BL.DTOs;

namespace PL.Models
{
    public class EmployeeViewModel
    {
        public List<EmployeeDTO> Employees { get; set; }
        public EmployeeDTO Employee { set; get; }

        public EmployeeViewModel()
        {
            Employees = new List<EmployeeDTO>();
        }
    }
}