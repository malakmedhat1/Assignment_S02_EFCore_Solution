using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Assignment_S02_EFCore.Models.Hospital
{
    [PrimaryKey(nameof(NurseID), nameof(DrugCode), nameof(PatientId))]
    internal class NurseDrugPatient
    {
        
        [ForeignKey(nameof(Nurse))]
        public int NurseID { get; set; }
        public Nurse? Nurse { get; set; }

        [ForeignKey(nameof(Drugs))]

        public string DrugCode { get; set; }
        public Drugs? Drugs { get; set; }
        [ForeignKey(nameof(Patient))]
        public int PatientId { get; set; }
        public Patient? Patient { get; set; }

        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public string? Dosage { get; set; }
    }
}
