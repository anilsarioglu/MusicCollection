using System.Data.Entity.ModelConfiguration;
using DAL.entities;

namespace DAL.dbConfigurations
{
    public class SongEntityConfiguration : EntityTypeConfiguration<Song>
    {
        public SongEntityConfiguration()
        {
            ToTable("Song").HasKey<int>(t => t.Id)
                .Property(c => c.Id)
                .HasColumnName("Id")
                .HasColumnOrder(0)
                .HasColumnType("int")
                .IsRequired();

            Property(c => c.GenreId)
                .HasColumnName("GenreId")
                .HasColumnOrder(1)
                .HasColumnType("int")
                .IsRequired();

            Property(c => c.Title)
                .HasColumnName("Title")
                .HasColumnOrder(2)
                .HasColumnType("varchar")
                .IsRequired();

            Property(c => c.Duration)
                .HasColumnName("Duration")
                .HasColumnOrder(3)
                .HasColumnType("int")
                .IsRequired();

            Property(c => c.Label)
                .HasColumnName("Label")
                .HasColumnOrder(4)
                .HasColumnType("varchar")
                .IsRequired();

            this.HasRequired<Genre>(i => i.Genre)
                .WithMany(c => c.SongList)
                .HasForeignKey<int>(i => i.GenreId);
        }
    }
}
