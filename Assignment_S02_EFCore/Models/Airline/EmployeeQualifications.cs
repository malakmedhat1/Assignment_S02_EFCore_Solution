using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Assignment_S02_EFCore.Models.Airline
{
    [PrimaryKey(nameof(EmployeeId), nameof(QualificationName))]
    internal class EmployeeQualifications
    {
        
        [Required, MaxLength(50)]
        public string QualificationName { get; set; }
        
        [ForeignKey(nameof(Employee))]
        public int EmployeeId { get; set; }
    }
}
