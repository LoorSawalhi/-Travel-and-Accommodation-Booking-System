using Riok.Mapperly.Abstractions;
using Hotel = TravelAndAccommodationBookingPlatform.Db.Models.Hotel;
using HotelDomain = TravelAndAccommodationBookingPlatform.Domain.Models.Hotel;

namespace TravelAndAccommodationBookingPlatform.Db.Mappers;

[Mapper]
public partial class HotelMapper
{
    [MapperIgnoreSource(nameof(Hotel.City))]
    public partial HotelDomain MapFromDbToDomain(Hotel customer);
    public partial Hotel MapFromDomainToDb(HotelDomain customer);
}