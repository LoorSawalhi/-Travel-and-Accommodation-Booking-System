using TravelAndAccommodationBookingPlatform.Domain.Models;

namespace TravelAndAccommodationBookingPlatform.Domain.IRepository;

public interface ICityRepository
{
    IQueryable<City> GetCityByName(string cityName);
}