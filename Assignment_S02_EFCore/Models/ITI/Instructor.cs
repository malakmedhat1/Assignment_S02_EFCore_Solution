using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_S02_EFCore.Models.ITI
{
    #region By Convention
    //internal class Instructor
    //{
    //    public int Id { get; set; }
    //    public string? Name { get; set; }
    //    public decimal Bonus { get; set; }
    //    public decimal Salary { get; set; }
    //    public string? Address { get; set; }
    //    public decimal HourRate { get; set; }
    //    public int Dept_ID { get; set; }
    //} 
    #endregion

    #region Data Annotation
    [Table("Instructors")]
    internal class Instructor
    {

        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Student Name Must Be At Most 50 Char and At Least 3 Char")]
        public string? Name { get; set; }
        
        [DataType(DataType.Currency)]
        public decimal Bonus { get; set; }

        [DataType(DataType.Currency)]
        [Column("InstructorSalary", TypeName = "decimal(10,2)")]
        public decimal Salary { get; set; }
        public string? Address { get; set; }
        public float HourRate { get; set; }

        [InverseProperty(nameof(Department.Manager))]
        public Department? ManagedDepartment { get; set; }

        // Foreign Key
        public int ContainedDepartmentID { get; set; }
        [InverseProperty(nameof(Department.ContainedInstructors))]
        public Department? ContainedDepartment { get; set; }= null!;

        public ICollection<Course_Inst> InstructedCourses { get; set; } = new HashSet<Course_Inst>();
    }
    #endregion
}
