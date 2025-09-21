using Assignment_S02_EFCore.Models.Musician;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Assignment_S02_EFCore.Contexts
{
    internal class Musician_EFCore_DbContext : DbContext
    {
        public Musician_EFCore_DbContext() : base()
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ITI_EFCore_DB;Integrated Security=True;Encrypt=False");
            optionsBuilder.UseSqlServer("Server = .; Database = Musician_EFCore_DB; Trusted_Connection = true; TrustServerCertificate = true");
        }
        public DbSet<Musician> Musicians { get; set; }
        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Album_Song> Album_Songs { get; set; }
        public DbSet<Mus_Instrument> Mus_Instruments { get; set; }
        public DbSet<Mus_Song> Mus_Songs { get; set; }


        }
}
