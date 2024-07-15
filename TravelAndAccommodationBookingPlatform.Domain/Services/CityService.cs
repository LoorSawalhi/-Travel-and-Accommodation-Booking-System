using Sieve.Models;
using TravelAndAccommodationBookingPlatform.Domain.IRepository;
using TravelAndAccommodationBookingPlatform.Domain.IServices;
using TravelAndAccommodationBookingPlatform.Domain.Models;

namespace TravelAndAccommodationBookingPlatform.Domain.Services;

public class CityService : ICityService
{
    private readonly ICityRepository _cityRepository;

    public CityService(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public IQueryable<City> FindCityByName(string name)
    {
        return _cityRepository.GetCityByName(name);
    }

    public async  Task<IEnumerable<City>> FindCitiesAsync(SieveModel sieveModel)
    {
        return await _cityRepository.GetAllCitiesAsync(sieveModel);
    }
}