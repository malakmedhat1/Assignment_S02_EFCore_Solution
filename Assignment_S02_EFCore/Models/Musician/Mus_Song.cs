using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Assignment_S02_EFCore.Models.Musician
{
    [PrimaryKey(nameof(MusicianId), nameof(SongTitle))]
    internal class Mus_Song
    {
        [ForeignKey(nameof(Musician))]
        public int MusicianId { get; set; }
        [ForeignKey(nameof(Song))]
        public string? SongTitle { get; set; }
        public Musician? Musician { get; set; }
        public Song? Song { get; set; }
    }
}
