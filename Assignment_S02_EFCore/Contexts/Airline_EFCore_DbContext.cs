using Assignment_S02_EFCore.Models.Airline;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Assignment_S02_EFCore.Contexts
{
    internal class Airline_EFCore_DbContext : DbContext
    {
        public Airline_EFCore_DbContext() : base()
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = .; Database = Airline_EFCore_DB; Trusted_Connection = true; TrustServerCertificate = true");
        }
        public DbSet<AirCraft> AirCrafts { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<AircraftRoutes> AircraftRoutes { get; set; }
        public DbSet<AirLine> AirLines { get; set; }
        public DbSet<AirlinePhones> AirlinePhones { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeQualifications> EmployeeQualifications { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

    }
}
