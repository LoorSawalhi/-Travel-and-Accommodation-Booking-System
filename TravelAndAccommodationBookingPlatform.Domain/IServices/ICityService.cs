using Sieve.Models;
using TravelAndAccommodationBookingPlatform.Domain.Models;

namespace TravelAndAccommodationBookingPlatform.Domain.IServices;

public interface ICityService
{
    IQueryable<City> FindCityByName(string name);
    Task<IEnumerable<City>> FindCitiesAsync(SieveModel sieveModel);
}