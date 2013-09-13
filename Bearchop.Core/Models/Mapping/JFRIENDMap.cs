using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class JFRIENDMap : EntityTypeConfiguration<JFRIEND>
    {
        public JFRIENDMap()
        {
            // Primary Key
            this.HasKey(t => new { t.UserID, t.FriendID });

            // Properties
            this.Property(t => t.UserID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.FriendID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("JFRIEND");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.FriendID).HasColumnName("FriendID");
            this.Property(t => t.Status).HasColumnName("Status");

            // Relationships
            this.HasRequired(t => t.JUSER)
                .WithMany(t => t.JFRIENDs)
                .HasForeignKey(d => d.UserID);

        }
    }
}
