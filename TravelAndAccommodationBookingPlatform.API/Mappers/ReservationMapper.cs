using Riok.Mapperly.Abstractions;
using TravelAndAccommodationBookingPlatform.API.DTOs;
using TravelAndAccommodationBookingPlatform.Domain.Models;

namespace TravelAndAccommodationBookingPlatform.API.Mappers;

[Mapper]
public partial class ReservationMapper
{
    public partial ReservationDto MapFromDbToDomain(Reservation reservation);
    public partial Reservation MapFromDomainToDb(ReservationDto reservation);
}