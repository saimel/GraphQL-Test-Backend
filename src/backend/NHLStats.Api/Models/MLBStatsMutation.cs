

using GraphQL.Types;
using NHLStats.Api.Helpers;
using NHLStats.Core.Data;
using NHLStats.Core.Models;

namespace NHLStats.Api.Models
{
    public class MLBPlayerMutation : ObjectGraphType
    {
        public MLBPlayerMutation(ContextServiceLocator contextServiceLocator)
        {
            Name = "CreatePlayerMutation";

            Field<PlayerType>(
                "createPlayer",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<PlayerInputType>> { Name = "player" }
                ),
                resolve: context =>
                {
                    var player = context.GetArgument<Player>("player");
                    return contextServiceLocator.PlayerRepository.Add(player);
                });

            Field<PlayerStatisticType>(
                "createPlayerStats",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<PlayerStatisticInputType>> { Name = "playerStats" }
                ),
                resolve: context =>
                {
                    var playerStats = context.GetArgument<PlayerStatistic>("playerStats");
                    return contextServiceLocator.PlayerStatisticRepository.Add(playerStats);
                });

            Field<PlayerStatisticType>(
                "createStats",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StatisticInputType>> { Name = "stats" }
                ),
                resolve: context =>
                {
                    var stats = context.GetArgument<PlayerStatistic>("stats");
                    return contextServiceLocator.PlayerStatisticRepository.Add(stats);
                });
        }
    }
}
