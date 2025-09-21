using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Assignment_S02_EFCore.Models.Musician
{
    [Table("Albums")]
    internal class Album
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey(nameof(Musician.AlbumsProduction))]
        public int MusicianProductionId { get; set; }
        public Musician? MusicianProduction { get; set; }
        
        public ICollection<Album_Song> ContainSongs { get; set; } = new HashSet<Album_Song>();
        
    }
}
