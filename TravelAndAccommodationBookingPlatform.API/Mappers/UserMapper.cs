using Riok.Mapperly.Abstractions;
using TravelAndAccommodationBookingPlatform.API.DTOs;
using TravelAndAccommodationBookingPlatform.Domain.Models;

namespace TravelAndAccommodationBookingPlatform.API.Mappers;


[Mapper]
public partial class UserMapper
{
    public partial UserDto MapFromDbToDomain(User user);
    public partial User MapFromDomainToDb(UserDto user);   
}