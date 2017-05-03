using System.Collections.Generic;
using BL.DTOs;

namespace PL.Models
{
    public class CompanyViewModel
    {
        public List<CompanyDTO> Companies { get; set; }
        public CompanyDTO Company { get; set; }

        public CompanyViewModel()
        {            
            Companies = new List<CompanyDTO>();
        }
    }
}
