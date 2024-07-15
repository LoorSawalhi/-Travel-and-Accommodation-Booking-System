using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sieve.Models;
using Sieve.Services;
using TravelAndAccommodationBookingPlatform.Db.Data;
using TravelAndAccommodationBookingPlatform.Db.Mappers;
using TravelAndAccommodationBookingPlatform.Domain.IRepository;
using TravelAndAccommodationBookingPlatform.Domain.Models;

namespace TravelAndAccommodationBookingPlatform.Db.Repositories;

public class HotelRepository(
    ISieveProcessor sieveProcessor,
    HotelsBookingSystemContext context,
    HotelMapper mapper,
    CityMapper cityMapper,
    ILogger<HotelRepository> logger)
    : IHotelRepository
{
    private readonly ILogger<HotelRepository> _logger = logger;

    public async Task<IEnumerable<Hotel>> GetHotelByName(string hotelName)
    {
        var hotels =  await context.Hotels
            .Where(hotel => hotel.Name.ToLower().Contains(hotelName.ToLower()))
            .ToListAsync();
        return hotels.Select(hotel => mapper.MapFromDbToDomain(hotel));
    }

    public async Task<IEnumerable<Hotel>> GetHotelByStarRating(int starRating)
    {
        var hotels = await context.Hotels
            .Where(hotel => hotel.StarRating == starRating)
            .ToListAsync();
        return hotels.Select(hotel => mapper.MapFromDbToDomain(hotel));
    }

    public async Task<IEnumerable<Hotel>> GetHotelByPriceRange(decimal minPrice, decimal maxPrice)
    {
        return await context.Hotels.Select(hotel => mapper.MapFromDbToDomain(hotel))
            .Where(hotel => hotel.MinPrice >= minPrice && hotel.MaxPrice <= maxPrice)
            .ToListAsync();
    }

    public async Task<IEnumerable<Hotel>> GetHotelByCityName(string cityName)
    {
        return await context.Hotels.Select(hotel => mapper.MapFromDbToDomain(hotel))
            .Where(hotel => hotel.City.Name.Equals(cityName, StringComparison.InvariantCultureIgnoreCase))
            .ToListAsync();
    }

    public async Task<IEnumerable<Hotel>> GetAllHotels(SieveModel sieveModel)
    {
        var result = await sieveProcessor.Apply(sieveModel, context.Hotels)
            .Include(hotel =>hotel.City).ToListAsync();

        return result.Select(hotel => new
            {
                hotel = mapper.MapFromDbToDomain(hotel),
                city = cityMapper.MapFromDbToDomain(hotel.City)
            })
            .ToList()
            .Select(h =>
            {
                h.hotel.City = h.city;
                return h.hotel;
            });
    }
}