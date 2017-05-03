using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.Entities;
using System;

namespace BL.DTOs
{
    public class IssueDTO
    {
        public int Id { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Select a correct type")]
        public IssueType Type { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Select a correct state")]
        public State State { get; set; } = State.New;
        
        [Required]
        public ProjectDTO Project { get; set; }

        [MaxLength(60, ErrorMessage = "MaxLength is 60")]
        public string CustomerName { get; set; }

        public EmployeeDTO Employee { get; set; }

        [MaxLength(200, ErrorMessage = "MaxLength is 200")]
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
