using GraphQL.DataLoader;
using GraphQL.Types;
using Hotel.Api.DataAccess.Entities;
using Hotel.DataAccess.Entities;
using Hotel.GraphQL.Types;
using Hotel.Repositories;
using System.Security.Claims;

namespace Hotel.Api.GraphQL.Types
{
    public class FancyHotelType: ObjectGraphType<FancyHotel>
    {
        public FancyHotelType(HotelReviewRepository hotelReviewRepository, IDataLoaderContextAccessor dataLoaderContextAccessor)
        {
            Name = "FancyHotel";

            Field(entity => entity.Id);
            Field(entity => entity.Name);
            Field(entity => entity.Description);
            Field<HotelTypeEnum>("HotelType", "The type of hotel");
            //Field<ListGraphType<HotelReviewType>>("HotelReviews", resolve: context => hotelReviewRepository.GetForHotel(context.Source.Id));

            Field<ListGraphType<HotelReviewType>>(
                "HotelReviews",
                resolve: context =>
                {
                            // TODO
                            var user = context.UserContext as ClaimsPrincipal;

                    var loader = dataLoaderContextAccessor.Context.GetOrAddCollectionBatchLoader<int, HotelReview>("GetReviewsByHotelId", hotelReviewRepository.GetForHotels);

                    return loader.LoadAsync(context.Source.Id);
                });

            Interface<HotelInterface>();
        }
    }
}
