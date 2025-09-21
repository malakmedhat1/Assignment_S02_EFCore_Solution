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
    //internal class Course
    //{
    //    public int Id { get; set; }
    //    public string? Name { get; set; }
    //    public int Duration { get; set; }
    //    public string? Description { get; set; }
    //    public int Top_ID { get; set; }
    //} 
    #endregion

    #region Data Annotation
    [Table("Courses")]
    internal class Course
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Student Name Must Be At Most 50 Char and At Least 3 Char")]
        public string? Name { get; set; }
        public int Duration { get; set; }
        public string? Description { get; set; }
        public int Top_ID { get; set; }

        public int ClassifiedTopicID { get; set; }
        [InverseProperty(nameof(Topic.ClassifiedCourses))]
        public Topic ClassifiedTopic { get; set; } = null!;

        public ICollection<Stud_Course> CourseStudents { get; set; } = new HashSet<Stud_Course>();

        public ICollection<Course_Inst> CourseInstructors { get; set; } = new HashSet<Course_Inst>();
    }
    #endregion
}
