using GraphQL.Types;
using Hotel.Api.GraphQL.Types;
using Hotel.DataAccess.Entities;
using Hotel.GraphQL.Types;
using Hotel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Api.GraphQL
{
    public class HotelMutation : ObjectGraphType
    {
        public HotelMutation(HotelReviewRepository hotelReviewRepository)
        {
            FieldAsync<HotelReviewType>(
                "addReview",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<HotelReviewInputType>> { Name = "Review" }),
                resolve: async context => {
                    var review = context.GetArgument<HotelReview>("review");

                    return await context.TryAsyncResolve(async c => await hotelReviewRepository.AddAsync(review));
                });
        }
    }
}
