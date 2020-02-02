using GraphQL;
using GraphQL.Types;
using Hotel.Api.GraphQL;

namespace Hotel.GraphQL
{
    public class HotelSchema : Schema
    {
        public HotelSchema(IDependencyResolver dependencyResolver)
            : base(dependencyResolver)
        {
            Query = dependencyResolver.Resolve<HotelQuery>();
            Mutation = dependencyResolver.Resolve<HotelMutation>();
        }
    }
}
