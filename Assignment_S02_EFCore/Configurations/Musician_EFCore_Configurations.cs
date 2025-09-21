using Assignment_S02_EFCore.Models.Musician;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_S02_EFCore.Configurations
{
    internal class Musician_EFCore_Configurations : IEntityTypeConfiguration<Mus_Instrument>, IEntityTypeConfiguration<Mus_Song>, 
                                                    IEntityTypeConfiguration<Album_Song>, IEntityTypeConfiguration<Album>
    {

        public void Configure(EntityTypeBuilder<Mus_Instrument> builder)
        {
            builder.HasKey(mi => new { mi.MusicianId, mi.InstrumentId });
            
            builder.HasOne(mi => mi.Musician)
                   .WithMany(m => m.PlayedInstrument)
                   .HasForeignKey(mi => mi.MusicianId);
            
            builder.HasOne(mi => mi.Instrument)
                     .WithMany(i => i.InstrumentPlayed)
                     .HasForeignKey(mi => mi.InstrumentId);
        }

        public void Configure(EntityTypeBuilder<Mus_Song> builder)
        {
            builder.HasKey(ms => new { ms.MusicianId, ms.SongTitle });
            
            builder.HasOne(ms => ms.Musician)
                   .WithMany(m => m.PerformedSongs)
                   .HasForeignKey(ms => ms.MusicianId);
            
            builder.HasOne(ms => ms.Song)
                     .WithMany(s => s.SongsPerformed)
                     .HasForeignKey(ms => ms.SongTitle);
        }

        public void Configure(EntityTypeBuilder<Album_Song> builder)
        {
            builder.HasKey(asg => new { asg.SongTitle, asg.AlbumId });
            
            builder.HasOne(asg => asg.Album)
                   .WithMany(a => a.ContainSongs)
                   .HasForeignKey(asg => asg.AlbumId);
            
            builder.HasOne(asg => asg.Song)
                     .WithMany(s => s.SongsInAlbum)
                     .HasForeignKey(asg => asg.SongTitle);

        }

        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.HasOne(a => a.MusicianProduction)
                   .WithMany(m => m.AlbumsProduction)
                   .HasForeignKey(a => a.MusicianProductionId);
        }

    }
    
    
}
