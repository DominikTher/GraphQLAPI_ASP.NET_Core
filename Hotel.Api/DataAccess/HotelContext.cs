using Hotel.Api.DataAccess.Entities;
using Hotel.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hotel.DataAccess
{
    public class HotelContext : DbContext
    {
        public DbSet<FancyHotel> Hotels { get; set; }
        public DbSet<HotelReview> HotelReviews { get; set; }

        public HotelContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {
        }
    }
}
