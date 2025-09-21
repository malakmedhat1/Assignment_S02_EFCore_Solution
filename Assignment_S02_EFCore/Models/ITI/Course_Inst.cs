using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_S02_EFCore.Models.ITI
{
    [PrimaryKey(nameof(InstId), nameof(CourseId))]
    internal class Course_Inst
    {
        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }

        [ForeignKey(nameof(Instructor))]
        public int InstId { get; set; }
        public decimal Evaluate { get; set; }
        public Course Course { get; set; } = null!;
        public Instructor Instructor { get; set; } = null!;
    }
}
