using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using TravelAndAccommodationBookingPlatform.API.DTOs;
using TravelAndAccommodationBookingPlatform.API.Mappers;
using TravelAndAccommodationBookingPlatform.Domain.IServices;

namespace TravelAndAccommodationBookingPlatform.API.Controllers;

/// <summary>
/// Search controller over hotels,
/// will return hotels with matched parameters
/// </summary>
[ApiController]
[Route("/api/{version:apiVersion}/search")]
[ApiVersion("1")]
public class SearchController(IHotelService hotelService, ICityService cityService, IRoomService roomService,
    HotelMapper hotelMapper, CityMapper cityMapper, RoomMapper roomMapper) : ControllerBase
{
    /// <summary>
    /// Search on hotels
    /// </summary>
    /// <response code="200">Returns matched hotels based on query</response>
    //
    [HttpGet("hotels")]
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
    [HttpGet("cities")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<HotelDto>> SearchCities([FromQuery] SieveModel sieveModel)
    {
        var models = await cityService.FindCitiesAsync(sieveModel);
        var cities = models.Select(cityMapper.MapFromDomainToApi);
        return Ok(cities);
    }
    
    // /// <summary>
    // /// Search on rooms
    // /// </summary>
    // /// <response code="200">Returns matched rooms based on query</response>
    // //
    // [HttpGet("rooms")]
    // [ProducesResponseType(StatusCodes.Status200OK)]
    // public async Task<ActionResult<RoomDto>> SearchRooms([FromQuery] SieveModel sieveModel)
    // {
    //     var models = await roomService.FindRoomsAsync(sieveModel);
    //     var rooms = models.Select(roomMapper.MapFromDomainToApi);
    //     return Ok(rooms);
    // }
}