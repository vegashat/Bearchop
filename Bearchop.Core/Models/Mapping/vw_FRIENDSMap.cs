using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class vw_FRIENDSMap : EntityTypeConfiguration<vw_FRIENDS>
    {
        public vw_FRIENDSMap()
        {
            // Primary Key
            this.HasKey(t => new { t.UserID, t.UserName, t.LocationSort });

            // Properties
            this.Property(t => t.UserID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.UserName)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Name)
                .HasMaxLength(50);

            this.Property(t => t.Pod)
                .HasMaxLength(50);

            this.Property(t => t.Email)
                .HasMaxLength(100);

            this.Property(t => t.Address)
                .HasMaxLength(100);

            this.Property(t => t.City)
                .HasMaxLength(25);

            this.Property(t => t.State)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.Location)
                .HasMaxLength(29);

            this.Property(t => t.LocationSort)
                .IsRequired()
                .HasMaxLength(27);

            this.Property(t => t.StatusText)
                .HasMaxLength(21);

            // Table & Column Mappings
            this.ToTable("vw_FRIENDS");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Pod).HasColumnName("Pod");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.CellPhone).HasColumnName("CellPhone");
            this.Property(t => t.HomePhone).HasColumnName("HomePhone");
            this.Property(t => t.Location).HasColumnName("Location");
            this.Property(t => t.LocationSort).HasColumnName("LocationSort");
            this.Property(t => t.UID).HasColumnName("UID");
            this.Property(t => t.FID).HasColumnName("FID");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.Initiator).HasColumnName("Initiator");
            this.Property(t => t.StatusText).HasColumnName("StatusText");
        }
    }
}
