using GraphQL.Types;
using Hotel.DataAccess.Entities;

namespace Hotel.Api.GraphQL.Types
{
    public class HotelInterface : InterfaceGraphType<HotelEntity>
    {
        public HotelInterface()
        {
            Name = "Hotel";

            Field(entity => entity.Id);
            Field(entity => entity.Name);
            Field(entity => entity.Description);
        }
    }
}
