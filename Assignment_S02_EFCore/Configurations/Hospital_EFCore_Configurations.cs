using Assignment_S02_EFCore.Models.Hospital;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_S02_EFCore.Configurations
{
    internal class Hospital_EFCore_Configurations : 
                                                    IEntityTypeConfiguration<NurseDrugPatient>, IEntityTypeConfiguration<Patient>,
                                                    IEntityTypeConfiguration<Nurse>, IEntityTypeConfiguration<PatientConsultant>,
                                                    IEntityTypeConfiguration<Ward>, IEntityTypeConfiguration<DrugBrand>
    {
        public void Configure(EntityTypeBuilder<NurseDrugPatient> builder)
        {
            builder.HasKey(ndp => new { ndp.NurseID, ndp.DrugCode, ndp.PatientId });
            
            builder.HasOne(ndp => ndp.Nurse)
                .WithMany(n => n.NurseDrugGived)
                .HasForeignKey(ndp => ndp.NurseID);
            
            builder.HasOne(ndp => ndp.Drugs)
                .WithMany(d => d.DrugGived)
                .HasForeignKey(ndp => ndp.DrugCode);
            
            builder.HasOne(ndp => ndp.Patient)
                .WithMany(p => p.PatientDrugGived)
                .HasForeignKey(ndp => ndp.PatientId);
        }

        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasOne(p => p.HostWard)
                .WithMany(w => w.HostPatients)
                .HasForeignKey(p => p.HostWardId);

            builder.HasOne(p => p.AssignedConsultant)
                .WithMany(c => c.AssignedPatients)
                .HasForeignKey(p => p.AssignedConsultantId);
        }


        public void Configure(EntityTypeBuilder<Nurse> builder)
        {
            builder.HasOne(n => n.SupervisedWard)
                .WithOne(w => w.Supervisor)
                .HasForeignKey<Ward>(w => w.SupervisorId);
        }

        public void Configure(EntityTypeBuilder<PatientConsultant> builder)
        {
            builder.HasKey(pc => new { pc.PatientId, pc.ConsultantId });
            
            builder.HasOne(pc => pc.Patient)
                .WithMany(p => p.PatientsExamine)
                .HasForeignKey(pc => pc.PatientId);
            
            builder.HasOne(pc => pc.Consultant)
                .WithMany(c => c.ExaminePatients)
                .HasForeignKey(pc => pc.ConsultantId);
        }

        public void Configure(EntityTypeBuilder<Ward> builder)
        {
            builder.HasOne(w => w.Supervisor)
                .WithOne(n => n.SupervisedWard)
                .HasForeignKey<Ward>(w => w.SupervisorId);
        }

        public void Configure(EntityTypeBuilder<DrugBrand> builder)
        {
            builder.HasKey(db => new { db.Brand, db.DrugCode });
            builder.HasOne(db => db.Drugs)
                .WithMany(d => d.Brands)
                .HasForeignKey(db => db.DrugCode);
        }
    }
    
}
