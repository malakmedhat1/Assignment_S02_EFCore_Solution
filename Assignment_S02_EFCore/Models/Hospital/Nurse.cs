using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Assignment_S02_EFCore.Models.Hospital
{
    [Table("Nurses")]
    internal class Nurse
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Address { get; set; }

        [InverseProperty(nameof(Ward.Supervisor))]
        public Ward? SupervisedWard { get; set; }

        [ForeignKey(nameof(Ward.ServedNerse))]
        public int? NerseServedId { get; set; }
        [InverseProperty(nameof(Ward.ServedNerse))]
        public Ward? NerseServed { get; set; }
    }
}
