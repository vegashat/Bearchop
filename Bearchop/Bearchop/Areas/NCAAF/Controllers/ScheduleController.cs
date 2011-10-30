using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contests.NCAAF.Web.jqGrid;
using Contests.NCAAF.Core;
using Bearchop.ActionFilter;
using Bearchop.Session;

namespace Contests.NCAAF.Web.Controllers
{
    [ValidateUser]
    public class ScheduleController : Controller
    {
        //
        // GET: /Schedule/

        internal class Schedule
        {
            public int UserId { get; set; }
            public int TeamId { get; set; }
            public string Name { get; set; }
            public int PickWeek { get; set; }
            public WeekOptions Week1_Opponent { get; set; }
            public WeekOptions Week2_Opponent { get; set; }
            public WeekOptions Week3_Opponent { get; set; }
            public WeekOptions Week4_Opponent { get; set; }
            public WeekOptions Week5_Opponent { get; set; }
            public WeekOptions Week6_Opponent { get; set; }
            public WeekOptions Week7_Opponent { get; set; }
            public WeekOptions Week8_Opponent { get; set; }
            public WeekOptions Week9_Opponent { get; set; }
            public WeekOptions Week10_Opponent { get; set; }
            public WeekOptions Week11_Opponent { get; set; }
            public WeekOptions Week12_Opponent { get; set; }
            public WeekOptions Week13_Opponent { get; set; }
            public WeekOptions Week14_Opponent { get; set; }
            public WeekOptions Week15_Opponent { get; set; }
        }

        internal class WeekOptions
        {
            public string Name { get; set; }
            public bool IsAway { get; set; }
            public bool IsByeWeek 
            { 
                get 
                { 
                    return string.IsNullOrEmpty(Name.Trim()); 
                } 
            }
            public bool SharesByeWeek { get; set; }
            public bool PlaysAgainstOwnedTeam { get; set; }

            string _class;
            public string Class
            {
                get
                {
                    _class = string.Empty;
                    _class += IsAway ? " away" : string.Empty;
                    _class += IsByeWeek ? " bye" : string.Empty;
                    _class += SharesByeWeek ? " share" : string.Empty;
                    _class += PlaysAgainstOwnedTeam ? " own" : string.Empty;

                    return _class;
                }
                set
                {
                    _class = value;
                }
            }

            public override string  ToString()
            { 	                
                return Name;
            }
        }

        internal class TeamInfo
        {
            
            public int TeamID { get; set; }
            public string Name { get; set; }
            public string Conference { get; set; }
            public decimal OPrice { get; set; }
            public decimal Price { get; set; }
            public int Wins { get; set; }
            public int Losses { get; set; }
            public int Points { get; set; }
            public int OwnedBy { get; set; }
            public decimal RealValue { get; set; }
            public bool IsSelected { get; set; }
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult UserSchedule(string search, string sidx, string sord, string filters, int? page = 1, int? rows = 1, string otherTeams = "")
        {
            using (var context = NCAAFContext.GetNcaaEntities())
            {
                List<int> otherTeamIds = new List<int>();

                foreach (var id in otherTeams.Split(','))
                {
                    if (!string.IsNullOrEmpty(id))
                    {
                        otherTeamIds.Add(Int32.Parse(id));
                    }
                }

                var userTeams = from t in context.USER_WEEKLY_SCHEDULE
                                where t.userid == BearchopSession.Current.CurrentUser.UserID
                                select new Schedule()
                                {
                                    UserId = t.userid,
                                    TeamId = t.teamid,
                                    Name = t.name,
                                    PickWeek = t.pick_week,
                                    Week1_Opponent = new WeekOptions() { Name = t.week1_opponent },
                                    Week2_Opponent = new WeekOptions() { Name = t.week2_opponent },
                                    Week3_Opponent = new WeekOptions() { Name = t.week3_opponent },
                                    Week4_Opponent = new WeekOptions() { Name = t.week4_opponent },
                                    Week5_Opponent = new WeekOptions() { Name = t.week5_opponent },
                                    Week6_Opponent = new WeekOptions() { Name = t.week6_opponent },
                                    Week7_Opponent = new WeekOptions() { Name = t.week7_opponent },
                                    Week8_Opponent = new WeekOptions() { Name = t.week8_opponent },
                                    Week9_Opponent = new WeekOptions() { Name = t.week9_opponent },
                                    Week10_Opponent = new WeekOptions() { Name = t.week10_opponent },
                                    Week11_Opponent = new WeekOptions() { Name = t.week11_opponent },
                                    Week12_Opponent = new WeekOptions() { Name = t.week12_opponent },
                                    Week13_Opponent = new WeekOptions() { Name = t.week13_opponent },
                                    Week14_Opponent = new WeekOptions() { Name = t.week14_opponent },
                                    Week15_Opponent = new WeekOptions() { Name = t.week15_opponent }
                                };


                var teams = from t in context.TEAM_SCHEDULE
                            where otherTeamIds.Contains(t.TeamID)
                            select new Schedule()
                            {
                                UserId = BearchopSession.Current.CurrentUser.UserID,
                                TeamId = t.TeamID,
                                Name = t.name,
                                PickWeek = 0,
                                Week1_Opponent = new WeekOptions() { Name = t.week1_opponent },
                                Week2_Opponent = new WeekOptions() { Name = t.week2_opponent },
                                Week3_Opponent = new WeekOptions() { Name = t.week3_opponent },
                                Week4_Opponent = new WeekOptions() { Name = t.week4_opponent },
                                Week5_Opponent = new WeekOptions() { Name = t.week5_opponent },
                                Week6_Opponent = new WeekOptions() { Name = t.week6_opponent },
                                Week7_Opponent = new WeekOptions() { Name = t.week7_opponent },
                                Week8_Opponent = new WeekOptions() { Name = t.week8_opponent },
                                Week9_Opponent = new WeekOptions() { Name = t.week9_opponent },
                                Week10_Opponent = new WeekOptions() { Name = t.week10_opponent },
                                Week11_Opponent = new WeekOptions() { Name = t.week11_opponent },
                                Week12_Opponent = new WeekOptions() { Name = t.week12_opponent },
                                Week13_Opponent = new WeekOptions() { Name = t.week13_opponent },
                                Week14_Opponent = new WeekOptions() { Name = t.week14_opponent },
                                Week15_Opponent = new WeekOptions() { Name = t.week15_opponent }
                            };

                var combined = userTeams.ToList();

                foreach (var team in teams)
                {
                    combined.Add(team);
                }

                if (!string.IsNullOrEmpty(filters))
                {
                    combined = combined.ApplyFilter<Schedule>(filters).AsQueryable().ToList();
                }
                                
                var jqGridData = combined.AsQueryable().ToJqGridData(page.Value, rows.Value, sidx,
                        sord == "desc", search, new[] 
                        { 
                            "userid", "teamid","name","pick_week"
                            ,"week1_opponent"
                            ,"week2_opponent"
                            ,"week3_opponent"
                            ,"week4_opponent"
                            ,"week5_opponent"
                            ,"week6_opponent"
                            ,"week7_opponent"
                            ,"week8_opponent"
                            ,"week9_opponent"
                            ,"week10_opponent"
                            ,"week11_opponent"
                            ,"week12_opponent"
                            ,"week13_opponent"
                            ,"week14_opponent"
                            ,"week15_opponent"
                        });

                return Json(jqGridData, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Teams(string search, string sidx, string sord, string filters, int? page = 1, int? rows = 1)
        {
            //Not sure how it disposes though
            using (var context = NCAAFContext.GetJeauxDBEntities())
            {

                //Only get this weeks selections
                var currentSelection = from c in context.COLFOOT.Where(c => c.UserID == BearchopSession.Current.CurrentUser.UserID)
                                       join w in context.COLFOOT_WEEK on c.Week equals w.CurrentWeek into cwJoin
                                       from i in cwJoin
                                       select c;

                //Now get all the teams that are selectable
                var teams = context.COLFOOT_TEAM;

                //Try to help with the serializing.
                var result = from t in teams
                             select new TeamInfo()
                             {
                                 TeamID = t.TeamID
                                ,
                                 Name = t.Name
                                ,
                                 Conference = t.Conference
                                ,
                                 OPrice = t.OPrice.HasValue ? t.OPrice.Value : 0
                                ,
                                 Price = t.Price.HasValue ? t.Price.Value : 0,
                                 Wins = t.Wins.HasValue ? t.Wins.Value : 0,
                                 Losses = t.Losses.HasValue ? t.Losses.Value : 0
                                ,
                                 Points = t.Points.HasValue ? t.Points.Value : 0
                                ,
                                 OwnedBy = t.OwnedBy.HasValue ? t.OwnedBy.Value : 0
                                ,
                                 RealValue = t.RealValue.HasValue ? t.RealValue.Value : 0
                                ,
                                 IsSelected = currentSelection.Count(c => c.TeamID == t.TeamID) > 0
                             };

                if (!string.IsNullOrEmpty(filters))
                {
                    result = result.ApplyFilter<TeamInfo>(filters).AsQueryable();
                }

                List<TeamInfo> sortableData = result.ToList();

                var jqGridData = sortableData.AsQueryable().ToJqGridData(page.Value, rows.Value, sidx,
                        sord == "desc", search, new[] 
                        { 
                            "TeamdID"
                            ,"Name"
                            ,"Conference"
                            ,"OPrice"
                            ,"Price"
                            ,"Wins"
                            ,"Losses"
                            ,"Points"
                            ,"OwnedBy"
                            ,"RealValue"
                            ,"IsSelected"
                        });

                return Json(jqGridData, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Conferences()
        {
            using (var context = NCAAFContext.GetJeauxDBEntities())
            {
                var conferences = (from t in context.COLFOOT_TEAM
                                   select t.Conference).Distinct();
                
                Dictionary<string, string> values = new Dictionary<string, string>();

                values.Add("All", "All");
                conferences.Where(d => d != null).ToList().ForEach(d => values.Add(d.ToString(), d.ToString()));

                return Json(values, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
