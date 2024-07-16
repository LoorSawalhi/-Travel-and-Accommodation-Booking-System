using Sieve.Models;
using TravelAndAccommodationBookingPlatform.Domain.Models;

namespace TravelAndAccommodationBookingPlatform.Domain.IRepository;

public interface IHotelRepository
{
    Task<Hotel?> GetHotelByName(string hotelName);
    Task<IEnumerable<Hotel>> GetHotelByStarRating(int starRating);
    Task<IEnumerable<Hotel>> GetHotelByPriceRange(decimal minPrice, decimal maxPrice);
    Task<IEnumerable<Hotel>> GetHotelByCityName(string cityName);
    Task<IEnumerable<Hotel>> GetAllHotels(SieveModel sieveModel);
    Task<IEnumerable<Room>> GetHotelRooms(int hotelId);
}