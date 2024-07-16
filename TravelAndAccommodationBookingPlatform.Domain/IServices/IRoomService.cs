using Sieve.Models;
using TravelAndAccommodationBookingPlatform.Domain.Models;

namespace TravelAndAccommodationBookingPlatform.Domain.IServices;

public interface IRoomService
{
    Task<IEnumerable<Room>> FindRoomsAsync(SieveModel sieveModel);
}