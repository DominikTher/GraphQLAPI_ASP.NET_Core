using GraphQL.Types;
using Hotel.DataAccess.Entities;
using Hotel.Repositories;

namespace Hotel.GraphQL.Types
{
    public class HotelType : ObjectGraphType<HotelEntity>
    {
        public HotelType(HotelReviewRepository hotelReviewRepository)
        {
            Field(entity => entity.Id);
            Field(entity => entity.Name);
            Field(entity => entity.Description);
            Field<HotelTypeEnum>("HotelType", "The type of hotel");
            FieldAsync<ListGraphType<HotelReviewType>>("HotelReviews", resolve: async context => await hotelReviewRepository.GetForHotel(context.Source.Id));
        }
    }
}
