using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxSports.Api.Core
{

    public class GameState
    {
        public int GameId { get; set; }
        public int Version { get; set; }
        public int StatusId { get; set; }
        public string Status { get; set; }
        public string UtcDate { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public bool IsOfficial { get; set; }
    }

    public class Teaser
    {
        public int Rating { get; set; }
        public int RatingHome { get; set; }
        public int RatingAway { get; set; }
        public string Text { get; set; }
        public string Home { get; set; }
        public string Away { get; set; }
        public int Status { get; set; }
    }

    public class LineScore
    {
        public int Quarter { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
    }

    public class ScoringSummary
    {
        public int Sequence { get; set; }
        public int TeamId { get; set; }
        public int ScoreTypeId { get; set; }
        public string Summary { get; set; }
        public int Quarter { get; set; }
        public string Time { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
    }

    public class DriveSummary
    {
        public int DriveId { get; set; }
        public int TeamId { get; set; }
        public string Time { get; set; }
        public int Plays { get; set; }
        public int Yards { get; set; }
        public int StartQuarter { get; set; }
        public string StartTime { get; set; }
        public string StartYardline { get; set; }
        public int StartYardsFromGoal { get; set; }
        public string StartEvent { get; set; }
        public int EndQuarter { get; set; }
        public string EndTime { get; set; }
        public string EndYardline { get; set; }
        public int EndYardsFromGoal { get; set; }
        public string EndEvent { get; set; }
    }

    public class PlayByPlay
    {
        public int Sequence { get; set; }
        public int EventId { get; set; }
        public int DriveId { get; set; }
        public int PlayId { get; set; }
        public bool ScoreChanged { get; set; }
        public int StartHomeScore { get; set; }
        public int EndHomeScore { get; set; }
        public int StartAwayScore { get; set; }
        public int EndAwayScore { get; set; }
        public int StartPossessionTeamId { get; set; }
        public int EndPossessionTeamId { get; set; }
        public bool Continuation { get; set; }
        public int FirstPlayerId { get; set; }
        public int Quarter { get; set; }
        public string Time { get; set; }
        public int YardsToGoal { get; set; }
        public string StartYardline { get; set; }
        public string EndYardline { get; set; }
        public int PlayYards { get; set; }
        public int PlayTypeID { get; set; }
        public string PlayTypeDescription { get; set; }
        public string PlayDirection { get; set; }
        public string PlayDetails { get; set; }
        public double HomeWinChance { get; set; }
        public double AwayWinChance { get; set; }
        public int? Down { get; set; }
        public int? Distance { get; set; }
        public int? SecondPlayerId { get; set; }
        public int? FirstTacklePlayerId { get; set; }
    }

    public class Passing
    {
        public int Completions { get; set; }
        public int Attempts { get; set; }
        public int Interceptions { get; set; }
        public int NetYards { get; set; }
        public int Sacks { get; set; }
        public int Touchdowns { get; set; }
        public string TouchdownDistances { get; set; }
        public double QBRating { get; set; }
    }

    public class Rushing
    {
        public int Attempts { get; set; }
        public int Yards { get; set; }
        public int Touchdowns { get; set; }
        public string TouchdownDistances { get; set; }
        public int Fumbles { get; set; }
        public int FumblesLost { get; set; }
    }

    public class Defense
    {
        public int Interceptions { get; set; }
        public int InterceptionReturnYards { get; set; }
        public int InterceptionReturnTouchdowns { get; set; }
        public int FumblesRecovered { get; set; }
        public int FumblesRecoveryTouchdowns { get; set; }
    }

    public class Return
    {
        public int PuntReturns { get; set; }
        public int PuntReturnYards { get; set; }
        public int PuntReturnTouchdowns { get; set; }
        public string PuntReturnTouchdownDistances { get; set; }
        public int PuntReturnLong { get; set; }
        public bool PuntReturnLongTouchdown { get; set; }
        public int KickReturns { get; set; }
        public int KickReturnYards { get; set; }
        public int KickReturnTouchdowns { get; set; }
        public string KickReturnTouchdownDistances { get; set; }
        public int KickReturnLong { get; set; }
        public bool KickReturnLongTouchdown { get; set; }
    }

    public class Kicking
    {
        public int Punts { get; set; }
        public int PuntYards { get; set; }
        public int XPMade { get; set; }
        public int XPAttempted { get; set; }
        public int XPBlocked { get; set; }
        public int FGMade { get; set; }
        public string FGMadeDistances { get; set; }
        public int FGMissed { get; set; }
        public string FGMissedDistances { get; set; }
        public int FGAttempted { get; set; }
        public int FGBlocked { get; set; }
        public string FGBlockedDistances { get; set; }
    }

    public class Misc
    {
        public int FirstDowns { get; set; }
        public int RushFirstDown { get; set; }
        public int PassFirstDown { get; set; }
        public int PenaltyFirstDown { get; set; }
        public int ThirdDownsMade { get; set; }
        public int ThirdDownsAttempted { get; set; }
        public int FourthDownsMade { get; set; }
        public int FourthDownsAttempted { get; set; }
        public int TwoPtConversionMade { get; set; }
        public int TwoPtConversionAttempted { get; set; }
        public int TotalPlays { get; set; }
        public int TotalNetYards { get; set; }
        public string TimeOfPossession { get; set; }
    }

    public class Home
    {
        public Passing Passing { get; set; }
        public Rushing Rushing { get; set; }
        public Defense Defense { get; set; }
        public Return Return { get; set; }
        public Kicking Kicking { get; set; }
        public Misc Misc { get; set; }
    }

    public class Passing2
    {
        public int Completions { get; set; }
        public int Attempts { get; set; }
        public int Interceptions { get; set; }
        public int NetYards { get; set; }
        public int Sacks { get; set; }
        public int Touchdowns { get; set; }
        public string TouchdownDistances { get; set; }
        public double QBRating { get; set; }
    }

    public class Rushing2
    {
        public int Attempts { get; set; }
        public int Yards { get; set; }
        public int Touchdowns { get; set; }
        public string TouchdownDistances { get; set; }
        public int Fumbles { get; set; }
        public int FumblesLost { get; set; }
    }

    public class Defense2
    {
        public int Interceptions { get; set; }
        public int InterceptionReturnYards { get; set; }
        public int InterceptionReturnTouchdowns { get; set; }
        public int FumblesRecovered { get; set; }
        public int FumblesRecoveryTouchdowns { get; set; }
    }

    public class Return2
    {
        public int PuntReturns { get; set; }
        public int PuntReturnYards { get; set; }
        public int PuntReturnTouchdowns { get; set; }
        public string PuntReturnTouchdownDistances { get; set; }
        public int PuntReturnLong { get; set; }
        public bool PuntReturnLongTouchdown { get; set; }
        public int KickReturns { get; set; }
        public int KickReturnYards { get; set; }
        public int KickReturnTouchdowns { get; set; }
        public string KickReturnTouchdownDistances { get; set; }
        public int KickReturnLong { get; set; }
        public bool KickReturnLongTouchdown { get; set; }
    }

    public class Kicking2
    {
        public int Punts { get; set; }
        public int PuntYards { get; set; }
        public int XPMade { get; set; }
        public int XPAttempted { get; set; }
        public int XPBlocked { get; set; }
        public int FGMade { get; set; }
        public string FGMadeDistances { get; set; }
        public int FGMissed { get; set; }
        public string FGMissedDistances { get; set; }
        public int FGAttempted { get; set; }
        public int FGBlocked { get; set; }
        public string FGBlockedDistances { get; set; }
    }

    public class Misc2
    {
        public int FirstDowns { get; set; }
        public int RushFirstDown { get; set; }
        public int PassFirstDown { get; set; }
        public int PenaltyFirstDown { get; set; }
        public int ThirdDownsMade { get; set; }
        public int ThirdDownsAttempted { get; set; }
        public int FourthDownsMade { get; set; }
        public int FourthDownsAttempted { get; set; }
        public int TwoPtConversionMade { get; set; }
        public int TwoPtConversionAttempted { get; set; }
        public int TotalPlays { get; set; }
        public int TotalNetYards { get; set; }
        public string TimeOfPossession { get; set; }
    }

    public class Away
    {
        public Passing2 Passing { get; set; }
        public Rushing2 Rushing { get; set; }
        public Defense2 Defense { get; set; }
        public Return2 Return { get; set; }
        public Kicking2 Kicking { get; set; }
        public Misc2 Misc { get; set; }
    }

    public class TeamStats
    {
        public Home Home { get; set; }
        public Away Away { get; set; }
    }

    public class Home2
    {
        public int PlayerID { get; set; }
        public int Sequence { get; set; }
        public string Position { get; set; }
        public string ShortName { get; set; }
        public string StatLine { get; set; }
        public int Value { get; set; }
    }

    public class Away2
    {
        public int PlayerID { get; set; }
        public int Sequence { get; set; }
        public string Position { get; set; }
        public string ShortName { get; set; }
        public string StatLine { get; set; }
        public int Value { get; set; }
    }

    public class TopPerformers
    {
        public List<Home2> Home { get; set; }
        public List<Away2> Away { get; set; }
    }

    public class Passing3
    {
        public int Id { get; set; }
        public int Completions { get; set; }
        public int Attempts { get; set; }
        public int Interceptions { get; set; }
        public int Yards { get; set; }
        public int Long { get; set; }
        public bool LongTouchdown { get; set; }
        public int Touchdowns { get; set; }
        public string TouchdownDistances { get; set; }
        public double QBRating { get; set; }
    }

    public class Rushing3
    {
        public int Id { get; set; }
        public int Attempts { get; set; }
        public int Yards { get; set; }
        public int Long { get; set; }
        public bool LongTouchdown { get; set; }
        public int Touchdowns { get; set; }
        public int Fumbles { get; set; }
        public int FumblesLost { get; set; }
    }

    public class Receiving
    {
        public int Id { get; set; }
        public int Receptions { get; set; }
        public int Yards { get; set; }
        public int Long { get; set; }
        public bool LongTouchdown { get; set; }
        public int Touchdowns { get; set; }
    }

    public class Defense3
    {
        public int Id { get; set; }
        public int Tackles { get; set; }
        public int Assists { get; set; }
        public int Sacks { get; set; }
        public int PassesDefensed { get; set; }
        public int SackYards { get; set; }
        public int Stuffs { get; set; }
        public int StuffYards { get; set; }
        public int Interceptions { get; set; }
        public int InterceptionYards { get; set; }
        public int InterceptionLong { get; set; }
        public int InterceptionTouchdowns { get; set; }
        public int FumblesRecovered { get; set; }
        public int FumbleRecoveryYards { get; set; }
        public int FumbleRecoveryTouchdowns { get; set; }
    }

    public class Return3
    {
        public int Id { get; set; }
        public int KickReturns { get; set; }
        public int KickReturnYards { get; set; }
        public int KickReturnLong { get; set; }
        public bool KickReturnLongTouchdown { get; set; }
        public int KickReturnTouchdowns { get; set; }
        public int PuntReturns { get; set; }
        public int PuntReturnYards { get; set; }
        public int PuntReturnLong { get; set; }
        public bool PuntReturnLongTouchdown { get; set; }
        public int PuntReturnTouchdowns { get; set; }
    }

    public class Kicking3
    {
        public int Id { get; set; }
        public int Punts { get; set; }
        public int PuntYards { get; set; }
        public int PuntLong { get; set; }
        public int FGMade { get; set; }
        public int FGAttempted { get; set; }
        public string FGMadeDistances { get; set; }
        public string FGMissedDistances { get; set; }
        public int FGBlocked { get; set; }
        public int PATMade { get; set; }
        public int PATAttempted { get; set; }
        public int PATBlocked { get; set; }
    }

    public class Home3
    {
        public List<Passing3> Passing { get; set; }
        public List<Rushing3> Rushing { get; set; }
        public List<Receiving> Receiving { get; set; }
        public List<Defense3> Defense { get; set; }
        public List<Return3> Return { get; set; }
        public List<Kicking3> Kicking { get; set; }
    }

    public class Passing4
    {
        public int Id { get; set; }
        public int Completions { get; set; }
        public int Attempts { get; set; }
        public int Interceptions { get; set; }
        public int Yards { get; set; }
        public int Long { get; set; }
        public bool LongTouchdown { get; set; }
        public int Touchdowns { get; set; }
        public string TouchdownDistances { get; set; }
        public double QBRating { get; set; }
    }

    public class Rushing4
    {
        public int Id { get; set; }
        public int Attempts { get; set; }
        public int Yards { get; set; }
        public int Long { get; set; }
        public bool LongTouchdown { get; set; }
        public int Touchdowns { get; set; }
        public int Fumbles { get; set; }
        public int FumblesLost { get; set; }
    }

    public class Receiving2
    {
        public int Id { get; set; }
        public int Receptions { get; set; }
        public int Yards { get; set; }
        public int Long { get; set; }
        public bool LongTouchdown { get; set; }
        public int Touchdowns { get; set; }
    }

    public class Defense4
    {
        public int Id { get; set; }
        public int Tackles { get; set; }
        public int Assists { get; set; }
        public int Sacks { get; set; }
        public int PassesDefensed { get; set; }
        public int SackYards { get; set; }
        public int Stuffs { get; set; }
        public int StuffYards { get; set; }
        public int Interceptions { get; set; }
        public int InterceptionYards { get; set; }
        public int InterceptionLong { get; set; }
        public int InterceptionTouchdowns { get; set; }
        public int FumblesRecovered { get; set; }
        public int FumbleRecoveryYards { get; set; }
        public int FumbleRecoveryTouchdowns { get; set; }
    }

    public class Return4
    {
        public int Id { get; set; }
        public int KickReturns { get; set; }
        public int KickReturnYards { get; set; }
        public int KickReturnLong { get; set; }
        public bool KickReturnLongTouchdown { get; set; }
        public int KickReturnTouchdowns { get; set; }
        public int PuntReturns { get; set; }
        public int PuntReturnYards { get; set; }
        public int PuntReturnLong { get; set; }
        public bool PuntReturnLongTouchdown { get; set; }
        public int PuntReturnTouchdowns { get; set; }
    }

    public class Kicking4
    {
        public int Id { get; set; }
        public int Punts { get; set; }
        public int PuntYards { get; set; }
        public int PuntLong { get; set; }
        public int FGMade { get; set; }
        public int FGAttempted { get; set; }
        public string FGMadeDistances { get; set; }
        public string FGMissedDistances { get; set; }
        public int FGBlocked { get; set; }
        public int PATMade { get; set; }
        public int PATAttempted { get; set; }
        public int PATBlocked { get; set; }
    }

    public class Away3
    {
        public List<Passing4> Passing { get; set; }
        public List<Rushing4> Rushing { get; set; }
        public List<Receiving2> Receiving { get; set; }
        public List<Defense4> Defense { get; set; }
        public List<Return4> Return { get; set; }
        public List<Kicking4> Kicking { get; set; }
    }

    public class PlayerStats
    {
        public Home3 Home { get; set; }
        public Away3 Away { get; set; }
    }

    public class FoxGameResult
    {
        public GameState GameState { get; set; }
        public List<LineScore> LineScore { get; set; }
        public TeamStats TeamStats { get; set; }
    }

}
