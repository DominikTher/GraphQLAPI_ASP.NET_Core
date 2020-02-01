using GraphQL.DataLoader;
using GraphQL.Types;
using Hotel.DataAccess.Entities;
using Hotel.Repositories;
using System.Security.Claims;

namespace Hotel.GraphQL.Types
{
    //public class HotelType : ObjectGraphType<HotelEntity>
    //{
    //    public HotelType(HotelReviewRepository hotelReviewRepository, IDataLoaderContextAccessor dataLoaderContextAccessor)
    //    {
    //        Field(entity => entity.Id);
    //        Field(entity => entity.Name);
    //        Field(entity => entity.Description);
    //        Field<HotelTypeEnum>("HotelType", "The type of hotel");
    //        //Field<ListGraphType<HotelReviewType>>("HotelReviews", resolve: context => hotelReviewRepository.GetForHotel(context.Source.Id));

    //        Field<ListGraphType<HotelReviewType>>(
    //            "HotelReviews",
    //            resolve: context =>
    //            {
    //                // TODO
    //                var user = context.UserContext as ClaimsPrincipal;

    //                var loader = dataLoaderContextAccessor.Context.GetOrAddCollectionBatchLoader<int, HotelReview>("GetReviewsByHotelId", hotelReviewRepository.GetForHotels);

    //                return loader.LoadAsync(context.Source.Id);
    //            });
    //    }
    //}
}
