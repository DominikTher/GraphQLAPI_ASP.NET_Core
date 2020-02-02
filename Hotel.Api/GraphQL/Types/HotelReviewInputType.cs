using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Api.GraphQL.Types
{
    public class HotelReviewInputType : InputObjectGraphType
    {
        public HotelReviewInputType()
        {
            Name = "HotelReviewInput";

            Field<NonNullGraphType<StringGraphType>>("Author");
            Field<NonNullGraphType<IntGraphType>>("Rating");
            Field<NonNullGraphType<IntGraphType>>("HotelId");
        }
    }
}
