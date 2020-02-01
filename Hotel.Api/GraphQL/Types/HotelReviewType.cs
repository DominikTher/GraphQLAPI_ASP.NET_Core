using GraphQL.Types;
using Hotel.DataAccess.Entities;

namespace Hotel.GraphQL.Types
{
    public class HotelReviewType : ObjectGraphType<HotelReview>
    {
        public HotelReviewType()
        {
            Field(entity => entity.Id);
            Field(entity => entity.Author);
            Field(entity => entity.Rating);
        }
    }
}
