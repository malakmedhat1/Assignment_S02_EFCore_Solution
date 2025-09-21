using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Assignment_S02_EFCore.Models.Musician
{
    [Table("Songs")]
    internal class Song
    {
        [Key]
        public string? Title { get; set; }
        [Required]
        public string? Author { get; set; }

    
        public ICollection<Mus_Song> SongsPerformed { get; set; } = new HashSet<Mus_Song>();
        public ICollection<Album_Song> SongsInAlbum { get; set; } = new HashSet<Album_Song>();


    }
}
