using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class JUSERMap : EntityTypeConfiguration<JUSER>
    {
        public JUSERMap()
        {
            // Primary Key
            this.HasKey(t => t.UserID);

            // Properties
            this.Property(t => t.UserName)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Password)
                .HasMaxLength(50);

            this.Property(t => t.Name)
                .HasMaxLength(50);

            this.Property(t => t.Email)
                .HasMaxLength(100);

            this.Property(t => t.Pod)
                .HasMaxLength(50);

            this.Property(t => t.Address)
                .HasMaxLength(100);

            this.Property(t => t.City)
                .HasMaxLength(25);

            this.Property(t => t.State)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.Spouse)
                .HasMaxLength(20);

            this.Property(t => t.MLB)
                .HasMaxLength(16);

            this.Property(t => t.NFL)
                .HasMaxLength(16);

            this.Property(t => t.NCF)
                .HasMaxLength(16);

            this.Property(t => t.NCB)
                .HasMaxLength(16);

            this.Property(t => t.NBA)
                .HasMaxLength(16);

            this.Property(t => t.NHL)
                .HasMaxLength(16);

            this.Property(t => t.Website)
                .HasMaxLength(100);

            this.Property(t => t.Location)
                .HasMaxLength(29);

            this.Property(t => t.LocationSort)
                .IsRequired()
                .HasMaxLength(27);

            this.Property(t => t.Comments)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("JUSER");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.ActiveFlag).HasColumnName("ActiveFlag");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Pod).HasColumnName("Pod");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.CellPhone).HasColumnName("CellPhone");
            this.Property(t => t.HomePhone).HasColumnName("HomePhone");
            this.Property(t => t.BBSBanFlag).HasColumnName("BBSBanFlag");
            this.Property(t => t.BdayMonth).HasColumnName("BdayMonth");
            this.Property(t => t.BdayDay).HasColumnName("BdayDay");
            this.Property(t => t.AnnvMonth).HasColumnName("AnnvMonth");
            this.Property(t => t.AnnvDay).HasColumnName("AnnvDay");
            this.Property(t => t.Spouse).HasColumnName("Spouse");
            this.Property(t => t.LoyaltyUpdated).HasColumnName("LoyaltyUpdated");
            this.Property(t => t.MLB).HasColumnName("MLB");
            this.Property(t => t.NFL).HasColumnName("NFL");
            this.Property(t => t.NCF).HasColumnName("NCF");
            this.Property(t => t.NCB).HasColumnName("NCB");
            this.Property(t => t.NBA).HasColumnName("NBA");
            this.Property(t => t.NHL).HasColumnName("NHL");
            this.Property(t => t.Website).HasColumnName("Website");
            this.Property(t => t.Location).HasColumnName("Location");
            this.Property(t => t.LocationSort).HasColumnName("LocationSort");
            this.Property(t => t.Reminder).HasColumnName("Reminder");
            this.Property(t => t.Comments).HasColumnName("Comments");
            this.Property(t => t.Created).HasColumnName("Created");
            this.Property(t => t.LastUpdated).HasColumnName("LastUpdated");
            this.Property(t => t.FamilyID).HasColumnName("FamilyID");
            
        }
    }
}
