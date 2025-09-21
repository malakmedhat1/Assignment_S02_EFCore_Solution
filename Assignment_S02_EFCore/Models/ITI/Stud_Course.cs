using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_S02_EFCore.Models.ITI
{
    [PrimaryKey(nameof(StudId),nameof(CourseId))]
    internal class Stud_Course
    {
        [ForeignKey(nameof(Student))]
        public int StudId { get; set; }

        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        public decimal Grade { get; set; }

        public Student Student { get; set; } = null!;
        public Course Course { get; set; } = null!;
    }
}
