using Riok.Mapperly.Abstractions;

using Reservation = TravelAndAccommodationBookingPlatform.Db.Models.Reservation;
using ReservationDomain = TravelAndAccommodationBookingPlatform.Domain.Models.Reservation;

namespace TravelAndAccommodationBookingPlatform.Db.Mappers;

[Mapper]
public partial class ReservationMapper
{
    public partial ReservationDomain MapFromDbToDomain(Reservation reservation);
    public partial Reservation MapFromDomainToDb(ReservationDomain reservation);
}