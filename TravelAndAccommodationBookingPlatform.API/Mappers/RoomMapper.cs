using Riok.Mapperly.Abstractions;
using TravelAndAccommodationBookingPlatform.API.DTOs;
using TravelAndAccommodationBookingPlatform.Domain.Models;

namespace TravelAndAccommodationBookingPlatform.API.Mappers;

[Mapper]
public partial class RoomMapper
{
    public partial RoomDto MapFromDbToDomain(Room room);
    public partial Room MapFromDomainToDb(RoomDto room);
}