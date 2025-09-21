using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Assignment_S02_EFCore.Models.Hospital
{
    [Table("Consultants")]
    internal class Consultant
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }

        public ICollection<Patient> AssignedPatients { get; set; } = new HashSet<Patient>();

        public ICollection<PatientConsultant> ExaminePatients { get; set; } = new HashSet<PatientConsultant>();

    }
}
