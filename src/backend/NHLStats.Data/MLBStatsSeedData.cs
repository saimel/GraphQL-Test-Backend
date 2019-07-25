
using System;
using System.Collections.Generic;
using System.Linq;
using MLBStats.Core.Models;

namespace MLBStats.Data
{
    public static class NHLStatsSeedData
    {
        private const string RegularSeason2016 = "2016 Regular Season";
        private const string RegularSeason2017 = "2017 Regular Season";
        private const string RegularSeason2018 = "2018 Regular Season";

        public static void EnsureSeedData(this MLBStatsContext db)
        {
            if (!db.Players.Any())
            {
                var players = new List<Player>
                {
                   new Player { Name = "Didi Gregorius", BirthDate = new DateTime(1990,2,18), Height = "6'03",WeightLbs = 205, BirthPlace = "Amsterdan, Netherlands"},
                   new Player { Name = "Yuliesky Gurriel", BirthDate = new DateTime(1984,6,9), Height = "6'00",WeightLbs = 190, BirthPlace = "Sancti Spiritus, Cuba"},
                   //new Player { Name = "Xander Bogaerts", BirthDate = new DateTime(1992,1,1), Height = "6'01",WeightLbs = 210, BirthPlace = "Oranjestad, Aruba"},
                   new Player { Name = "Jose Abreu", BirthDate = new DateTime(1987,1,29), Height = "6'03",WeightLbs = 255, BirthPlace = "Cienfuegos, Cuba"},
                   //new Player { Name = "Khris Davis", BirthDate = new DateTime(1987,12,21), Height = "5'11",WeightLbs = 203, BirthPlace = "California, USA"},

                   new Player { Name = "Starlin Castro", BirthDate = new DateTime(1990,3,24), Height = "6'02",WeightLbs = 230, BirthPlace = "Monte Cristi, Dom. Rep."},
                   //new Player { Name = "Todd Frazier", BirthDate = new DateTime(1986,2,12), Height = "6'03",WeightLbs = 220, BirthPlace = "New Jersey, USA"},
                   //new Player { Name = "Eugenio Suarez", BirthDate = new DateTime(1991,7,18), Height = "5'11",WeightLbs = 213, BirthPlace = "Puerto Ordaz, Venezuela"},
                   new Player { Name = "Yasmani Grandal", BirthDate = new DateTime(1988,11,8), Height = "6'01",WeightLbs = 235, BirthPlace = "Havana, Cuba"},
                   //new Player { Name = "Cody Bellinger", BirthDate = new DateTime(1995,7,13), Height = "6'04",WeightLbs = 203, BirthPlace = "Arizona, USA"},
                };
                db.Players.AddRange(players);
                db.SaveChanges();
            }

            if (!db.Seasons.Any())
            {
                var seasons = new List<Season>
                {
                    new Season {Name = RegularSeason2016},
                    new Season {Name = RegularSeason2017},
                    new Season {Name = RegularSeason2018}
                };
                db.Seasons.AddRange(seasons);
                db.SaveChanges();
            }

            if (!db.Leagues.Any())
            {
                var al = new League { Name = "American League", Abbreviation = "AL" };
                var nl = new League { Name = "National League", Abbreviation = "NL" };

                var leagues = new List<League> { al, nl };

                db.Leagues.AddRange(leagues);
                db.SaveChanges();

                if (!db.Teams.Any())
                {
                    var teams = new List<Team>
                    {
                        new Team {Name = "New York Yankees", Abbreviation = "NYY", LeagueId = al.Id},
                        new Team {Name = "Boston Red Sox", Abbreviation = "BOS", LeagueId = al.Id},
                        new Team {Name = "Houston Astros", Abbreviation = "HOU", LeagueId = al.Id},
                        new Team {Name = "Chicago White Sox", Abbreviation = "CWS", LeagueId = al.Id},
                        new Team {Name = "Oakland Athletics", Abbreviation = "OAK", LeagueId = al.Id},

                        new Team {Name = "Miami Marlins", Abbreviation = "MIA", LeagueId = nl.Id},
                        new Team {Name = "New York Mets", Abbreviation = "NYM", LeagueId = nl.Id},
                        new Team {Name = "Cincinnati Reds", Abbreviation = "CIN", LeagueId = nl.Id},
                        new Team {Name = "Milwaukee Brewers", Abbreviation = "MIL", LeagueId = nl.Id},
                        new Team {Name = "Los Angeles Dodgers", Abbreviation = "LAD", LeagueId = nl.Id},
                    };
                    db.Teams.AddRange(teams);
                    db.SaveChanges();
                }
            }

            if (!db.PlayerStatistics.Any())
            {
                #region regular seasons
                var regularSeason2016 = db.Seasons.Single(s => s.Name == RegularSeason2016);
                var regularSeason2017 = db.Seasons.Single(s => s.Name == RegularSeason2017);
                var regularSeason2018 = db.Seasons.Single(s => s.Name == RegularSeason2018);
                #endregion
                // players
                var dGregorius = db.Players.Single(p => p.Name == "Didi Gregorius");
                var yGurriel = db.Players.Single(p => p.Name == "Yuliesky Gurriel");
                //var xBogaerts = db.Players.Single(p => p.Name == "Xander Bogaerts");
                var jAbreu = db.Players.Single(p => p.Name == "Jose Abreu");

                var sCastro = db.Players.Single(p => p.Name == "Starlin Castro");
                //var tFrazier = db.Players.Single(p => p.Name == "Todd Frazier");
                var yGrandal = db.Players.Single(p => p.Name == "Yasmani Grandal");
                //var cBellinger = db.Players.Single(p => p.Name == "Cody Bellinger");

                // teams
                var nyy = db.Teams.Single(t => t.Abbreviation == "NYY");
                var hou = db.Teams.Single(t => t.Abbreviation == "BOS");
                var bos = db.Teams.Single(t => t.Abbreviation == "HOU");
                var cws = db.Teams.Single(t => t.Abbreviation == "CWS");
                var oak = db.Teams.Single(t => t.Abbreviation == "OAK");

                var mia = db.Teams.Single(t => t.Abbreviation == "MIA");
                var nym = db.Teams.Single(t => t.Abbreviation == "NYM");
                var cin = db.Teams.Single(t => t.Abbreviation == "CIN");
                var mil = db.Teams.Single(t => t.Abbreviation == "MIL");
                var lad = db.Teams.Single(t => t.Abbreviation == "LAD");

                #region didi gregorius
                var dGregoriusSeason2016 = new PlayerStatistic
                {
                    SeasonId = regularSeason2016.Id,
                    PlayerId = dGregorius.Id,
                    TeamId = nyy.Id,
                    GamesPlayed = 153,
                    AtBat = 562,
                    Hits = 155,
                    RBIs = 70,
                    HomeRuns = 20,
                };
                var dGregoriusSeason2017 = new PlayerStatistic
                {
                    SeasonId = regularSeason2017.Id,
                    PlayerId = dGregorius.Id,
                    TeamId = nyy.Id,
                    GamesPlayed = 136,
                    AtBat = 534,
                    Hits = 135,
                    RBIs = 87,
                    HomeRuns = 25,
                };
                var dGregoriusSeason2018 = new PlayerStatistic
                {
                    SeasonId = regularSeason2018.Id,
                    PlayerId = dGregorius.Id,
                    TeamId = nyy.Id,
                    GamesPlayed = 134,
                    AtBat = 504,
                    Hits = 135,
                    RBIs = 86,
                    HomeRuns = 27,
                };
                db.PlayerStatistics.Add(dGregoriusSeason2016);
                db.PlayerStatistics.Add(dGregoriusSeason2017);
                db.PlayerStatistics.Add(dGregoriusSeason2018);
                #endregion

                #region yuli gurriel
                var yGurrielSeason2016 = new PlayerStatistic
                {
                    SeasonId = regularSeason2016.Id,
                    PlayerId = yGurriel.Id,
                    TeamId = hou.Id,
                    GamesPlayed = 36,
                    AtBat = 130,
                    Hits = 34,
                    RBIs = 15,
                    HomeRuns = 3,
                };
                var yGurrielSeason2017 = new PlayerStatistic
                {
                    SeasonId = regularSeason2017.Id,
                    PlayerId = yGurriel.Id,
                    TeamId = hou.Id,
                    GamesPlayed = 139,
                    AtBat = 529,
                    Hits = 158,
                    RBIs = 75,
                    HomeRuns = 18,
                };
                var yGurrielSeason2018 = new PlayerStatistic
                {
                    SeasonId = regularSeason2018.Id,
                    PlayerId = yGurriel.Id,
                    TeamId = hou.Id,
                    GamesPlayed = 136,
                    AtBat = 537,
                    Hits = 156,
                    RBIs = 85,
                    HomeRuns = 13,
                };
                db.PlayerStatistics.Add(yGurrielSeason2016);
                db.PlayerStatistics.Add(yGurrielSeason2017);
                db.PlayerStatistics.Add(yGurrielSeason2018);
                #endregion

                #region jose abreu
                var jAbreuSeason2016 = new PlayerStatistic
                {
                    SeasonId = regularSeason2016.Id,
                    PlayerId = jAbreu.Id,
                    TeamId = cws.Id,
                    GamesPlayed = 159,
                    AtBat = 624,
                    Hits = 183,
                    RBIs = 100,
                    HomeRuns = 25,
                };
                var jAbreuSeason2017 = new PlayerStatistic
                {
                    SeasonId = regularSeason2017.Id,
                    PlayerId = jAbreu.Id,
                    TeamId = cws.Id,
                    GamesPlayed = 156,
                    AtBat = 621,
                    Hits = 189,
                    RBIs = 102,
                    HomeRuns = 33,
                };
                var jabreuSeason2018 = new PlayerStatistic
                {
                    SeasonId = regularSeason2018.Id,
                    PlayerId = jAbreu.Id,
                    TeamId = cws.Id,
                    GamesPlayed = 128,
                    AtBat = 499,
                    Hits = 132,
                    RBIs = 78,
                    HomeRuns = 22,
                };
                db.PlayerStatistics.Add(jAbreuSeason2016);
                db.PlayerStatistics.Add(jAbreuSeason2017);
                db.PlayerStatistics.Add(jabreuSeason2018);
                #endregion

                #region starlin castro
                var sCastroSeason2016 = new PlayerStatistic
                {
                    SeasonId = regularSeason2016.Id,
                    PlayerId = sCastro.Id,
                    TeamId = nyy.Id,
                    GamesPlayed = 154,
                    AtBat = 577,
                    Hits = 156,
                    RBIs = 70,
                    HomeRuns = 21,
                };
                db.PlayerStatistics.Add(sCastroSeason2016);
                #endregion

                #region yasmani grandal
                var yGrandalSeason2016 = new PlayerStatistic
                {
                    SeasonId = regularSeason2016.Id,
                    PlayerId = yGrandal.Id,
                    TeamId = lad.Id,
                    GamesPlayed = 126,
                    AtBat = 390,
                    Hits = 89,
                    RBIs = 72,
                    HomeRuns = 27,
                };
                var yGrandalSeason2017 = new PlayerStatistic
                {
                    SeasonId = regularSeason2017.Id,
                    PlayerId = yGrandal.Id,
                    TeamId = lad.Id,
                    GamesPlayed = 129,
                    AtBat = 438,
                    Hits = 108,
                    RBIs = 58,
                    HomeRuns = 22,
                };
                var yGrandalSeason2018 = new PlayerStatistic
                {
                    SeasonId = regularSeason2018.Id,
                    PlayerId = yGrandal.Id,
                    TeamId = lad.Id,
                    GamesPlayed = 140,
                    AtBat = 440,
                    Hits = 106,
                    RBIs = 68,
                    HomeRuns = 24,
                };
                db.PlayerStatistics.Add(yGrandalSeason2016);
                db.PlayerStatistics.Add(yGrandalSeason2017);
                db.PlayerStatistics.Add(yGrandalSeason2018);
                #endregion

                db.SaveChanges();
            }
        }
    }
}
