using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Bearchop.ActionFilter;
using Bearchop.Areas.LOTW.Web.ViewModels;
using Bearchop.Session;
using Contests.LOTW.Core.Model;
using Contests.LOTW.Core.Service;
using Contests.NCAAF.Core;


namespace Bearchop.Areas.LOTW.Web.Controllers
{
    [ValidateUser]
    public class PickController : Controller
    {
        GameService _gameService = new GameService();
        PickService _pickService = new PickService();
        WeekService _weekService = new WeekService();

        public ActionResult List(int? week = null, int? userId = null)
        {
            var model = GetPickViewModel(week, userId);

            return View(model);
        }

        public PartialViewResult History(int userId)
        {
            var weeks       = _weekService.GetWeeks();
            var currentWeek = _weekService.GetWeek();

            var model = new PickHistoryViewModel(userId, weeks, currentWeek);

            return PartialView("_PickHistory", model);
        }
        
        public PartialViewResult UserPicks(int week, int userId)
        {
            return PartialView("_UserPicks", GetPickViewModel(week, userId));
        }
        
        private PicksViewModel GetPickViewModel(int? week, int? userId)
        {
            Contests.LOTW.Core.Model.Week currentWeek = null;
            int currentUserId = 0;

            currentWeek = _weekService.GetWeek(week);

            if (userId.HasValue)
            {
                currentUserId = userId.Value;
            }
            else
            {
                currentUserId = BearchopSession.Current.CurrentUser.UserID;
            }

            var games = _gameService.GetGames(currentWeek.Number);                        
            var picks = _pickService.GetUserPicksForWeek(currentUserId, currentWeek.Number);
            
            if (currentUserId != BearchopSession.Current.CurrentUser.UserID)
            {
                if(games.Count(game => game.Date <= DateTime.Now) == 0)
                {
                    //No viewable (or hackable from Bradley) picks for users until the game starts
                    picks = new List<Pick>().AsQueryable();
                }
            }

            var model = new PicksViewModel(currentWeek, games.ToList(), picks.ToList(), new LOTWUser() { Id = currentUserId });
            return model;
        }

        [HttpPost]
        public JsonResult Save(int week, [Bind(Prefix="")] IList<Pick> picks)
        {
            try
            {
                int userId = BearchopSession.Current.CurrentUser.UserID;

                if (week == _weekService.GetWeek().Number)
                {
                    List<Pick> selectedPicks = new List<Pick>();

                    //First remove current picks for the week and save the new ones
                    _pickService.RemovePicks(userId, week);

                    //Should get all picks submitted, only save those with 
                    for (int i = 0; i < picks.Count(); i++)
                    {
                        var pick = picks.ElementAt(i);

                        bool isChecked = false;
                        Boolean.TryParse(Request.Form.GetValues("gameSelected" + pick.GameId)[0], out isChecked);

                        if (isChecked)
                        {
                            _pickService.SavePick(pick);
                            selectedPicks.Add(pick);
                        }
                    }

                    //Email(selectedPicks);
                }

                var result = new { Success = true };

                return Json(result);   
            }
            catch (Exception ex)
            {
                var result = new { Success = false, Error = ex.ToString() };
                Email(ex);
                return Json(result);
            }     
        }


        const string PICK_FORMAT = "<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td></tr>";
       
        private void Email(IEnumerable<Pick> picks)
        {
            var message = new MailMessage("vegashat@willnette", BearchopSession.Current.CurrentUser.Email);
            message.CC.Add("vegashat@willnette.com");

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<table><tr><th>Pick</th><Against<th><th>Favorite</th><th>Spread</th><th>Picked Over/Under</th><th>Over/Under Pick</th></tr>");

            sb.AppendLine(string.Format("<p>Below are your current picks for week {0}</p>", picks.FirstOrDefault().WeekId));

            foreach (var pick in picks)
            {
                var game = _gameService.GetGame(pick.GameId);
                string pickName = pick.Team;
                string againstName = (pick.Team == game.HomeTeam ? game.AwayTeam : game.HomeTeam);
                string ouDesc = string.Empty;

                if(pick.HasOverUnder)
                {
                    ouDesc = pick.OverUnder.ToString();
                }

                sb.AppendLine(string.Format(PICK_FORMAT, pickName, againstName, game.Favorite, game.Spread, pick.HasOverUnder.ToString(), ouDesc));
            }
            sb.AppendLine("</table>");

            var client = new SmtpClient();
            
            client.Send(message);
        }

        private void Email(Exception ex)
        {

            var message = new MailMessage("vegashat@willnette.com", BearchopSession.Current.CurrentUser.Email);
            message.CC.Add("vegashat@willnette.com");

            message.Body = "Error saving picks \r\n";
            message.Body += ex.ToString();

            var client = new SmtpClient();
            client.Send(message);
        }
    }
}
