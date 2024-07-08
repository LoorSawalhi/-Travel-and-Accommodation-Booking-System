using Riok.Mapperly.Abstractions;
using TravelAndAccommodationBookingPlatform.API.DTOs;
using TravelAndAccommodationBookingPlatform.Domain.Models;

namespace TravelAndAccommodationBookingPlatform.API.Mappers;

[Mapper]
public partial class HotelMapper
{
    public partial HotelDto MapFromDbToDomain(Hotel customer);
    public partial Hotel MapFromDomainToDb(HotelDto customer);
}