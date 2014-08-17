using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bearchop.ViewModels;
using Bearchop.Models;
using Bearchop.LOTW.Core.Service;
using Bearchop.LOTW.Core.Repository;
using System.Text;
using Bearchop.Core.Models;
using Bearchop.Core.Services;

namespace Bearchop.Areas.LOTW.Controllers
{
    public class MessageController : Controller
    {

        GameService _gameService = new GameService();
        PickService _pickService = new PickService();
        WeekService _weekService = new WeekService();
        UserService _userService = new UserService();
        JUserService _jUserService = new JUserService();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Send(MessageViewModel message)
        {
            SendEmail(message.ToList, message.Subject, message.Body);
            return RedirectToAction("Index");            
        }

        const string HOME_TEAM_FAVORED = "<tr><td><strong>{0}</strong></td><td>{1}</td><td>{2}</td><td>{3}</td></tr>";
        const string AWAY_TEAM_FAVORED = "<tr><td>{0}</td><td><strong>{1}</strong></td><td>{2}</td><td>{3}</td></tr>";

        public PartialViewResult Reminder(int? weekNumber)
        {
            var week = _weekService.GetWeek(weekNumber);

            var games = _gameService.GetGames(week.Number);
            
            IEnumerable<string> emailAddresses = GetEmailAddresses();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<p>Just a friendly reminder about the Locks of the Week Contest.  Just click <a href='http://bearchop.com/lotw'>here</a> and select your picks.  The games are below.</p>");

            GetGamesTable(games, sb);

            var model = new MessageViewModel(string.Join(",", emailAddresses), "Make your LOTW Picks", sb.ToString());

            return PartialView("_Message", model);
        }

        private static void GetGamesTable(IQueryable<Bearchop.LOTW.Core.Model.Game> games, StringBuilder sb)
        {
            sb.AppendLine("<table><tr><th>Home Team</th><th>Away Team</th><th>Spread</th><th>Over/Under</th></tr>");

            foreach (var game in games)
            {
                string formatString = HOME_TEAM_FAVORED;
                if (game.Favorite == game.AwayTeam)
                {
                    formatString = AWAY_TEAM_FAVORED;
                }

                sb.AppendLine(string.Format(formatString, game.HomeTeam, game.AwayTeam, game.Spread, game.OverUnder));
            }

            sb.AppendLine("</table>");
        }

        public ActionResult GamesCreated(int week)
        {
            var games = _gameService.GetGames(week);
            IEnumerable<string> emailAddresses = GetEmailAddresses();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format("<p>The games for week {0} have been randomly generated.  Just click <a href='http://bearchop.com/lotw'>here</a> and select your picks.</p>", week));

            GetGamesTable(games, sb);

            var model = new MessageViewModel(string.Join(",", emailAddresses), "New LOTW Games", sb.ToString());

            return PartialView("_Message", model);
        }

        void SendEmail(string toList, string subject, string body)
        {
            //BearchopMailer mailer = new BearchopMailer();
            //mailer.Send(toList, subject, body);
        }

        private IEnumerable<string> GetEmailAddresses()
        {
            
            List<string> emailAddresses = new List<string>();

            var users = _userService.GetUsers();

            //Build the recipient list
            foreach (var user in users)
            {
                emailAddresses.Add(_jUserService.LoadUser(user.Id).Email);
            }

            return emailAddresses;
        }
    }
}
