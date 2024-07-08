using TravelAndAccommodationBookingPlatform.Domain.Models;

namespace TravelAndAccommodationBookingPlatform.Domain.IRepository;

public interface IHotelRepository
{
    IQueryable<Hotel> GetHotelByName(string hotelName);
    IQueryable<Hotel> GetHotelByStarRating(int starRating);
    IQueryable<Hotel> GetHotelByPriceRange(decimal minPrice, decimal maxPrice);
    IQueryable<Hotel> GetHotelByCityName(string cityName);
}