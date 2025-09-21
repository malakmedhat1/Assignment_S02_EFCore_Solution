using Assignment_S02_EFCore.Models.ITI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_S02_EFCore.Configurations
{
    internal interface ITI_EFCore_Configurations :  IEntityTypeConfiguration<Student>, IEntityTypeConfiguration<Instructor>,
                                                    IEntityTypeConfiguration<Course>, IEntityTypeConfiguration<Stud_Course>,
                                                    IEntityTypeConfiguration<Course_Inst>
    {
        void IEntityTypeConfiguration<Student>.Configure(EntityTypeBuilder<Student> builder)
        {
           
            builder.HasOne<Department>(s => s.LocatedDepartment)
                   .WithMany(d => d.LocatedStudents)
                   .HasForeignKey(s => s.LocatedDepartmentID)
                   .OnDelete(DeleteBehavior.Cascade);
        }
        void IEntityTypeConfiguration<Instructor>.Configure(EntityTypeBuilder<Instructor> builder)
        {

            builder.HasOne(i => i.ManagedDepartment)
                   .WithOne(d => d.Manager)
                   .HasForeignKey<Department>(d => d.ManagerId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(i => i.ContainedDepartment)
                   .WithMany(d => d.ContainedInstructors)
                   .HasForeignKey(i => i.ContainedDepartmentID)
                   .OnDelete(DeleteBehavior.Restrict);
        }

        void IEntityTypeConfiguration<Course>.Configure(EntityTypeBuilder<Course> builder)
        {

            builder.HasOne<Topic>(c => c.ClassifiedTopic)
                .WithMany(t => t.ClassifiedCourses)
                .HasForeignKey(c => c.ClassifiedTopicID)
                .OnDelete(DeleteBehavior.Cascade);
        }

        void IEntityTypeConfiguration<Stud_Course>.Configure(EntityTypeBuilder<Stud_Course> builder)
        {

            builder.HasKey(sc => new { sc.StudId, sc.CourseId });


            builder.HasOne(sc => sc.Student)
                    .WithMany(s => s.StudentsCourses)
                    .HasForeignKey(sc => sc.StudId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(sc => sc.Course)
                    .WithMany(c => c.CourseStudents)
                    .HasForeignKey(sc => sc.CourseId)
                    .OnDelete(DeleteBehavior.Cascade);
        }

        void IEntityTypeConfiguration<Course_Inst>.Configure(EntityTypeBuilder<Course_Inst> builder)
        {
            builder.HasKey(ci => new { ci.InstId, ci.CourseId });

            
            builder.HasOne(ci => ci.Instructor)
                .WithMany(i => i.InstructedCourses)
                .HasForeignKey(ci => ci.InstId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ci => ci.Course)
                .WithMany(c => c.CourseInstructors)
                .HasForeignKey(ci => ci.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
        }
        }
}
