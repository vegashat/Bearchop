using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Contests.LOTW.Core.Model;
using System.ComponentModel.DataAnnotations;

namespace Contests.LOTW.Core.Repository
{
    public class LOTWContext : DbContext
    {
        public DbSet<LOTWUser> Users { get; set; }
        public DbSet<Week> Weeks { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Pick> Picks { get; set; }
        public DbSet<Conference> Leagues { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LOTWUser>()
                .Property(u => u.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder.Entity<Schedule>()
                .HasRequired<Team>(p => p.HomeTeam)
                .WithMany()
                .HasForeignKey(p => p.HomeId)
                .WillCascadeOnDelete(false);
            
            modelBuilder.Entity<Schedule>()
                .HasRequired<Team>(p => p.AwayTeam)
                .WithMany()
                .HasForeignKey(p => p.AwayId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LOTWUser>()
                .HasMany<Pick>(u => u.Picks)
                .WithRequired()
                .HasForeignKey(u => u.UserId);
                            
            base.OnModelCreating(modelBuilder);
        }
    }
}
