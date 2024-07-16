using Riok.Mapperly.Abstractions;

using Room = TravelAndAccommodationBookingPlatform.Db.Models.Room;
using RoomDomain = TravelAndAccommodationBookingPlatform.Domain.Models.Room;

namespace TravelAndAccommodationBookingPlatform.Db.Mappers;

[Mapper]
public partial class RoomMapper
{
    [MapperIgnoreSource(nameof(Room.Hotel))]
    public partial RoomDomain MapFromDbToDomain(Room room);
    public partial Room MapFromDomainToDb(RoomDomain room);
}