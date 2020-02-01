using Hotel.DataAccess.Entities;
using System.Linq;

namespace Hotel.DataAccess
{
    public static class InitialData
    {
        public static void Seed(this HotelContext hotelContext)
        {
            if (!hotelContext.Hotels.Any())
            {
                hotelContext.Hotels.Add(new HotelEntity
                {
                    Name = "Aloha",
                    Description = "Hotel in Africa",
                    NumberOfRooms = 150,
                    PricePerNight = 500,
                    HotelType = HotelType.OneStar
                });

                hotelContext.Hotels.Add(new HotelEntity
                {
                    Name = "General",
                    Description = "Hotel in USA",
                    NumberOfRooms = 10,
                    PricePerNight = 100,
                    HotelType = HotelType.OneStar
                });

                hotelContext.Hotels.Add(new HotelEntity
                {
                    Name = "Ultimate",
                    Description = "Hotel in Europe",
                    NumberOfRooms = 60,
                    PricePerNight = 10,
                    HotelType = HotelType.TwoStar
                });

                hotelContext.Hotels.Add(new HotelEntity
                {
                    Name = "Beds",
                    Description = "Hotel in Brno",
                    NumberOfRooms = 80,
                    PricePerNight = 230,
                    HotelType = HotelType.TwoStar
                });

                hotelContext.Hotels.Add(new HotelEntity
                {
                    Name = "International",
                    Description = "Hotel in Slovakia",
                    NumberOfRooms = 200,
                    PricePerNight = 1100,
                    HotelType = HotelType.TwoStar
                });

                hotelContext.SaveChanges();
            }

            if (!hotelContext.HotelReviews.Any())
            {
                hotelContext.HotelReviews.Add(new HotelReview
                {
                    HotelId = 1,
                    Author = "Dominik",
                    Rating = 100
                });

                hotelContext.SaveChanges();
            }
        }
    }
}
