using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Assignment_S02_EFCore.Models.Airline
{
    [Table("AirLines", Schema = "Airline")]
    internal class AirLine
    {
        [Key]
        public int AirLineId { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required, MaxLength(50)]
        public string Address { get; set; }
        [Required, MaxLength(50)]
        public string? ContPerson { get; set; }

        public ICollection<Employee> WorkingEmployee { get; set; } = new List<Employee>();
        public ICollection<Transaction> RecordedTransactions { get; set; } = new List<Transaction>();
        public ICollection<AirCraft> OwnedCraft { get; set; } = new List<AirCraft>();

        public ICollection<AirlinePhones> ContactNumbers { get; set; } = new List<AirlinePhones>();
    }
}
