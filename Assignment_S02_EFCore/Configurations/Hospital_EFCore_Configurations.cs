using Assignment_S02_EFCore.Models.Hospital;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_S02_EFCore.Configurations
{
    internal class Hospital_EFCore_Configurations : IEntityTypeConfiguration<Drugs>, IEntityTypeConfiguration<DrugBrand>, 
                                                    IEntityTypeConfiguration<NurseDrugPatient>, IEntityTypeConfiguration<Patient>,
                                                    IEntityTypeConfiguration<Consultant>, IEntityTypeConfiguration<Nurse>,
                                                    IEntityTypeConfiguration<PatientConsultant>, IEntityTypeConfiguration<Ward>
    {
        public void Configure(EntityTypeBuilder<Drugs> builder)
        {
        }
        public void Configure(EntityTypeBuilder<DrugBrand> builder)
        {
        }
        public void Configure(EntityTypeBuilder<NurseDrugPatient> builder)
        {
            
            builder.HasOne(ndp => ndp.Nurse).WithMany().HasForeignKey(ndp => ndp.NurseID);
            builder.HasOne(ndp => ndp.Drugs).WithMany().HasForeignKey(ndp => ndp.DrugCode);
            builder.HasOne(ndp => ndp.Patient).WithMany().HasForeignKey(ndp => ndp.PatientId);
        }

        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            throw new NotImplementedException();
        }

        public void Configure(EntityTypeBuilder<Consultant> builder)
        {
            throw new NotImplementedException();
        }

        public void Configure(EntityTypeBuilder<Nurse> builder)
        {
            builder.HasOne(n => n.SupervisedWard)
                .WithOne(w => w.Supervisor)
                .HasForeignKey<Ward>(w => w.SupervisorId);
        }

        public void Configure(EntityTypeBuilder<PatientConsultant> builder)
        {
            throw new NotImplementedException();
        }

        public void Configure(EntityTypeBuilder<Ward> builder)
        {
            builder.HasOne(w => w.Supervisor)
                .WithOne(n => n.SupervisedWard)
                .HasForeignKey<Ward>(w => w.SupervisorId);
        }
    }
    
}
