using System.Data.Entity.ModelConfiguration;
using DAL.entities;

namespace DAL.dbConfigurations
{
    public class PlaylistEntityConfiguration : EntityTypeConfiguration<Playlist>
    {
        public PlaylistEntityConfiguration()
        {
            ToTable("Playlist").HasKey<int>(t => t.Id)
                .Property(c => c.Id)
                .HasColumnName("Id")
                .HasColumnOrder(0)
                .HasColumnType("int")
                .IsRequired();

            Property(c => c.Title)
                .HasColumnName("Title")
                .HasColumnOrder(1)
                .HasColumnType("varchar")
                .IsRequired();
        }
    }
}
