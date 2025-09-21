using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_S02_EFCore.Models.Sales
{
    [Table("Employees")]
    internal class Employee
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }

        [InverseProperty(nameof(SalesOffice.Manger))]
        public SalesOffice? ManagedOffice { get; set; }

        [InverseProperty(nameof(SalesOffice.AssignedEmployee))]
        public SalesOffice AssignedOffice { get; set; }

        [ForeignKey(nameof(SalesOffice.AssignedEmployee))]
        public int? AssignedOfficeID { get; set; }
    }
}
