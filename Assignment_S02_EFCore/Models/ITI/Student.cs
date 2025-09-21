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
    //internal class Student
    //{
    //    public int Id { get; set; }
    //    public string? FName { get; set; }
    //    public string? LName { get; set; }
    //    public string? Address { get; set; }
    //    public int Age { get; set; }
    //    public int Dept_ID { get; set; }
    //} 
    #endregion

    #region Data Annotation

    [Table("Students")]
    internal class Student
    {
        [Key]
        public int StudId { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        //[MaxLength(50, ErrorMessage ="Student Name Must Be At Most 50 Char")]
        //[MinLength(3, ErrorMessage = "Student Name Must Be At Least 3 Char")]
        [StringLength(50,MinimumLength =3, ErrorMessage = "Student Name Must Be At Most 50 Char and At Least 3 Char")]
        public string? FName { get; set; }
        public string? LName { get; set; }
        public string? Address { get; set; }
        [Column("StudentAge")]
        [Range(18,30)]
        [DeniedValues(15,35,36,37)]
        public int Age { get; set; }
        // Foreign Key
        public int LocatedDepartmentID { get; set; }
        public Department LocatedDepartment { get; set; } = null!;

        public ICollection<Stud_Course> StudentsCourses { get; set; } = new HashSet<Stud_Course>();

    }

    #endregion
}
