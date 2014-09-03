using System;
using System.Collections.Generic;

namespace Bearchop.LOTW.Core.Models
{
    public enum OverUnderEnum
    {
        Over = 0,
        Under = 1,
        Push = 2
    }

    public partial class Game
    {

        const string DESCRIPTION_FORMAT = "{0} @ {1}";
        const string SPREAD_FORMAT = "{1}";

        public Game()
        {
            this.Picks = new List<Pick>();
        }

        public int Id { get; set; }
        public int WeekId { get; set; }
        public System.DateTime Date { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public decimal HomeTeamSpread { get; set; }
        public decimal AwayTeamSpread { get; set; }
        public decimal OverUnder { get; set; }
        public decimal FinalScore { get; set; }
        public decimal HomeTeamScore { get; set; }
        public decimal AwayTeamScore { get; set; }
        public virtual Week Week { get; set; }
        public virtual ICollection<Pick> Picks { get; set; }

        public string Favorite
        {
            get
            {
                if (HomeTeamSpread < 0)
                {
                    return HomeTeam;
                }
                else
                {
                    return AwayTeam;
                }
            }
        }

        public string Description
        {
            get
            {
                return string.Format(DESCRIPTION_FORMAT, AwayTeam.TeamMascot(), HomeTeam.TeamMascot());
            }
        }

        public string Spread
        {
            get
            {
                //If the spread hasn't been set yet
                if (HomeTeamSpread == 0)
                    return string.Empty;

                if (HomeTeamSpread < 0)
                {
                    return string.Format(SPREAD_FORMAT, HomeTeam, HomeTeamSpread);
                }
                else
                {
                    return string.Format(SPREAD_FORMAT, AwayTeam, AwayTeamSpread);
                }
            }
        }
        public bool Finalized
        {
            get
            {
                return ((FinalScore > 0) && (HomeTeamScore + AwayTeamScore == FinalScore));
            }
        }

        public string WinningTeam
        {
            get
            {
                if (HomeTeamScore > AwayTeamScore)
                {
                    return HomeTeam;
                }
                return AwayTeam;
            }
        }

        public string WinningTeamATS
        {
            get
            {
                //Just find out if the home team won.

                //If home team favored
                if (HomeTeamSpread < 0)
                {
                    decimal adjustedScore = HomeTeamScore + HomeTeamSpread;
                    if (adjustedScore > AwayTeamScore)
                    {
                        return HomeTeam;
                    }
                    else if (adjustedScore == AwayTeamScore)
                    {
                        return "PUSH";
                    }
                    else
                    {
                        return AwayTeam;
                    }
                }
                //Away Team Favored
                else
                {
                    decimal adjustedScore = AwayTeamScore + AwayTeamSpread;
                    if (adjustedScore > HomeTeamScore)
                    {
                        return AwayTeam;
                    }
                    else if (adjustedScore == AwayTeamScore)
                    {
                        return "PUSH";
                    }
                    else
                    {
                        return HomeTeam;
                    }
                }
            }
        }

        public OverUnderEnum OverUnderResult
        {
            get
            {
                if (FinalScore > OverUnder)
                {
                    return OverUnderEnum.Over;
                }
                else if (FinalScore == OverUnder)
                {
                    return OverUnderEnum.Push;
                }
                else
                {
                    return OverUnderEnum.Under;
                }
            }
        }
    }
    public static class GameExtensions
    {
        public static string TeamMascot(this string team)
        {
            var name = team.Split(' ');

            return name[name.Length - 1];
        }
    }
}
