using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TravelAndAccommodationBookingPlatform.API.DTOs;
using TravelAndAccommodationBookingPlatform.API.Mappers;
using TravelAndAccommodationBookingPlatform.Domain.IServices;

namespace TravelAndAccommodationBookingPlatform.API.Controllers;

/// <summary>
/// Search controller over hotels,
/// will return hotels with matched parameters
/// </summary>
[ApiController]
[Route("/api/search/hotels")]
[ApiVersion("1")]
public class SearchHotelsController(IHotelService hotelService, HotelMapper mapper) : ControllerBase
{
    /// <summary>
    /// Search hotel by name
    /// </summary>
    /// <response code="200">Returns hotels by name</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<HotelDto>> GetHotelByName([FromQuery] string? name)
    {
        // using var scope = _logger.BeginScope(new
        // {
        //     Class = "soso",
        // });
        //
        if (name.IsNullOrEmpty())
            name = "";
        
        var hotels = await hotelService.FindHotelsByNameAsync(name);
        if (hotels.IsNullOrEmpty())
            return NoContent();
        var hotelDto = hotels.Select(mapper.MapFromDomainToAPI);
        return Ok(hotelDto);
    }
}