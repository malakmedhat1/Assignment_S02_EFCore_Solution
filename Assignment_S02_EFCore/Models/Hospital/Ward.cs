using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Assignment_S02_EFCore.Models.Hospital
{
    [Table("Wards")]
    internal class Ward
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }

        [ForeignKey(nameof(Nurse.SupervisedWard))]
        public int SupervisorId { get; set; }
        [InverseProperty(nameof(Nurse.SupervisedWard))]
        public Nurse Supervisor { get; set; } = null!;

        [InverseProperty(nameof(Nurse.NerseServed))]
        public ICollection<Nurse> ServedNerse { get; set; } = new HashSet<Nurse>();

        public ICollection<Patient> HostPatients { get; set; } = new HashSet<Patient>();    
    }
}
