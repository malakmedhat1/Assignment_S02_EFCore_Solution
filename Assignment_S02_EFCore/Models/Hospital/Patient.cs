using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Assignment_S02_EFCore.Models.Hospital
{
    [Table("Patients")]
    internal class Patient
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public DateTime DOB { get; set; }

        [ForeignKey(nameof(Ward.HostPatients))]
        public int? HostWardId { get; set; }
        public Ward? HostWard { get; set; }

        [ForeignKey(nameof(Consultant.AssignedPatients))]
        public int? AssignedConsultantId { get; set; }
        public Consultant? AssignedConsultant { get; set; }

        public ICollection<NurseDrugPatient> PatientDrugGived { get; set; } = new HashSet<NurseDrugPatient>();

        public ICollection<PatientConsultant> PatientsExamine { get; set; } = new HashSet<PatientConsultant>();



    }
}
