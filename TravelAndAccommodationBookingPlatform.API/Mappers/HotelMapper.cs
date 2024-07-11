using Riok.Mapperly.Abstractions;
using TravelAndAccommodationBookingPlatform.API.DTOs;
using TravelAndAccommodationBookingPlatform.Domain.Models;

namespace TravelAndAccommodationBookingPlatform.API.Mappers;

[Mapper]
public partial class HotelMapper
{
    public partial Hotel MapFromAPIToDomain(HotelDto hotel);
    public partial HotelDto MapFromDomainToAPI(Hotel hotel);
}