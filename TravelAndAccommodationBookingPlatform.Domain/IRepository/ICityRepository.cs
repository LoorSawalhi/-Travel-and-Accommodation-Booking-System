using Sieve.Models;
using TravelAndAccommodationBookingPlatform.Domain.Models;

namespace TravelAndAccommodationBookingPlatform.Domain.IRepository;

public interface ICityRepository
{
    IQueryable<City> GetCityByName(string cityName);
    Task<IEnumerable<City>> GetAllCitiesAsync(SieveModel sieveModel);
}