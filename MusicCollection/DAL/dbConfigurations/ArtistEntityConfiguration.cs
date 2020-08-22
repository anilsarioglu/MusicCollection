using System.Data.Entity.ModelConfiguration;
using Domain;

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

            Property(c => c.Name)
                .HasColumnName("Name")
                .HasColumnOrder(1)
                .HasColumnType("varchar")
                .IsRequired();

            Property(c => c.Birthdate)
                .HasColumnName("Birthdate")
                .HasColumnOrder(2)
                .HasColumnType("date")
                .IsRequired();
        }
    }
}
