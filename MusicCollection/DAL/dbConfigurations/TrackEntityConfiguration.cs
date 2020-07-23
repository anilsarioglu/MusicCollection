using System.Data.Entity.ModelConfiguration;
using DAL.entities;

namespace DAL.dbConfigurations
{
    public class TrackEntityConfiguration : EntityTypeConfiguration<Track>
    {
        public TrackEntityConfiguration()
        {
            ToTable("Track").HasKey<int>(t => t.Id)
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

            Property(c => c.Duration)
                .HasColumnName("Duration")
                .HasColumnOrder(2)
                .HasColumnType("int")
                .IsRequired();

            Property(c => c.Label)
                .HasColumnName("Label")
                .HasColumnOrder(3)
                .HasColumnType("varchar")
                .IsRequired();
        }
    }
}
