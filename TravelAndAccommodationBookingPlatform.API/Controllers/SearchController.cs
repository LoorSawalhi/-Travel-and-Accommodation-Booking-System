using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using TravelAndAccommodationBookingPlatform.API.DTOs;
using TravelAndAccommodationBookingPlatform.API.Mappers;
using TravelAndAccommodationBookingPlatform.Domain.IServices;
using TravelAndAccommodationBookingPlatform.Domain.Services;

namespace TravelAndAccommodationBookingPlatform.API.Controllers;

/// <summary>
/// Search controller over hotels,
/// will return hotels with matched parameters
/// </summary>
[ApiController]
[Route("/api/{version:apiVersion}/search")]
[ApiVersion("1")]
public class SearchController(IHotelService hotelService, ICityService cityService,
    HotelMapper hotelMapper, CityMapper cityMapper) : ControllerBase
{
    /// <summary>
    /// Search on hotels
    /// </summary>
    /// <response code="200">Returns matched hotels based on query</response>
    //
    [HttpGet("/hotels")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<HotelDto>> SearchHotel([FromQuery] SieveModel sieveModel)
    {
        var models = await hotelService.FindHotelsAsync(sieveModel);
        var hotels = models.Select(hotelMapper.MapFromDomainToAPI);
        return Ok(hotels);
    }
    
    /// <summary>
    /// Search on cities
    /// </summary>
    /// <response code="200">Returns matched cities based on query</response>
    //
    [HttpGet("/cities")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<HotelDto>> SearchCities([FromQuery] SieveModel sieveModel)
    {
        var models = await cityService.FindCitiesAsync(sieveModel);
        var cities = models.Select(cityMapper.MapFromDomainToApi);
        return Ok(cities);
    }
}