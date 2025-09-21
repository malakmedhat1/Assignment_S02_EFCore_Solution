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

        //[ForeignKey(nameof(Doctor.Consultants))]
        //public int DoctorId { get; set; }
        //public Doctor? Doctor { get; set; }
    }
}
