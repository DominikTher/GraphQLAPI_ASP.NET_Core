﻿using Hotel.DataAccess;
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
        private readonly Func<HotelContext> hotelContextFactory;

        public HotelReviewRepository(Func<HotelContext> hotelContextFactory)
        {
            this.hotelContextFactory = hotelContextFactory;
        }

        public async Task<IEnumerable<HotelReview>> GetForHotelAsync(int hotelId)
        {
            using var dbContext = hotelContextFactory.Invoke();

            return await dbContext.HotelReviews.Where(entity => entity.HotelId == hotelId).ToListAsync();
        }

        public async Task<ILookup<int, HotelReview>> GetForHotelsAsync(IEnumerable<int> hotelIds)
        {
            using var dbContext = hotelContextFactory.Invoke();
            var reviews = await dbContext.HotelReviews.Where(hotelReview => hotelIds.Contains(hotelReview.HotelId)).ToListAsync();

            return reviews.ToLookup(r => r.HotelId);
        }

        public async Task<HotelReview> AddAsync(HotelReview hotelReview)
        {
            using var dbContext = hotelContextFactory.Invoke();
            var addedEntity = dbContext.HotelReviews.Add(hotelReview);
            await dbContext.SaveChangesAsync();

            return addedEntity.Entity;
        }
    }
}
