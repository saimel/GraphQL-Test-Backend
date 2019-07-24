using GraphQL.Types;
using NHLStats.Core.Models;

namespace NHLStats.Api.Models
{
    public class PlayerStatisticType : ObjectGraphType<PlayerStatistic>
    {
        public PlayerStatisticType()
        {
            Field(x => x.Id);
            Field(x => x.SeasonId);
            Field(x => x.Season.Name).Name("season");
            Field(x => x.Team.Abbreviation).Name("teamAbbreviation");
            Field(x => x.Team.League.Abbreviation).Name("leagueAbbreviation");
            Field(x => x.GamesPlayed);
            Field(x => x.AtBat);
            Field(x => x.Hits);
            Field(x => x.RBIs).Name("rbis");
            Field(x => x.HomeRuns);
            Field(x => x.Average);

            // graphql-dotnet can't currently automatically infer int16 so need to resolve manually
            //Field<IntGraphType>("gamesPlayed", resolve: context => context.Source.GamesPlayed);
            //Field<IntGraphType>("atBat", resolve: context => context.Source.AtBat);
            //Field<IntGraphType>("hits", resolve: context => context.Source.Hits);
            //Field<IntGraphType>("rbis", resolve: context => context.Source.RBIs);
            //Field<IntGraphType>("homeRuns", resolve: context => context.Source.HomeRuns);
            //Field<IntGraphType>("ave", resolve: context => context.Source.Average);
        }
    }
}


