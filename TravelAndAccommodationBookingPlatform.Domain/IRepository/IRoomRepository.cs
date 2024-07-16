using Sieve.Models;
using TravelAndAccommodationBookingPlatform.Domain.Models;

namespace TravelAndAccommodationBookingPlatform.Domain.IRepository;

public interface IRoomRepository
{
    Task<IEnumerable<Room>> GetAllRooms(SieveModel sieveModel);
}