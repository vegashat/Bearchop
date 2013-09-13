using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class COLFOOTMap : EntityTypeConfiguration<COLFOOT>
    {
        public COLFOOTMap()
        {
            // Primary Key
            this.HasKey(t => new { t.UserID, t.TeamID, t.Week });

            // Properties
            this.Property(t => t.UserID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.TeamID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.UserName)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("COLFOOT");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.TeamID).HasColumnName("TeamID");
            this.Property(t => t.Week).HasColumnName("Week");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.Points).HasColumnName("Points");
            

            // Relationships
            //this.HasRequired(t => t.COLFOOT_TEAM)
            //    .WithMany(t => t.COLFeet)
            //    .HasForeignKey(d => d.TeamID);

        }
    }
}
