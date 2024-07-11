using TravelAndAccommodationBookingPlatform.Domain.Models;

namespace TravelAndAccommodationBookingPlatform.Domain.IServices;

public interface IHotelService
{
    Task<IEnumerable<Hotel>> FindHotelsByNameAsync(string name);
}