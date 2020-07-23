using System.Data.Entity;
using DAL.dbConfigurations;
using DAL.entities;

namespace DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("conStr")
        {

        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Track> Tracks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("MusicCollection");

            modelBuilder.Configurations.Add(new AlbumEntityConfiguration());
            modelBuilder.Configurations.Add(new ArtistEntityConfiguration());
            modelBuilder.Configurations.Add(new GenreEntityConfiguration());
            modelBuilder.Configurations.Add(new PlaylistEntityConfiguration());
            modelBuilder.Configurations.Add(new TrackEntityConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
