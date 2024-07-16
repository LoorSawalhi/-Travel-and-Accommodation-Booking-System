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
[Route("/api/{version:apiVersion}/hotels")]
[ApiVersion("1")]
public class HotelsController(IHotelService hotelService, HotelMapper hotelMapper) : ControllerBase
{
    /// <summary>
    /// Search on hotels
    /// </summary>
    /// <response code="200">Returns matched hotels based on query</response>
    //
    [HttpGet("search")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<HotelDto>> SearchHotel([FromQuery] SieveModel sieveModel)
    {
        var models = await hotelService.FindHotelsAsync(sieveModel);
        var hotels = models.Select(hotelMapper.MapFromDomainToAPI);
        return Ok(hotels);
    }
}