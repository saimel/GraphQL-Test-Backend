

using GraphQL.Types;

namespace NHLStats.Api.Models
{
    public class PlayerStatisticInputType : InputObjectGraphType
    {
        public PlayerStatisticInputType()
        {
            Name = "PlayerStatisticInput";
            Field<NonNullGraphType<IntGraphType>>("seasonId");
            Field<NonNullGraphType<IntGraphType>>("teamId");
            Field<IntGraphType>("gamesPlayed");
            Field<IntGraphType>("atBat");
            Field<IntGraphType>("hits");
            Field<IntGraphType>("rbis");
            Field<IntGraphType>("homeRuns");
        }
    }

    public class StatisticInputType : PlayerStatisticInputType
    {
        public StatisticInputType() : base()
        {
            Name = "StatisticInput";
            Field<NonNullGraphType<IntGraphType>>("playerId");
        }
    }
}
