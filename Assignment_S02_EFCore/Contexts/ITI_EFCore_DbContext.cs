using Assignment_S02_EFCore.Models.ITI;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Assignment_S02_EFCore.Contexts
{
    internal class ITI_EFCore_DbContext : DbContext
    {
        public ITI_EFCore_DbContext() : base()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ITI_EFCore_DB;Integrated Security=True;Encrypt=False");
            optionsBuilder.UseSqlServer("Server = .; Database = ITI_EFCore_DB; Trusted_Connection = true; TrustServerCertificate = true");
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; } 
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Topic> Topics { get; set; }
    }
}
