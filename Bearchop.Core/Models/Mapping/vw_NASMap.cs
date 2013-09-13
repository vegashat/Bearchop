using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class vw_NASMap : EntityTypeConfiguration<vw_NAS>
    {
        public vw_NASMap()
        {
            // Primary Key
            this.HasKey(t => new { t.UserID, t.UserName, t.Year });

            // Properties
            this.Property(t => t.UserID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.UserName)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Name)
                .HasMaxLength(50);

            this.Property(t => t.Year)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(4);

            this.Property(t => t.MLBPTeam)
                .HasMaxLength(20);

            this.Property(t => t.MLBFTeam)
                .HasMaxLength(20);

            this.Property(t => t.MLBRTeam)
                .HasMaxLength(20);

            this.Property(t => t.NFLPTeam)
                .HasMaxLength(20);

            this.Property(t => t.NFLFTeam)
                .HasMaxLength(20);

            this.Property(t => t.NFLRTeam)
                .HasMaxLength(20);

            this.Property(t => t.NCFPTeam)
                .HasMaxLength(20);

            this.Property(t => t.NCFFTeam)
                .HasMaxLength(20);

            this.Property(t => t.NCFRTeam)
                .HasMaxLength(20);

            this.Property(t => t.NCBPTeam)
                .HasMaxLength(20);

            this.Property(t => t.NCBFTeam)
                .HasMaxLength(20);

            this.Property(t => t.NCBRTeam)
                .HasMaxLength(20);

            this.Property(t => t.NBAPTeam)
                .HasMaxLength(20);

            this.Property(t => t.NBAFTeam)
                .HasMaxLength(20);

            this.Property(t => t.NBARTeam)
                .HasMaxLength(20);

            this.Property(t => t.NHLPTeam)
                .HasMaxLength(20);

            this.Property(t => t.NHLFTeam)
                .HasMaxLength(20);

            this.Property(t => t.NHLRTeam)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("vw_NAS");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Year).HasColumnName("Year");
            this.Property(t => t.TotalPoints).HasColumnName("TotalPoints");
            this.Property(t => t.MLBPTeam).HasColumnName("MLBPTeam");
            this.Property(t => t.MLBPPts).HasColumnName("MLBPPts");
            this.Property(t => t.MLBFTeam).HasColumnName("MLBFTeam");
            this.Property(t => t.MLBFPts).HasColumnName("MLBFPts");
            this.Property(t => t.MLBRTeam).HasColumnName("MLBRTeam");
            this.Property(t => t.MLBRPts).HasColumnName("MLBRPts");
            this.Property(t => t.NFLPTeam).HasColumnName("NFLPTeam");
            this.Property(t => t.NFLPPts).HasColumnName("NFLPPts");
            this.Property(t => t.NFLFTeam).HasColumnName("NFLFTeam");
            this.Property(t => t.NFLFPts).HasColumnName("NFLFPts");
            this.Property(t => t.NFLRTeam).HasColumnName("NFLRTeam");
            this.Property(t => t.NFLRPts).HasColumnName("NFLRPts");
            this.Property(t => t.NCFPTeam).HasColumnName("NCFPTeam");
            this.Property(t => t.NCFPPts).HasColumnName("NCFPPts");
            this.Property(t => t.NCFFTeam).HasColumnName("NCFFTeam");
            this.Property(t => t.NCFFPts).HasColumnName("NCFFPts");
            this.Property(t => t.NCFRTeam).HasColumnName("NCFRTeam");
            this.Property(t => t.NCFRPts).HasColumnName("NCFRPts");
            this.Property(t => t.NCBPTeam).HasColumnName("NCBPTeam");
            this.Property(t => t.NCBPPts).HasColumnName("NCBPPts");
            this.Property(t => t.NCBFTeam).HasColumnName("NCBFTeam");
            this.Property(t => t.NCBFPts).HasColumnName("NCBFPts");
            this.Property(t => t.NCBRTeam).HasColumnName("NCBRTeam");
            this.Property(t => t.NCBRPts).HasColumnName("NCBRPts");
            this.Property(t => t.NBAPTeam).HasColumnName("NBAPTeam");
            this.Property(t => t.NBAPPts).HasColumnName("NBAPPts");
            this.Property(t => t.NBAFTeam).HasColumnName("NBAFTeam");
            this.Property(t => t.NBAFPts).HasColumnName("NBAFPts");
            this.Property(t => t.NBARTeam).HasColumnName("NBARTeam");
            this.Property(t => t.NBARPts).HasColumnName("NBARPts");
            this.Property(t => t.NHLPTeam).HasColumnName("NHLPTeam");
            this.Property(t => t.NHLPPts).HasColumnName("NHLPPts");
            this.Property(t => t.NHLFTeam).HasColumnName("NHLFTeam");
            this.Property(t => t.NHLFPts).HasColumnName("NHLFPts");
            this.Property(t => t.NHLRTeam).HasColumnName("NHLRTeam");
            this.Property(t => t.NHLRPts).HasColumnName("NHLRPts");
        }
    }
}
