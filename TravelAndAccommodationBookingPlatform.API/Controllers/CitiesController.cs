using Microsoft.AspNetCore.Mvc;
using TravelAndAccommodationBookingPlatform.API.DTOs;
using TravelAndAccommodationBookingPlatform.API.Mappers;
using TravelAndAccommodationBookingPlatform.Domain.IServices;

namespace TravelAndAccommodationBookingPlatform.API.Controllers;

public class CitiesController : ControllerBase
{
    private readonly ICityService _cityService;
    private readonly CityMapper _mapper;

    public CitiesController(ICityService cityService, CityMapper mapper)
    {
        _cityService = cityService;
        _mapper = mapper;
    }
    
    /// <summary>
    /// Get city by name
    /// </summary>
    /// <response code="200">Returns city by name</response>
    [HttpGet("{name}", Name = "Get all cities")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<CityDto> GetCityByName(string name)
    {
        // using var scope = _logger.BeginScope(new
        // {
        //     Class = "soso",
        // });
        //
        var city = _cityService.FindCityByName(name)
            .Select(c => _mapper.MapFromDbToDomain(c));
        return Ok(city);
    }
    
}