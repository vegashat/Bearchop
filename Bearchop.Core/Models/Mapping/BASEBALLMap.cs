using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class BASEBALLMap : EntityTypeConfiguration<BASEBALL>
    {
        public BASEBALLMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Year, t.UserID });

            // Properties
            this.Property(t => t.Year)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.UserID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.UserName)
                .HasMaxLength(20);

            this.Property(t => t.ALEast)
                .HasMaxLength(20);

            this.Property(t => t.ALCent)
                .HasMaxLength(20);

            this.Property(t => t.ALWest)
                .HasMaxLength(20);

            this.Property(t => t.ALWild)
                .HasMaxLength(20);

            this.Property(t => t.ALWild2)
                .HasMaxLength(20);

            this.Property(t => t.NLEast)
                .HasMaxLength(20);

            this.Property(t => t.NLCent)
                .HasMaxLength(20);

            this.Property(t => t.NLWest)
                .HasMaxLength(20);

            this.Property(t => t.NLWild)
                .HasMaxLength(20);

            this.Property(t => t.NLWild2)
                .HasMaxLength(20);

            this.Property(t => t.Champion)
                .HasMaxLength(20);

            this.Property(t => t.ALMVP)
                .HasMaxLength(50);

            this.Property(t => t.NLMVP)
                .HasMaxLength(50);

            this.Property(t => t.ALCY)
                .HasMaxLength(50);

            this.Property(t => t.NLCY)
                .HasMaxLength(50);

            this.Property(t => t.ALRookie)
                .HasMaxLength(50);

            this.Property(t => t.NLRookie)
                .HasMaxLength(50);

            this.Property(t => t.ALManager)
                .HasMaxLength(50);

            this.Property(t => t.NLManager)
                .HasMaxLength(50);

            this.Property(t => t.HRLeader)
                .HasMaxLength(50);

            this.Property(t => t.HRCount)
                .HasMaxLength(20);

            this.Property(t => t.RBILeader)
                .HasMaxLength(50);

            this.Property(t => t.RBICount)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("BASEBALL");
            this.Property(t => t.Year).HasColumnName("Year");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.ALEast).HasColumnName("ALEast");
            this.Property(t => t.ALCent).HasColumnName("ALCent");
            this.Property(t => t.ALWest).HasColumnName("ALWest");
            this.Property(t => t.ALWild).HasColumnName("ALWild");
            this.Property(t => t.ALWild2).HasColumnName("ALWild2");
            this.Property(t => t.NLEast).HasColumnName("NLEast");
            this.Property(t => t.NLCent).HasColumnName("NLCent");
            this.Property(t => t.NLWest).HasColumnName("NLWest");
            this.Property(t => t.NLWild).HasColumnName("NLWild");
            this.Property(t => t.NLWild2).HasColumnName("NLWild2");
            this.Property(t => t.Champion).HasColumnName("Champion");
            this.Property(t => t.ALMVP).HasColumnName("ALMVP");
            this.Property(t => t.NLMVP).HasColumnName("NLMVP");
            this.Property(t => t.ALCY).HasColumnName("ALCY");
            this.Property(t => t.NLCY).HasColumnName("NLCY");
            this.Property(t => t.ALRookie).HasColumnName("ALRookie");
            this.Property(t => t.NLRookie).HasColumnName("NLRookie");
            this.Property(t => t.ALManager).HasColumnName("ALManager");
            this.Property(t => t.NLManager).HasColumnName("NLManager");
            this.Property(t => t.HRLeader).HasColumnName("HRLeader");
            this.Property(t => t.HRCount).HasColumnName("HRCount");
            this.Property(t => t.HRPoints).HasColumnName("HRPoints");
            this.Property(t => t.RBILeader).HasColumnName("RBILeader");
            this.Property(t => t.RBICount).HasColumnName("RBICount");
            this.Property(t => t.RBIPoints).HasColumnName("RBIPoints");
            this.Property(t => t.Points).HasColumnName("Points");
        }
    }
}
