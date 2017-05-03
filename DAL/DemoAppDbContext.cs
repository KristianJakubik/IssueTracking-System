using System.Data.Entity;
using DAL.Entities;

namespace DAL
{
    public class DemoAppDbContext : DbContext
    {
        public DemoAppDbContext(): base("IssueTracker")
        {
            Database.SetInitializer(new DataInitializer());
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Issue> Issues { get; set; }
    }
}
