 
using GraphQL;
using GraphQL.Types;

namespace NHLStats.Api.Models
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


 