using Assignment_S02_EFCore.Models.Sales;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Assignment_S02_EFCore.Contexts
{
    internal class Sales_EFCore_DbContext : DbContext
    {
        public Sales_EFCore_DbContext() : base()
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = .; Database = Sales_EFCore_DB; Trusted_Connection = true; TrustServerCertificate = true");
        }
        public DbSet<SalesOffice> SalesOffices { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Prop_Owner> Prop_Owners { get; set; }
        public DbSet<Owner> Owners { get; set; }
        }
}
