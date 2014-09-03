using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Bearchop.LOTW.Core.Models.Mapping;

namespace Bearchop.LOTW.Core.Models
{
    public partial class LOTWContext : DbContext
    {
        static LOTWContext()
        {
            Database.SetInitializer<LOTWContext>(null);
        }

        public LOTWContext()
            : base("Name=LOTWContext")
        {
        }

        public DbSet<Conference> Conferences { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<LOTWUser> Users { get; set; }
        public DbSet<Pick> Picks { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Week> Weeks { get; set; }
        public DbSet<vw_team_schedule> vw_team_schedule { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ConferenceMap());
            modelBuilder.Configurations.Add(new DivisionMap());
            modelBuilder.Configurations.Add(new GameMap());
            modelBuilder.Configurations.Add(new LOTWUserMap());
            modelBuilder.Configurations.Add(new PickMap());
            modelBuilder.Configurations.Add(new ScheduleMap());
            modelBuilder.Configurations.Add(new TeamMap());
            modelBuilder.Configurations.Add(new WeekMap());
            modelBuilder.Configurations.Add(new vw_team_scheduleMap());
        }
    }
}
