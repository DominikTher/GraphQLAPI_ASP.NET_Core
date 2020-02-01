using GraphQL.Types;
using Hotel.Api.GraphQL.Types;
using Hotel.GraphQL.Types;
using Hotel.Repositories;

namespace Hotel.GraphQL
{
    public class HotelQuery : ObjectGraphType
    {
        public HotelQuery(HotelRepository hotelRepository)
        {
            Field<ListGraphType<HotelInterface>>("Hotels", resolve: context => hotelRepository.GetAllAsync());

            Field<FancyHotelType>(
                "Hotel",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");

                    return hotelRepository.GetOneAsync(id);
                }
            );
        }
    }
}
