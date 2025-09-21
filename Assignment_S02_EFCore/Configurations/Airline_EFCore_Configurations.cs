using Assignment_S02_EFCore.Models.Airline;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_S02_EFCore.Configurations
{
    internal class Airline_EFCore_Configurations :  IEntityTypeConfiguration<AircraftRoutes>,IEntityTypeConfiguration<Employee>,
                                                    IEntityTypeConfiguration<Transaction>, IEntityTypeConfiguration<AirCraft>
    {
        public void Configure(EntityTypeBuilder<AircraftRoutes> builder)
        {
            builder.HasKey(ar => new { ar.AircraftId, ar.RouteId, ar.Depature });

            builder.HasOne(ar => ar.AirCraft)
                .WithMany(ac => ac.AssignedRoutes)
                .HasForeignKey(ar => ar.AircraftId);
            builder.HasOne(ar => ar.Route)
                .WithMany(r => r.RoutesAssigned)
                .HasForeignKey(ar => ar.RouteId);
        }

        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasOne(e => e.EmployeeWorking)
                   .WithMany(ac => ac.WorkingEmployee)
                   .HasForeignKey(e => e.EmployeeWorkingId)
                   .OnDelete(DeleteBehavior.Restrict);
        }

        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasOne(t => t.TransactionsRecorded)
                   .WithMany(al => al.RecordedTransactions)
                   .HasForeignKey(t => t.TransactionsRecordedID)
                   .OnDelete(DeleteBehavior.Restrict);
        }

        public void Configure(EntityTypeBuilder<AirCraft> builder)
        {
            builder.HasOne(ac => ac.AirLineOwning)
                   .WithMany(al => al.OwnedCraft)
                   .HasForeignKey(ac => ac.AirLineOwningId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
