using Hotel.DataAccess.Entities;
using System.Collections.Generic;

namespace Hotel.Api.DataAccess.Entities
{
    public class FancyHotel : HotelEntity
    {
        public int NumberOfRooms { get; set; }
        public float PricePerNight { get; set; }
        public HotelType HotelType { get; set; }

        public IEnumerable<HotelReview> HotelReviews { get; set; }
    }
}
