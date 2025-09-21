using Assignment_S02_EFCore.Models.Airline;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_S02_EFCore.Configurations
{
    internal class Airline_EFCore_Configurations :  IEntityTypeConfiguration<AircraftRoutes>,IEntityTypeConfiguration<Employee>,
                                                    IEntityTypeConfiguration<Transaction>, IEntityTypeConfiguration<AirCraft>,
                                                    IEntityTypeConfiguration<AirlinePhones>, IEntityTypeConfiguration<EmployeeQualifications>
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

        public void Configure(EntityTypeBuilder<AirlinePhones> builder)
        {
            builder.HasKey(ap => new { ap.AirLineId, ap.PhoneNumber });
            builder.HasOne(ap => ap.AirLine)
                   .WithMany(al => al.ContactNumbers)
                   .HasForeignKey(ap => ap.AirLineId)
                   .OnDelete(DeleteBehavior.Cascade);
        }

        public void Configure(EntityTypeBuilder<EmployeeQualifications> builder)
        {
            builder.HasKey(eq => new { eq.EmployeeId, eq.QualificationName });
            builder.HasOne(eq => eq.Employee)
                   .WithMany(e => e.Qualifications)
                   .HasForeignKey(eq => eq.EmployeeId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
