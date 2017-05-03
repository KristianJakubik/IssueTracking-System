using AutoMapper;
using BL.DTOs;
using DAL.Entities;

namespace BL
{
    public class Mapping
    {
        public static void Create()
        {
            
            Mapper.CreateMap<CustomerDTO, Customer>()
                .Include<PersonDTO,Person>()
                .Include<CompanyDTO, Company>();

            Mapper.CreateMap<Customer, CustomerDTO>()
                .Include<Person, PersonDTO>()
                .Include<Company, CompanyDTO>();

            Mapper.CreateMap<Company, CompanyDTO>();
            Mapper.CreateMap<CompanyDTO, Company>();

            Mapper.CreateMap<Person, PersonDTO>();
            Mapper.CreateMap<PersonDTO, Person>();

            Mapper.CreateMap<Project, ProjectDTO>();
            Mapper.CreateMap<ProjectDTO, Project>();
            
            Mapper.CreateMap<Issue, IssueDTO>();
            Mapper.CreateMap<IssueDTO, Issue>();

            Mapper.CreateMap<Employee, EmployeeDTO>();
            Mapper.CreateMap<EmployeeDTO, Employee>();

        }
    }
}
