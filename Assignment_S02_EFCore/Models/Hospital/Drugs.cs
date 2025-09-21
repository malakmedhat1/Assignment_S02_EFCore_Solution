using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Assignment_S02_EFCore.Models.Hospital
{
    [Table("Drugs")]
    internal class Drugs
    {
        [Key]
        public string Code { get; set; }
        [Required]
        public string Dosage { get; set; }

        public ICollection<NurseDrugPatient> DrugGived { get; set; } = new HashSet<NurseDrugPatient>();
    }
}
