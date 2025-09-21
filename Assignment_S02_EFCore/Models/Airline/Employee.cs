using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Assignment_S02_EFCore.Models.Airline
{
    [Table("Employees", Schema = "Airline")]
    internal class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required, MaxLength(50)]
        public string Address { get; set; }
        [Required, MaxLength(50)]
        public string Position { get; set; }
        
        public enum Gender { Male = 0, Female = 1, Other = 2 }
        public Gender gender;

        public DateOnly hiredate { get; set; }

        [ForeignKey(nameof(AirLine.WorkingEmployee))]
        public int EmployeeWorkingId { get; set; }
        public AirLine EmployeeWorking { get; set; }= null!;
    }
}
