using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxSports.Api.Core
{

    public class EventType
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Record
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int lastModifyDateUtc { get; set; }
    }

    public class LogoFlipOrientation
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class HomeTeam
    {
        public int id { get; set; }
        public string uri { get; set; }
        public int groupId { get; set; }
        public string location { get; set; }
        public string name { get; set; }
        public string abbreviation { get; set; }
        public string customName { get; set; }
        public string primaryColor { get; set; }
        public string secondaryColor { get; set; }
        public bool useSecondaryColor { get; set; }
        public Record record { get; set; }
        public string siteUrl { get; set; }
        public string teamColorAccent { get; set; }
        public string teamColorBaseOne { get; set; }
        public string teamColorBaseTwo { get; set; }
        public string teamColorComplimentary { get; set; }
        public string twitterAccount { get; set; }
        public string twitterId { get; set; }
        public string facebookAccount { get; set; }
        public string facebookId { get; set; }
        public bool logoFlippable { get; set; }
        public LogoFlipOrientation logoFlipOrientation { get; set; }
    }

    public class Record2
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int lastModifyDateUtc { get; set; }
    }

    public class LogoFlipOrientation2
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class AwayTeam
    {
        public int id { get; set; }
        public string uri { get; set; }
        public int groupId { get; set; }
        public string location { get; set; }
        public string name { get; set; }
        public string abbreviation { get; set; }
        public string customName { get; set; }
        public string primaryColor { get; set; }
        public string secondaryColor { get; set; }
        public bool useSecondaryColor { get; set; }
        public Record2 record { get; set; }
        public string siteUrl { get; set; }
        public string teamColorAccent { get; set; }
        public string teamColorBaseOne { get; set; }
        public string teamColorBaseTwo { get; set; }
        public string teamColorComplimentary { get; set; }
        public string twitterAccount { get; set; }
        public string twitterId { get; set; }
        public string facebookAccount { get; set; }
        public string facebookId { get; set; }
        public bool logoFlippable { get; set; }
        public LogoFlipOrientation2 logoFlipOrientation { get; set; }
    }

    public class Status
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Api
    {
        public string home { get; set; }
        public string away { get; set; }
        public string content_json { get; set; }
        public string preview_json { get; set; }
        public string recap_json { get; set; }
        public string content_xml { get; set; }
        public string preview_xml { get; set; }
        public string recap_xml { get; set; }
    }

    public class Web
    {
        public string gametrax { get; set; }
        public string boxscore { get; set; }
    }

    public class Links
    {
        public Api api { get; set; }
        public Web web { get; set; }
    }

    public class Game
    {
        public int openingFavoriteTeamId { get; set; }
        public double openingFavoritePoints { get; set; }
        public int openingFavoriteMoney { get; set; }
        public int openingUnderdogMoney { get; set; }
        public int openingOverMoney { get; set; }
        public int openingUnderMoney { get; set; }
        public int currentFavoriteTeamId { get; set; }
        public double currentFavoritePoints { get; set; }
        public int currentFavoriteMoney { get; set; }
        public int currentUnderdogMoney { get; set; }
        public int currentOverMoney { get; set; }
        public int currentUnderMoney { get; set; }
    }

    public class StatsInc
    {
        public Game Game { get; set; }
    }

    public class Game2
    {
        public int openingFavoriteTeamId { get; set; }
        public double openingFavoritePoints { get; set; }
        public int openingFavoriteMoney { get; set; }
        public int openingUnderdogMoney { get; set; }
        public int openingHomeMoney { get; set; }
        public int openingAwayMoney { get; set; }
        public int currentFavoriteTeamId { get; set; }
        public double currentFavoritePoints { get; set; }
        public int currentFavoriteMoney { get; set; }
        public int currentUnderdogMoney { get; set; }
        public int currentHomeMoney { get; set; }
        public int currentAwayMoney { get; set; }
        public int lineChangeDate { get; set; }
    }

    public class __invalid_type__5DimesEu
    {
        public Game2 Game { get; set; }
    }

    public class Game3
    {
        public int openingFavoriteTeamId { get; set; }
        public double openingFavoritePoints { get; set; }
        public int openingFavoriteMoney { get; set; }
        public int openingUnderdogMoney { get; set; }
        public int currentFavoriteTeamId { get; set; }
        public double currentFavoritePoints { get; set; }
        public int currentFavoriteMoney { get; set; }
        public int currentUnderdogMoney { get; set; }
        public int lineChangeDate { get; set; }
    }

    public class BETONLINE
    {
        public Game3 Game { get; set; }
    }

    public class Game4
    {
        public int openingFavoriteTeamId { get; set; }
        public double openingFavoritePoints { get; set; }
        public int openingFavoriteMoney { get; set; }
        public int openingUnderdogMoney { get; set; }
        public int currentFavoriteTeamId { get; set; }
        public double currentFavoritePoints { get; set; }
        public int currentFavoriteMoney { get; set; }
        public int currentUnderdogMoney { get; set; }
        public int lineChangeDate { get; set; }
    }

    public class SportsBettingAg
    {
        public Game4 Game { get; set; }
    }

    public class Odds
    {
        public StatsInc StatsInc { get; set; }
        public BETONLINE BETONLINE { get; set; }
    }

    public class State
    {
        public int id { get; set; }
        public string name { get; set; }
        public string abbreviation { get; set; }
    }

    public class Country
    {
        public int id { get; set; }
        public string name { get; set; }
        public string abbreviation { get; set; }
        public string shortname { get; set; }
    }

    public class Web2
    {
        public string map { get; set; }
    }

    public class Links2
    {
        public Web2 web { get; set; }
    }

    public class Venue
    {
        public int id { get; set; }
        public string name { get; set; }
        public string city { get; set; }
        public State state { get; set; }
        public Country country { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public Links2 links { get; set; }
    }

    public class Details
    {
        public int AwayTeamRank { get; set; }
        public int HomeTeamRank { get; set; }
    }

    public class Page
    {
        public double homeTeamPickemPickPct { get; set; }
        public double awayTeamPickemPickPct { get; set; }
        public string uri { get; set; }
        public int date { get; set; }
        public int utcDate { get; set; }
        public int week { get; set; }
        public string seasonType { get; set; }
        public int season { get; set; }
        public EventType eventType { get; set; }
        public HomeTeam homeTeam { get; set; }
        public AwayTeam awayTeam { get; set; }
        public Status status { get; set; }
        public Links links { get; set; }
        //public Odds odds { get; set; }
        public Venue venue { get; set; }
        public bool isTBA { get; set; }
        public bool isNeutralSite { get; set; }
        public int localDate { get; set; }
        public Details details { get; set; }
        public int lastModifyDateUtc { get; set; }
        public int coverageLevel { get; set; }
        public int id { get; set; }
    }

    public class Schedule
    {
        public int totalCount { get; set; }
        public int pageSize { get; set; }
        public int currentPageStart { get; set; }
        public List<Page> page { get; set; }
    }

}
