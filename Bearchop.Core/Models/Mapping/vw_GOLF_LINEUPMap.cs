using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class vw_GOLF_LINEUPMap : EntityTypeConfiguration<vw_GOLF_LINEUP>
    {
        public vw_GOLF_LINEUPMap()
        {
            // Primary Key
            this.HasKey(t => new { t.UserName, t.GolferID, t.Golfer, t.Country, t.Rank, t.Value_Differs, t.Renegotiate_Flag, t.Selected_Golfer, t.UserID, t.Current_Flag, t.TotalPts });

            // Properties
            this.Property(t => t.UserName)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.GolferID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Golfer)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Country)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.Value_Differs)
                .IsRequired()
                .HasMaxLength(1);

            this.Property(t => t.Renegotiate_Flag)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Selected_Golfer)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.UserID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Current_Flag)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("vw_GOLF_LINEUP");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.GolferID).HasColumnName("GolferID");
            this.Property(t => t.Golfer).HasColumnName("Golfer");
            this.Property(t => t.Country).HasColumnName("Country");
            this.Property(t => t.Rank).HasColumnName("Rank");
            this.Property(t => t.Lineup_Value).HasColumnName("Lineup_Value");
            this.Property(t => t.Golfer_Value).HasColumnName("Golfer_Value");
            this.Property(t => t.Value_Differs).HasColumnName("Value_Differs");
            this.Property(t => t.Renegotiate_Flag).HasColumnName("Renegotiate_Flag");
            this.Property(t => t.Golfer_Points).HasColumnName("Golfer_Points");
            this.Property(t => t.Selected_Golfer).HasColumnName("Selected_Golfer");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.Current_Flag).HasColumnName("Current_Flag");
            this.Property(t => t.TotalPts).HasColumnName("TotalPts");
        }
    }
}
