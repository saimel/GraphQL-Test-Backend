 
using GraphQL;
using GraphQL.Types;

namespace MLBStats.Api.Models
{
    public class MLBStatsSchema : Schema
    {
        public MLBStatsSchema(IDependencyResolver resolver): base(resolver)
        {
            Query = resolver.Resolve<MLBStatsQuery>();
            Mutation = resolver.Resolve<MLBPlayerMutation>();
        }
    }
}


 