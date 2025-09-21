using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Assignment_S02_EFCore.Models.Musician
{
    [Table("Musicians")]
    internal class Musician
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public int Ph_Number { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        
        public ICollection<Album> AlbumsProduction { get; set; } = new HashSet<Album>();
        public ICollection<Mus_Instrument> PlayedInstrument { get; set; } = new HashSet<Mus_Instrument>();
        public ICollection<Mus_Song> PerformedSongs { get; set; } = new HashSet<Mus_Song>();
    }
}
