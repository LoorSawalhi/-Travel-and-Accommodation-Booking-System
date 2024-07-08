using Riok.Mapperly.Abstractions;

using User = TravelAndAccommodationBookingPlatform.Db.Models.User;
using UserDomain = TravelAndAccommodationBookingPlatform.Domain.Models.User;

namespace TravelAndAccommodationBookingPlatform.Db.Mappers;

[Mapper]
public partial class UserMapper
{
    public partial UserDomain MapFromDbToDomain(User user);
    public partial User MapFromDomainToDb(UserDomain user);   
}