using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.DataAccess.Entities
{
    public class HotelEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfRooms { get; set; }
        public float PricePerNight { get; set; }
        public HotelType HotelType { get; set; }

        public IEnumerable<HotelReview> HotelReviews { get; set; }
    }
}
