using Riok.Mapperly.Abstractions;
using TravelAndAccommodationBookingPlatform.API.DTOs;
using TravelAndAccommodationBookingPlatform.Domain.Models;

namespace TravelAndAccommodationBookingPlatform.API.Mappers;

[Mapper]
public partial class CityMapper 
{
    public partial CityDto MapFromDomainToApi(City customer);
    public partial City MapFromApiToDomain(CityDto customer);
}