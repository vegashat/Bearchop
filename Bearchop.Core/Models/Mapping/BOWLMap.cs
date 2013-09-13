using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class BOWLMap : EntityTypeConfiguration<BOWL>
    {
        public BOWLMap()
        {
            // Primary Key
            this.HasKey(t => t.BowlID);

            // Properties
            this.Property(t => t.BowlName)
                .HasMaxLength(20);

            this.Property(t => t.Location)
                .HasMaxLength(20);

            this.Property(t => t.Team1)
                .HasMaxLength(15);

            this.Property(t => t.Team2)
                .HasMaxLength(15);

            this.Property(t => t.Winner)
                .HasMaxLength(15);

            this.Property(t => t.Pick)
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("BOWL");
            this.Property(t => t.BowlID).HasColumnName("BowlID");
            this.Property(t => t.BowlDate).HasColumnName("BowlDate");
            this.Property(t => t.BowlName).HasColumnName("BowlName");
            this.Property(t => t.Location).HasColumnName("Location");
            this.Property(t => t.Team1).HasColumnName("Team1");
            this.Property(t => t.Team2).HasColumnName("Team2");
            this.Property(t => t.Winner).HasColumnName("Winner");
            this.Property(t => t.Pick).HasColumnName("Pick");
            this.Property(t => t.Rank).HasColumnName("Rank");
        }
    }
}
