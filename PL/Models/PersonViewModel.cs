using System.Collections.Generic;
using BL.DTOs;

namespace PL.Models
{
    public class PersonViewModel
    {
        public List<PersonDTO> Persons{ get; set; }
        public PersonDTO Person { get; set; }
        public PersonViewModel()
        {
            Persons = new List<PersonDTO>();
        }
    }
}