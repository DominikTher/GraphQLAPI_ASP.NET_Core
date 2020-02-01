using GraphQL.Types;
using Hotel.GraphQL.Types;
using Hotel.Repositories;

namespace Hotel.GraphQL
{
    public class HotelQuery : ObjectGraphType
    {
        public HotelQuery(HotelRepository hotelRepository)
        {
            FieldAsync<ListGraphType<HotelType>>("hotels", resolve: async context => await hotelRepository.GetAllAsync());
        }
    }
}
