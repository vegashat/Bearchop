using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class GOLF_LINEUPMap : EntityTypeConfiguration<GOLF_LINEUP>
    {
        public GOLF_LINEUPMap()
        {
            // Primary Key
            this.HasKey(t => new { t.UserID, t.GolferID, t.Major });

            // Properties
            this.Property(t => t.UserID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.GolferID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Major)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(3);

            // Table & Column Mappings
            this.ToTable("GOLF_LINEUP");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.GolferID).HasColumnName("GolferID");
            this.Property(t => t.Major).HasColumnName("Major");
            this.Property(t => t.Active_Flag).HasColumnName("Active_Flag");
            this.Property(t => t.Lineup_Value).HasColumnName("Lineup_Value");
            this.Property(t => t.User_Points).HasColumnName("User_Points");
        }
    }
}
