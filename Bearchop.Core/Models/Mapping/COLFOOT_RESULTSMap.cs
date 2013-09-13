using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class COLFOOT_RESULTSMap : EntityTypeConfiguration<COLFOOT_RESULTS>
    {
        public COLFOOT_RESULTSMap()
        {
            // Primary Key
            this.HasKey(t => new { t.TeamID, t.Week });

            // Properties
            this.Property(t => t.TeamID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("COLFOOT_RESULTS");
            this.Property(t => t.TeamID).HasColumnName("TeamID");
            this.Property(t => t.Week).HasColumnName("Week");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.WinLoss).HasColumnName("WinLoss");
            this.Property(t => t.Score).HasColumnName("Score");
            this.Property(t => t.OPass).HasColumnName("OPass");
            this.Property(t => t.ORush).HasColumnName("ORush");
            this.Property(t => t.TA).HasColumnName("TA");
            this.Property(t => t.DPass).HasColumnName("DPass");
            this.Property(t => t.DRush).HasColumnName("DRush");
            this.Property(t => t.TF).HasColumnName("TF");
            this.Property(t => t.Points).HasColumnName("Points");

            // Relationships
            //this.HasRequired(t => t.COLFOOT_TEAM)
            //    .WithMany(t => t.COLFOOT_RESULTS)
            //    .HasForeignKey(d => d.TeamID);

        }
    }
}
