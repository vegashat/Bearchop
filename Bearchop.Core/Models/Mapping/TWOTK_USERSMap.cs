using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class TWOTK_USERSMap : EntityTypeConfiguration<TWOTK_USERS>
    {
        public TWOTK_USERSMap()
        {
            // Primary Key
            this.HasKey(t => t.UserID);

            // Properties
            this.Property(t => t.UserID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.UserName)
                .HasMaxLength(15);

            this.Property(t => t.Name)
                .HasMaxLength(50);

            this.Property(t => t.ShirtSize)
                .HasMaxLength(3);

            // Table & Column Mappings
            this.ToTable("TWOTK_USERS");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.Pushups).HasColumnName("Pushups");
            this.Property(t => t.PushupsCompleted).HasColumnName("PushupsCompleted");
            this.Property(t => t.Situps).HasColumnName("Situps");
            this.Property(t => t.SitupsCompleted).HasColumnName("SitupsCompleted");
            this.Property(t => t.ShirtSize).HasColumnName("ShirtSize");
        }
    }
}
