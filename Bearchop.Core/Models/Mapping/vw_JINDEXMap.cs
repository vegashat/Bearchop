using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class vw_JINDEXMap : EntityTypeConfiguration<vw_JINDEX>
    {
        public vw_JINDEXMap()
        {
            // Primary Key
            this.HasKey(t => new { t.UserID, t.UserName });

            // Properties
            this.Property(t => t.UserID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.UserName)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Name)
                .HasMaxLength(50);

            this.Property(t => t.XFactor)
                .HasMaxLength(31);

            this.Property(t => t.BonusPlace)
                .HasMaxLength(31);

            this.Property(t => t.BonusContest)
                .HasMaxLength(31);

            // Table & Column Mappings
            this.ToTable("vw_JINDEX");
            this.Property(t => t.Rank).HasColumnName("Rank");
            this.Property(t => t.JIndex).HasColumnName("JIndex");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.ContestCount).HasColumnName("ContestCount");
            this.Property(t => t.PlaceAvg).HasColumnName("PlaceAvg");
            this.Property(t => t.FinishAvg).HasColumnName("FinishAvg");
            this.Property(t => t.FinishPoints).HasColumnName("FinishPoints");
            this.Property(t => t.ChampionCount).HasColumnName("ChampionCount");
            this.Property(t => t.MVPCount).HasColumnName("MVPCount");
            this.Property(t => t.AllStarCount).HasColumnName("AllStarCount");
            this.Property(t => t.StarCount).HasColumnName("StarCount");
            this.Property(t => t.XFactor).HasColumnName("XFactor");
            this.Property(t => t.BonusPlace).HasColumnName("BonusPlace");
            this.Property(t => t.BonusContest).HasColumnName("BonusContest");
            this.Property(t => t.BestFinish).HasColumnName("BestFinish");
        }
    }
}
