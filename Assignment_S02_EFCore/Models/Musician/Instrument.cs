using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Assignment_S02_EFCore.Models.Musician
{
    [Table("Instruments")]
    internal class Instrument
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }

        public ICollection<Mus_Instrument> InstrumentPlayed { get; set; } = new HashSet<Mus_Instrument>();


    }
}
