using GraphQL.Types;

namespace Hotel.GraphQL.Types
{
    public class HotelTypeEnum : EnumerationGraphType<DataAccess.Entities.HotelType>
    {
        public HotelTypeEnum()
        {
            Name = "Type";
            Description = "The type of hotel";
        }
    }
}
