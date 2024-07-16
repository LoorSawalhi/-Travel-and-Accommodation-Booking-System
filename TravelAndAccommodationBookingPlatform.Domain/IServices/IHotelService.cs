using Sieve.Models;
using TravelAndAccommodationBookingPlatform.Domain.Models;

namespace TravelAndAccommodationBookingPlatform.Domain.IServices;

public interface IHotelService
{
    Task<IEnumerable<Hotel>> FindHotelsAsync(SieveModel sieveModel);
    Task<Hotel> FindHotelsByNameAsync(string name);
    Task<IEnumerable<Hotel>> FindHotelsByRatingAsync(int rating);
    Task<IEnumerable<Room>> FindHotelsRoomsAsync(string hotelName);
}