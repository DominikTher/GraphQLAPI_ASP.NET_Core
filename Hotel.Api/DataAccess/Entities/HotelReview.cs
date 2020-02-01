namespace Hotel.DataAccess.Entities
{
    public class HotelReview
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public int Rating { get; set; }

        public int HotelId { get; set; }
        public HotelEntity Hotel { get; set; }
    }
}
