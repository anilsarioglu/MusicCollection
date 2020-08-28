using System.Data.Entity.ModelConfiguration;
using Domain;

namespace DAL.DbConfigurations
{
    public class TrackGenreEntityConfiguration : EntityTypeConfiguration<TrackGenre>
    {
        public TrackGenreEntityConfiguration()
        {
            ToTable("TrackGenre").HasKey<int>(t => t.Id)
                .Property(c => c.Id)
                .HasColumnName("Id")
                .HasColumnOrder(0)
                .HasColumnType("int")
                .IsRequired();

            Property(c => c.TrackId)
                .HasColumnName("TrackId")
                .HasColumnOrder(1)
                .HasColumnType("int")
                .IsRequired();

            Property(c => c.GenreId)
                .HasColumnName("GenreId")
                .HasColumnOrder(2)
                .HasColumnType("int")
                .IsRequired();

            this.HasRequired<Track>(i => i.Track)
                .WithMany(c => c.TrackGenreList)
                .HasForeignKey<int>(i => i.TrackId);

            this.HasRequired<Genre>(i => i.Genre)
                .WithMany(c => c.TrackGenreList)
                .HasForeignKey<int>(i => i.GenreId);
        }
    }
}
