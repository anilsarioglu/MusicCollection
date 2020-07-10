using System.Data.Entity.ModelConfiguration;
using DAL.entities;

namespace DAL.dbConfigurations
{
    public class ArtistEntityConfiguration : EntityTypeConfiguration<Artist>
    {
        public ArtistEntityConfiguration()
        {
            ToTable("Artist").HasKey<int>(t => t.Id)
                .Property(c => c.Id)
                .HasColumnName("Id")
                .HasColumnOrder(0)
                .HasColumnType("int")
                .IsRequired();

            Property(c => c.LastName)
                .HasColumnName("LastName")
                .HasColumnOrder(1)
                .HasColumnType("varchar")
                .IsRequired();

            Property(c => c.FirstName)
                .HasColumnName("FirstName")
                .HasColumnOrder(2)
                .HasColumnType("varchar")
                .IsRequired();

            Property(c => c.ArtistName)
                .HasColumnName("ArtistName")
                .HasColumnOrder(3)
                .HasColumnType("varchar")
                .IsRequired();

            Property(c => c.Birthdate)
                .HasColumnName("Birthdate")
                .HasColumnOrder(4)
                .HasColumnType("date")
                .IsRequired();
        }
    }
}
