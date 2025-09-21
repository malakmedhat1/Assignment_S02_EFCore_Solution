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

    }
}
