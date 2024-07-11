using TravelAndAccommodationBookingPlatform.Domain.Models;

namespace TravelAndAccommodationBookingPlatform.Domain.IRepository;

public interface IHotelRepository
{
    Task<IEnumerable<Hotel>> GetHotelByName(string hotelName);
    Task<IEnumerable<Hotel>> GetHotelByStarRating(int starRating);
    Task<IEnumerable<Hotel>> GetHotelByPriceRange(decimal minPrice, decimal maxPrice);
    Task<IEnumerable<Hotel>> GetHotelByCityName(string cityName);
}