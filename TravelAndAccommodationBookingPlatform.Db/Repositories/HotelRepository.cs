using Microsoft.EntityFrameworkCore;
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

    public async Task<IEnumerable<Hotel>> GetHotelByName(string hotelName)
    {
        var hotels =  await _context.Hotels
            .Where(hotel => hotel.Name.ToLower().Contains(hotelName.ToLower()))
            .ToListAsync();
        return hotels.Select(hotel => _mapper.MapFromDbToDomain(hotel));
    }

    public async Task<IEnumerable<Hotel>> GetHotelByStarRating(int starRating)
    {
        return await _context.Hotels.Select(hotel => _mapper.MapFromDbToDomain(hotel))
            .Where(hotel => hotel.StarRating == starRating)
            .ToListAsync();
    }

    public async Task<IEnumerable<Hotel>> GetHotelByPriceRange(decimal minPrice, decimal maxPrice)
    {
        return await _context.Hotels.Select(hotel => _mapper.MapFromDbToDomain(hotel))
            .Where(hotel => hotel.MinPrice >= minPrice && hotel.MaxPrice <= maxPrice)
            .ToListAsync();
    }

    public async Task<IEnumerable<Hotel>> GetHotelByCityName(string cityName)
    {
        return await _context.Hotels.Select(hotel => _mapper.MapFromDbToDomain(hotel))
            .Where(hotel => hotel.City.Name.Equals(cityName, StringComparison.InvariantCultureIgnoreCase))
            .ToListAsync();
    }
}