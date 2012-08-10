using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using NCAAF.Model.Models.Mapping;

namespace NCAAF.Model.Models
{
    public class NCAAFContext : DbContext
    {
        static NCAAFContext()
        {
            Database.SetInitializer<NCAAFContext>(null);
        }

		public NCAAFContext()
			: base("Name=NCAAFContext")
		{
		}

        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Week> Weeks { get; set; }
        public DbSet<vw_schedule> vw_schedule { get; set; }
        public DbSet<vw_team_away_weekly_schedule> vw_team_away_weekly_schedule { get; set; }
        public DbSet<vw_team_home_weekly_schedule> vw_team_home_weekly_schedule { get; set; }
        public DbSet<vw_team_weekly_schedule> vw_team_weekly_schedule { get; set; }
        public DbSet<vw_user_schedule> vw_user_schedule { get; set; }
        public DbSet<vw_user_weekly_schedule> vw_user_weekly_schedule { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ScheduleMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new TeamMap());
            modelBuilder.Configurations.Add(new WeekMap());
            modelBuilder.Configurations.Add(new vw_scheduleMap());
            modelBuilder.Configurations.Add(new vw_team_away_weekly_scheduleMap());
            modelBuilder.Configurations.Add(new vw_team_home_weekly_scheduleMap());
            modelBuilder.Configurations.Add(new vw_team_weekly_scheduleMap());
            modelBuilder.Configurations.Add(new vw_user_scheduleMap());
            modelBuilder.Configurations.Add(new vw_user_weekly_scheduleMap());
        }
    }
}
