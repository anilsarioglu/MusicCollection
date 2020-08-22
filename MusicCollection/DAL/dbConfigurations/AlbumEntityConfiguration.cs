using System.Data.Entity.ModelConfiguration;
using Domain;

namespace DAL.dbConfigurations
{
    public class AlbumEntityConfiguration : EntityTypeConfiguration<Album>
    {
        public AlbumEntityConfiguration()
        {
            ToTable("Album").HasKey<int>(t => t.Id)
                .Property(c => c.Id)
                .HasColumnName("Id")
                .HasColumnOrder(0)
                .HasColumnType("int")
                .IsRequired();

            Property(c => c.ArtistId)
                .HasColumnName("ArtistId")
                .HasColumnOrder(1)
                .HasColumnType("int")
                .IsRequired();

            Property(c => c.Name)
                .HasColumnName("Name")
                .HasColumnOrder(2)
                .HasColumnType("varchar")
                .IsRequired();

            Property(c => c.ReleaseDate)
                .HasColumnName("ReleaseDate")
                .HasColumnOrder(3)
                .HasColumnType("date")
                .IsRequired();

            this.HasRequired<Artist>(i => i.Artist)
                .WithMany(c => c.AlbumList)
                .HasForeignKey<int>(i => i.ArtistId);
        }
    }
}
