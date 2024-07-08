using TravelAndAccommodationBookingPlatform.Db.Data;
using TravelAndAccommodationBookingPlatform.Db.Mappers;
using TravelAndAccommodationBookingPlatform.Domain.IRepository;
using TravelAndAccommodationBookingPlatform.Domain.Models;

namespace TravelAndAccommodationBookingPlatform.Db.Repositories;

public class HotelRepository : IHotelRepository
{
    private readonly HotelsBookingSystemContext _context;
    private readonly HotelMapper _mapper;

    public HotelRepository(HotelsBookingSystemContext context, HotelMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IQueryable<Hotel> GetHotelByName(string hotelName)
    {
        return _context.Hotels.Select(hotel => _mapper.MapFromDbToDomain(hotel))
            .Where(hotel => hotel.Name.Equals(hotelName, StringComparison.InvariantCultureIgnoreCase));
    }

    public IQueryable<Hotel> GetHotelByStarRating(int starRating)
    {
        return _context.Hotels.Select(hotel => _mapper.MapFromDbToDomain(hotel))
            .Where(hotel => hotel.StarRating == starRating);
    }

    public IQueryable<Hotel> GetHotelByPriceRange(decimal minPrice, decimal maxPrice)
    {
        return _context.Hotels.Select(hotel => _mapper.MapFromDbToDomain(hotel))
            .Where(hotel => hotel.MinPrice >= minPrice && hotel.MaxPrice <= maxPrice);
    }

    public IQueryable<Hotel> GetHotelByCityName(string cityName)
    {
        return _context.Hotels.Select(hotel => _mapper.MapFromDbToDomain(hotel))
            .Where(hotel => hotel.City.Name.Equals(cityName, StringComparison.InvariantCultureIgnoreCase));
    }
}