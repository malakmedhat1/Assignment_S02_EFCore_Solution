using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_S02_EFCore.Models.ITI
{
    #region By Convention
    //internal class Department
    //{
    //    public int Id { get; set; }
    //    public string? Name { get; set; }
    //    public int Ins_Id { get; set; }
    //    public DateTime HiringDate { get; set; }
    //} 
    #endregion

    #region Data Annotation

    [Table("Departments")]
    internal class Department
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Student Name Must Be At Most 50 Char and At Least 3 Char")]
        public string? Name { get; set; }
        // Foreign Key 
        [ForeignKey(nameof(Instructor))]
        public int? ManagerId { get; set; }
        
        [InverseProperty(nameof(Instructor.ManagedDepartment))]
        public Instructor Manager { get; set; } = null!;
        public DateTime HiringDate { get; set; }
        public ICollection<Student> LocatedStudents { get; set; } = new HashSet<Student>();

        [InverseProperty(nameof(Instructor.ContainedDepartment))]
        public ICollection<Instructor> ContainedInstructors { get; set; } = new HashSet<Instructor>();

    }
    #endregion
}
