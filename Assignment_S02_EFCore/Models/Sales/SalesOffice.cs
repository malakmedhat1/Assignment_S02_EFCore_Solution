using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_S02_EFCore.Models.Sales
{
    [Table("SalesOffices")]
    internal class SalesOffice
    {
        [Key]
        public int Number { get; set; }
        public string? Location { get; set; }

        [ForeignKey(nameof(Employee))]
        public int ManagerId { get; set; }
        [InverseProperty(nameof(Employee.ManagedOffice))]
        public Employee Manger { get; set; } = null!;


        public ICollection<Employee> AssignedEmployee { get; set; } = new HashSet<Employee>();
        public ICollection<Property> ListsOfProperties { get; set; } = new HashSet<Property>();
    }
}
