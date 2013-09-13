using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Bearchop.Core.Models.Mapping;

namespace Bearchop.Core.Models
{
    public class JeauxDBContext : DbContext
    {
        static JeauxDBContext()
        {
            Database.SetInitializer<JeauxDBContext>(null);
        }

		public JeauxDBContext()
			: base("Name=JeauxDBContext")
		{
            this.Configuration.LazyLoadingEnabled = true;
		}

        public DbSet<AUDIT_LOG> AUDIT_LOG { get; set; }
        public DbSet<BASEBALL> BASEBALLs { get; set; }
        public DbSet<BIG12> BIG12 { get; set; }
        public DbSet<BIG12_PICKS> BIG12_PICKS { get; set; }
        public DbSet<BIG12_SCHEDULE> BIG12_SCHEDULE { get; set; }
        public DbSet<BOWL> BOWLs { get; set; }
        public DbSet<BOWL_PICKS> BOWL_PICKS { get; set; }
        public DbSet<COLFOOT> COLFOOT_USERS { get; set; }
        public DbSet<COLFOOT_RESULTS> COLFOOT_RESULTS { get; set; }
        public DbSet<COLFOOT_TEAM> COLFOOT_TEAM { get; set; }
        public DbSet<COLFOOT_TRADE> COLFOOT_TRADE { get; set; }
        public DbSet<COLFOOT_WEEK> COLFOOT_WEEK { get; set; }
        public DbSet<CONTEST> CONTESTs { get; set; }
        public DbSet<EMAIL> EMAILs { get; set; }
        public DbSet<ERRORLOG> ERRORLOGs { get; set; }
        public DbSet<GALLERY> GALLERies { get; set; }
        public DbSet<GOLF_LINEUP> GOLF_LINEUP { get; set; }
        public DbSet<GOLF_MAJOR> GOLF_MAJOR { get; set; }
        public DbSet<GOLF_SCORE> GOLF_SCORE { get; set; }
        public DbSet<GOLFER> GOLFERs { get; set; }
        public DbSet<HIT> HITS { get; set; }
        public DbSet<JEVENT> JEVENTs { get; set; }
        public DbSet<JFRIEND> JFRIENDs { get; set; }
        public DbSet<JISSUE> JISSUEs { get; set; }
        public DbSet<JTAG> JTAGs { get; set; }
        public DbSet<JUSER> JUSERs { get; set; }
        public DbSet<LOYALTY> LOYALTies { get; set; }
        public DbSet<NA> NAS { get; set; }
        public DbSet<NAS_TEAM> NAS_TEAM { get; set; }
        public DbSet<NB12_PICK> NB12_PICK { get; set; }
        public DbSet<NB12_PLAYER> NB12_PLAYER { get; set; }
        public DbSet<NB12_SCHEDULE> NB12_SCHEDULE { get; set; }
        public DbSet<NB12_SCORES> NB12_SCORES { get; set; }
        public DbSet<NB12_TRADE> NB12_TRADE { get; set; }
        public DbSet<NBA_GAME> NBA_GAME { get; set; }
        public DbSet<NBA_PICK> NBA_PICK { get; set; }
        public DbSet<NCAA_GAME> NCAA_GAME { get; set; }
        public DbSet<NCAA_PICK> NCAA_PICK { get; set; }
        public DbSet<NCAA_PLAYER> NCAA_PLAYER { get; set; }
        public DbSet<NCAA_POD> NCAA_POD { get; set; }
        public DbSet<NCAA_TEAM> NCAA_TEAM { get; set; }
        public DbSet<NCAAFootballSchedule> NCAAFootballSchedules { get; set; }
        public DbSet<NCAAFootballTeam> NCAAFootballTeams { get; set; }
        public DbSet<NCAAFootballWeek> NCAAFootballWeeks { get; set; }
        public DbSet<NPGAME> NPGAMEs { get; set; }
        public DbSet<NPPICK> NPPICKs { get; set; }
        public DbSet<NPROUND> NPROUNDs { get; set; }
        public DbSet<NPSERy> NPSERIES { get; set; }
        public DbSet<NPTEAM> NPTEAMs { get; set; }
        public DbSet<REF_CONTEST> REF_CONTEST { get; set; }
        public DbSet<RESUME> RESUMEs { get; set; }
        public DbSet<REVIEW> REVIEWS { get; set; }
        public DbSet<TWOTK> TWOTKs { get; set; }
        public DbSet<TWOTK_USERS> TWOTK_USERS { get; set; }
        public DbSet<NPStanding> NPStandings { get; set; }
        public DbSet<vw_COLFOOT_STANDINGS> vw_COLFOOT_STANDINGS { get; set; }
        public DbSet<vw_FRIENDS> vw_FRIENDS { get; set; }
        public DbSet<vw_GOLF_LEADERBOARD> vw_GOLF_LEADERBOARD { get; set; }
        public DbSet<vw_GOLF_LINEUP> vw_GOLF_LINEUP { get; set; }
        public DbSet<vw_GOLF_MAJOR> vw_GOLF_MAJOR { get; set; }
        public DbSet<vw_GOLF_STANDINGS> vw_GOLF_STANDINGS { get; set; }
        public DbSet<vw_GOLFER> vw_GOLFER { get; set; }
        public DbSet<vw_JINDEX> vw_JINDEX { get; set; }
        public DbSet<vw_JINDEX2> vw_JINDEX2 { get; set; }
        public DbSet<vw_JPOINTS> vw_JPOINTS { get; set; }
        public DbSet<vw_NAS> vw_NAS { get; set; }
        public DbSet<vw_NBA_CALENDAR> vw_NBA_CALENDAR { get; set; }
        public DbSet<vw_NBA_HOPPER> vw_NBA_HOPPER { get; set; }
        public DbSet<vw_schedule> TeamSchedule { get; set; }
        public DbSet<vw_team_away_weekly_schedule> AwayTeamSchedule { get; set; }
        public DbSet<vw_team_home_weekly_schedule> HomeTeamSchedule { get; set; }
        public DbSet<TeamWeeklySchedule> TeamWeeklySchedule { get; set; }
        public DbSet<UserSchedule> UserSchedule { get; set; }
        public DbSet<UserWeeklySchedule> UserWeeklySchedule { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AUDIT_LOGMap());
            modelBuilder.Configurations.Add(new BASEBALLMap());
            modelBuilder.Configurations.Add(new BIG12Map());
            modelBuilder.Configurations.Add(new BIG12_PICKSMap());
            modelBuilder.Configurations.Add(new BIG12_SCHEDULEMap());
            modelBuilder.Configurations.Add(new BOWLMap());
            modelBuilder.Configurations.Add(new BOWL_PICKSMap());
            modelBuilder.Configurations.Add(new COLFOOTMap());
            modelBuilder.Configurations.Add(new COLFOOT_RESULTSMap());
            modelBuilder.Configurations.Add(new COLFOOT_TEAMMap());
            modelBuilder.Configurations.Add(new COLFOOT_TRADEMap());
            modelBuilder.Configurations.Add(new COLFOOT_WEEKMap());
            modelBuilder.Configurations.Add(new CONTESTMap());
            modelBuilder.Configurations.Add(new EMAILMap());
            modelBuilder.Configurations.Add(new ERRORLOGMap());
            modelBuilder.Configurations.Add(new GALLERYMap());
            modelBuilder.Configurations.Add(new GOLF_LINEUPMap());
            modelBuilder.Configurations.Add(new GOLF_MAJORMap());
            modelBuilder.Configurations.Add(new GOLF_SCOREMap());
            modelBuilder.Configurations.Add(new GOLFERMap());
            modelBuilder.Configurations.Add(new HITMap());
            modelBuilder.Configurations.Add(new JEVENTMap());
            modelBuilder.Configurations.Add(new JFRIENDMap());
            modelBuilder.Configurations.Add(new JISSUEMap());
            modelBuilder.Configurations.Add(new JTAGMap());
            modelBuilder.Configurations.Add(new JUSERMap());
            modelBuilder.Configurations.Add(new LOYALTYMap());
            modelBuilder.Configurations.Add(new NAMap());
            modelBuilder.Configurations.Add(new NAS_TEAMMap());
            modelBuilder.Configurations.Add(new NB12_PICKMap());
            modelBuilder.Configurations.Add(new NB12_PLAYERMap());
            modelBuilder.Configurations.Add(new NB12_SCHEDULEMap());
            modelBuilder.Configurations.Add(new NB12_SCORESMap());
            modelBuilder.Configurations.Add(new NB12_TRADEMap());
            modelBuilder.Configurations.Add(new NBA_GAMEMap());
            modelBuilder.Configurations.Add(new NBA_PICKMap());
            modelBuilder.Configurations.Add(new NCAA_GAMEMap());
            modelBuilder.Configurations.Add(new NCAA_PICKMap());
            modelBuilder.Configurations.Add(new NCAA_PLAYERMap());
            modelBuilder.Configurations.Add(new NCAA_PODMap());
            modelBuilder.Configurations.Add(new NCAA_TEAMMap());
            modelBuilder.Configurations.Add(new NCAAFootballScheduleMap());
            modelBuilder.Configurations.Add(new NCAAFootballTeamMap());
            modelBuilder.Configurations.Add(new NCAAFootballWeekMap());
            modelBuilder.Configurations.Add(new NPGAMEMap());
            modelBuilder.Configurations.Add(new NPPICKMap());
            modelBuilder.Configurations.Add(new NPROUNDMap());
            modelBuilder.Configurations.Add(new NPSERyMap());
            modelBuilder.Configurations.Add(new NPTEAMMap());
            modelBuilder.Configurations.Add(new REF_CONTESTMap());
            modelBuilder.Configurations.Add(new RESUMEMap());
            modelBuilder.Configurations.Add(new REVIEWMap());
            modelBuilder.Configurations.Add(new TWOTKMap());
            modelBuilder.Configurations.Add(new TWOTK_USERSMap());
            modelBuilder.Configurations.Add(new NPStandingMap());
            modelBuilder.Configurations.Add(new vw_COLFOOT_STANDINGSMap());
            modelBuilder.Configurations.Add(new vw_FRIENDSMap());
            modelBuilder.Configurations.Add(new vw_GOLF_LEADERBOARDMap());
            modelBuilder.Configurations.Add(new vw_GOLF_LINEUPMap());
            modelBuilder.Configurations.Add(new vw_GOLF_MAJORMap());
            modelBuilder.Configurations.Add(new vw_GOLF_STANDINGSMap());
            modelBuilder.Configurations.Add(new vw_GOLFERMap());
            modelBuilder.Configurations.Add(new vw_JINDEXMap());
            modelBuilder.Configurations.Add(new vw_JINDEX2Map());
            modelBuilder.Configurations.Add(new vw_JPOINTSMap());
            modelBuilder.Configurations.Add(new vw_NASMap());
            modelBuilder.Configurations.Add(new vw_NBA_CALENDARMap());
            modelBuilder.Configurations.Add(new vw_NBA_HOPPERMap());
            modelBuilder.Configurations.Add(new vw_scheduleMap());
            modelBuilder.Configurations.Add(new vw_team_away_weekly_scheduleMap());
            modelBuilder.Configurations.Add(new vw_team_home_weekly_scheduleMap());
            modelBuilder.Configurations.Add(new TeamWeeklyScheduleMap());
            modelBuilder.Configurations.Add(new vw_user_scheduleMap());
            modelBuilder.Configurations.Add(new vw_user_weekly_scheduleMap());
        }
    }
}
