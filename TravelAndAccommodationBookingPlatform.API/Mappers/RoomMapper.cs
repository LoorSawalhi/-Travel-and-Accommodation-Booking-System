using Riok.Mapperly.Abstractions;
using TravelAndAccommodationBookingPlatform.API.DTOs;
using TravelAndAccommodationBookingPlatform.Domain.Models;

namespace TravelAndAccommodationBookingPlatform.API.Mappers;

[Mapper]
public partial class RoomMapper
{
    public partial RoomDto MapFromDomainToApi(Room room);
    public partial Room MapFromApiToDomain(RoomDto room);
}