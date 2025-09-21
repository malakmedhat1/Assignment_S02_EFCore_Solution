using Assignment_S02_EFCore.Models.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_S02_EFCore.Configurations
{
    internal class Sales_EFCore_Configurations : IEntityTypeConfiguration<SalesOffice>, IEntityTypeConfiguration<Employee>,
                                                 IEntityTypeConfiguration<Property>, IEntityTypeConfiguration<Prop_Owner>
    {
        public void Configure(EntityTypeBuilder<SalesOffice> builder)
        {
            builder.HasOne(SO => SO.Manger)
                .WithOne(e => e.ManagedOffice)
                .HasForeignKey<SalesOffice>(SO => SO.ManagerId);
        }

        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasOne(e => e.AssignedOffice)
                .WithMany(SO => SO.AssignedEmployee)
                .HasForeignKey(e => e.AssignedOfficeID)
                .OnDelete(DeleteBehavior.NoAction);
        }

        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.HasOne(p=>p.ListedOffice)
                .WithMany(SO =>SO.ListsOfProperties)
                .HasForeignKey(p => p.ListedOfficeID);
        }

        public void Configure(EntityTypeBuilder<Prop_Owner> builder)
        {
            builder.HasKey(po => new { po.OwnId, po.PropId });

            builder.HasOne(po => po.Owner)
                   .WithMany(o => o.OwnedProperties)
                   .HasForeignKey(po => po.OwnId);

            builder.HasOne(po => po.Property)
                     .WithMany(p => p.PropertiesOwned)
                     .HasForeignKey(po => po.PropId);
        }
    }
}
