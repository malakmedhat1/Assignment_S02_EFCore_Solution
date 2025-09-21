using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Assignment_S02_EFCore.Models.Hospital
{
    [PrimaryKey(nameof(PatientId),nameof(ConsultantId))]
    internal class PatientConsultant
    {
        [ForeignKey(nameof(Patient))]
        public int PatientId { get; set; }
        public Patient? Patient { get; set; }
        [ForeignKey(nameof(Consultant))]
        public int ConsultantId { get; set; }
        public Consultant? Consultant { get; set; }
    }
}
