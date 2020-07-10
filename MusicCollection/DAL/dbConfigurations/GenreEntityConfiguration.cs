using System.Data.Entity.ModelConfiguration;
using DAL.entities;

namespace DAL.dbConfigurations
{
    public class GenreEntityConfiguration : EntityTypeConfiguration<Genre>
    {
        public GenreEntityConfiguration()
        {
            ToTable("Genre").HasKey<int>(t => t.Id)
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
        }
    }
}
