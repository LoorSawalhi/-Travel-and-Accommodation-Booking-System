using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using TravelAndAccommodationBookingPlatform.API.DTOs;
using TravelAndAccommodationBookingPlatform.API.Mappers;
using TravelAndAccommodationBookingPlatform.Domain.Exceptions;
using TravelAndAccommodationBookingPlatform.Domain.IServices;
using TravelAndAccommodationBookingPlatform.Domain.Models;

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
    
    /// <summary>
    /// List hotel details by its name
    /// </summary>
    /// <response code="200"/>Returns details of hotel/response>
    //
    [HttpGet("{hotelName}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<HotelDto>> ListHotelDetails(string hotelName)
    {
        try
        {
            var details = await hotelService.FindHotelsByNameAsync(hotelName);
            var apiDetails = hotelMapper.MapFromDomainToAPI(details);
            return Ok(apiDetails);
        }
        catch (HotelNotFound ex)
        {
            return NotFound(ex.Message);
        }
  
        
    }
}