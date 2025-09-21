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
    //internal class Topic
    //{
    //    public int Id { get; set; }
    //    public string? Name { get; set; }
    //} 
    #endregion

    #region Data Annotation
    [Table("Topics")]
    internal class Topic
    {
        public int Id { get; set; }
        
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Student Name Must Be At Most 50 Char and At Least 3 Char")]
        public string? Name { get; set; }
        [InverseProperty(nameof(Course.ClassifiedTopic))]
        public ICollection<Course> ClassifiedCourses { get; set; } = new HashSet<Course>();
    }
    #endregion
}
