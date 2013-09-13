using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class NB12_PICKMap : EntityTypeConfiguration<NB12_PICK>
    {
        public NB12_PICKMap()
        {
            // Primary Key
            this.HasKey(t => t.Pick);

            // Properties
            this.Property(t => t.Pick)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.UserName)
                .HasMaxLength(15);

            this.Property(t => t.Player)
                .HasMaxLength(20);

            this.Property(t => t.Pos)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.Team)
                .HasMaxLength(3);

            this.Property(t => t.Acquired)
                .IsFixedLength()
                .HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("NB12_PICK");
            this.Property(t => t.Pick).HasColumnName("Pick");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.Player).HasColumnName("Player");
            this.Property(t => t.Pos).HasColumnName("Pos");
            this.Property(t => t.Team).HasColumnName("Team");
            this.Property(t => t.Points).HasColumnName("Points");
            this.Property(t => t.Acquired).HasColumnName("Acquired");
            this.Property(t => t.ActiveFlag).HasColumnName("ActiveFlag");
            this.Property(t => t.PriorWeek).HasColumnName("PriorWeek");
            this.Property(t => t.PriorGame).HasColumnName("PriorGame");
            this.Property(t => t.PriorPoints).HasColumnName("PriorPoints");
        }
    }
}
