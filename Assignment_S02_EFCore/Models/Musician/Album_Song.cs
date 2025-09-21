using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Assignment_S02_EFCore.Models.Musician
{
    [PrimaryKey(nameof(SongTitle), nameof(AlbumId))]
    internal class Album_Song
    {
        [ForeignKey(nameof(Song))]
        public string? SongTitle { get; set; }
        [ForeignKey(nameof(Album))]
        public int AlbumId { get; set; }

        public Album? Album { get; set; }

        public Song? Song { get; set; }
    }
}
