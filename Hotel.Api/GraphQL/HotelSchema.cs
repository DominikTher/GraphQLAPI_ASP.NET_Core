using GraphQL;
using GraphQL.Types;

namespace Hotel.GraphQL
{
    public class HotelSchema : Schema
    {
        public HotelSchema(IDependencyResolver dependencyResolver)
            : base(dependencyResolver)
        {
            Query = dependencyResolver.Resolve<HotelQuery>();
        }
    }
}
