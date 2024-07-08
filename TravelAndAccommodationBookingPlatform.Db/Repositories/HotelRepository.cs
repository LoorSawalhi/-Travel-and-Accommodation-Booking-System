using TravelAndAccommodationBookingPlatform.Db.Data;
using TravelAndAccommodationBookingPlatform.Domain.IRepository;
using TravelAndAccommodationBookingPlatform.Domain.Models;

namespace TravelAndAccommodationBookingPlatform.Db.Repositories;

public class HotelRepository : IHotelRepository
{
    private readonly HotelsBookingSystemContext _context;

    public HotelRepository(HotelsBookingSystemContext context)
    {
        _context = context;
    }

    public IQueryable<Hotel> GetHotelByName(string hotelName)
    {
        return _context.Hotels.Where(hotel => hotel.Name.Equals(hotelName, StringComparison.InvariantCultureIgnoreCase));
    }

    public IQueryable<Hotel> GetHotelByStarRating(int starRating)
    {
        return _context.Hotels.Where(hotel => hotel.StarRating == starRating);
    }

    public IQueryable<Hotel> GetHotelByPriceRange(decimal minPrice, decimal maxPrice)
    {
        return _context.Hotels.Where(hotel => hotel.MinPrice >= minPrice && hotel.MaxPrice <= maxPrice);
    }

    public IQueryable<Hotel> GetHotelByCityName(string cityName)
    {
        throw new NotImplementedException();
    }
}