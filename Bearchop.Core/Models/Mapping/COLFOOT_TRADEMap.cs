using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class COLFOOT_TRADEMap : EntityTypeConfiguration<COLFOOT_TRADE>
    {
        public COLFOOT_TRADEMap()
        {
            // Primary Key
            this.HasKey(t => new { t.UserID, t.Week });

            // Properties
            this.Property(t => t.UserID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Team1_Name)
                .HasMaxLength(15);

            this.Property(t => t.Team2_Name)
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("COLFOOT_TRADE");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.Week).HasColumnName("Week");
            this.Property(t => t.Team1).HasColumnName("Team1");
            this.Property(t => t.Team2).HasColumnName("Team2");
            this.Property(t => t.Team1_Name).HasColumnName("Team1_Name");
            this.Property(t => t.Team2_Name).HasColumnName("Team2_Name");
        }
    }
}
