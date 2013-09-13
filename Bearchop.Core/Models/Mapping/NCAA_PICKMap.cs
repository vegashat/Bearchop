using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class NCAA_PICKMap : EntityTypeConfiguration<NCAA_PICK>
    {
        public NCAA_PICKMap()
        {
            // Primary Key
            this.HasKey(t => new { t.UserID, t.GameID });

            // Properties
            this.Property(t => t.UserID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.GameID)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(4);

            this.Property(t => t.TeamPick)
                .IsFixedLength()
                .HasMaxLength(4);

            // Table & Column Mappings
            this.ToTable("NCAA_PICK");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.GameID).HasColumnName("GameID");
            this.Property(t => t.TeamPick).HasColumnName("TeamPick");
            this.Property(t => t.Points).HasColumnName("Points");

            // Relationships
            this.HasRequired(t => t.NCAA_GAME)
                .WithMany(t => t.NCAA_PICK)
                .HasForeignKey(d => d.GameID);
            this.HasRequired(t => t.NCAA_PLAYER)
                .WithMany(t => t.NCAA_PICK)
                .HasForeignKey(d => d.UserID);
            this.HasOptional(t => t.NCAA_TEAM)
                .WithMany(t => t.NCAA_PICK)
                .HasForeignKey(d => d.TeamPick);

        }
    }
}
