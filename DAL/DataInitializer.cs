using System;
using System.Collections.Generic;
using System.Data.Entity;
using DAL.Entities;

namespace DAL
{
    public class DataInitializer : DropCreateDatabaseAlways<DemoAppDbContext>
    {
        protected override void Seed(DemoAppDbContext context)
        {
            var employee1 = new Employee()
            {
                FirstName = "Leslie",
                LastName = "Knope",
            };

            var employee2 = new Employee
            {
                FirstName = "Tom",
                LastName = "Haverford"
            };

            var employee3 = new Employee
            {
                FirstName = "Ron",
                LastName = "Swanson"
            };

            var employee4 = new Employee
            {
                FirstName = "April",
                LastName = "Ludgate"
            };

            context.Employees.AddRange(new []{employee1, employee2, employee3, employee4});

            var company1 = new Company
            {
                Name = "Google",
                ICO = "12345678",
                Contact = "google@gmail.com"
            };

            var company2 = new Company
            {
                Name = "Amazon",
                ICO = "87654321",
                Contact = "amazon.com"
            };

            context.Companies.AddRange(new []{company1, company2});

            var person = new Person
            {
                FirstName = "Steve",
                LastName = "Jobs",
                Contact = "steve@apple.com"
            };

            context.Persons.Add(person);

            var project1 = new Project
            {
                Name = "YouTube",
                Customer = company1,
            };

            var project2 = new Project
            {
                Name = "IPhone",
                Customer = person
            };

            context.Projects.AddRange(new []{project1, project2});

            var issue1 = new Issue
            {
                Project = project1,
                Description = "Videos can't be played",
                Employee = employee1,
                CustomerName = company1.Name,
                Type = IssueType.Bug,
                End = DateTime.UtcNow
            };

            context.Issues.AddRange(new[] {issue1});
            context.SaveChanges();

            base.Seed(context);

        }
    }
}
