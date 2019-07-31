
using GraphQL.Types;
using MLBStats.Api.Helpers;
using MLBStats.Core.Data;
using MLBStats.Core.Models;

namespace MLBStats.Api.Models
{
    public class PlayerType : ObjectGraphType<Player>
    {
        public PlayerType(ContextServiceLocator contextServiceLocator)
        {
            Field(x => x.Id);
            Field(x => x.Name, true);
            Field(x => x.BirthPlace);
            Field(x => x.Height);
            Field(x => x.WeightLbs);
            Field(x => x.BirthDate);
            //Field<StringGraphType>("birthDate", resolve: context => context.Source.BirthDate.ToShortDateString());
            Field<ListGraphType<PlayerStatisticType>>("playerStats",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => contextServiceLocator.PlayerStatisticRepository.Get(context.Source.Id), description: "Player's stats");
        }
    }
}
