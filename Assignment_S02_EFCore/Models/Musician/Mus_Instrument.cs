using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Assignment_S02_EFCore.Models.Musician
{
    [PrimaryKey(nameof(MusicianId), nameof(InstrumentId))]
    internal class Mus_Instrument
    {
        [ForeignKey(nameof(Musician))]
        public int MusicianId { get; set; }
        [ForeignKey(nameof(Instrument))]
        public int InstrumentId { get; set; }
        public Musician? Musician { get; set; }
        public Instrument? Instrument { get; set; }
    }
}
