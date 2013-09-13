using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class NPPICKMap : EntityTypeConfiguration<NPPICK>
    {
        public NPPICKMap()
        {
            // Primary Key
            this.HasKey(t => t.PickID);

            // Properties
            this.Property(t => t.SeriesId)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(3);

            this.Property(t => t.TeamPickId)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(3);

            // Table & Column Mappings
            this.ToTable("NPPICK");
            this.Property(t => t.PickID).HasColumnName("PickID");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.PickDateTime).HasColumnName("PickDateTime");
            this.Property(t => t.SeriesId).HasColumnName("SeriesId");
            this.Property(t => t.PickedBeforeGame).HasColumnName("PickedBeforeGame");
            this.Property(t => t.TeamPickId).HasColumnName("TeamPickId");
            this.Property(t => t.GamePick).HasColumnName("GamePick");
            this.Property(t => t.PotentialPoints).HasColumnName("PotentialPoints");
            this.Property(t => t.Points).HasColumnName("Points");
            this.Property(t => t.ActivePick).HasColumnName("ActivePick");
        }
    }
}
