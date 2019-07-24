
using GraphQL.Types;
using NHLStats.Api.Helpers;

namespace NHLStats.Api.Models
{
    public class MLBStatsQuery : ObjectGraphType
    {
        public MLBStatsQuery(ContextServiceLocator contextServiceLocator)
        {
            Field<PlayerType>(
                "player",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => contextServiceLocator.PlayerRepository.Get(context.GetArgument<int>("id")));

            Field<PlayerType>(
                "randomPlayer",
                resolve: context => contextServiceLocator.PlayerRepository.GetRandom());

            Field<ListGraphType<PlayerType>>(
                "allPlayers",
                resolve: context => contextServiceLocator.PlayerRepository.All());
        }
    }
}
