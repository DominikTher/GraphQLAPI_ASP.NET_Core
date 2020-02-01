using Hotel.Api.DataAccess.Entities;
using Hotel.DataAccess;
using Hotel.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Repositories
{
    public class HotelRepository
    {
        private readonly Func<HotelContext> hotelContextFactory;

        public HotelRepository(Func<HotelContext> hotelContextFactory)
        {
            this.hotelContextFactory = hotelContextFactory;
        }

        public async Task<HotelEntity> GetOneAsync(int id)
        {
            using var dbContext = hotelContextFactory.Invoke();

            return await dbContext.Hotels.FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public async Task<IEnumerable<HotelEntity>> GetAllAsync()
        {
            using var dbContext = hotelContextFactory.Invoke();

            return await dbContext.Hotels.ToListAsync();
        }
    }
}
