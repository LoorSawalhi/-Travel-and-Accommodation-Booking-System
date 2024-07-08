using Riok.Mapperly.Abstractions;

using City = TravelAndAccommodationBookingPlatform.Db.Models.City;
using CityDomain = TravelAndAccommodationBookingPlatform.Domain.Models.City;

namespace TravelAndAccommodationBookingPlatform.Db.Mappers;

[Mapper]
public partial class CityMapper 
{
    public partial CityDomain MapFromDbToDomain(City city);
    public partial City MapFromDomainToDb(CityDomain city);
}