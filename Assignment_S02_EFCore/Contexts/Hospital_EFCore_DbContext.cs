using Assignment_S02_EFCore.Models.Hospital;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Assignment_S02_EFCore.Contexts
{
    internal class Hospital_EFCore_DbContext : DbContext
    {
        public Hospital_EFCore_DbContext() : base()
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = .; Database = Hospital_EFCore_DB; Trusted_Connection = true; TrustServerCertificate = true");
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Consultant> consultants { get; set; }
        public DbSet<DrugBrand> drugBrands { get; set; }
        public DbSet<Drugs> Drugs { get; set; }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<NurseDrugPatient> NurseDrugPatients { get; set; }
        public DbSet<PatientConsultant> PatientConsultants { get; set; }
        public DbSet<Ward> Ward { get; set; }
    }
}
