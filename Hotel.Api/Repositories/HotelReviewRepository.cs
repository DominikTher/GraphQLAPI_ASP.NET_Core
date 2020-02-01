using Hotel.DataAccess;
using Hotel.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Repositories
{
    public class HotelReviewRepository
    {
        private readonly HotelContext hotelContext;
        private readonly Func<HotelContext> hotelContextFactory;

        public HotelReviewRepository(HotelContext hotelContext)
        {
            this.hotelContext = hotelContext;
        }

        public HotelReviewRepository(Func<HotelContext> hotelContextFactory)
        {
            this.hotelContextFactory = hotelContextFactory;
        }

        public async Task<IEnumerable<HotelReview>> GetForHotel(int hotelId)
        {
            using var dbContext = hotelContextFactory.Invoke();

            return await dbContext.HotelReviews.Where(entity => entity.HotelId == hotelId).ToListAsync();
        }
    }
}
