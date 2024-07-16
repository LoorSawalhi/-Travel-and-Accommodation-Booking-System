using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;
using TravelAndAccommodationBookingPlatform.Db.Data;
using TravelAndAccommodationBookingPlatform.Db.Mappers;
using TravelAndAccommodationBookingPlatform.Domain.IRepository;
using TravelAndAccommodationBookingPlatform.Domain.Models;

namespace TravelAndAccommodationBookingPlatform.Db.Repositories;

public class RoomRepository(HotelsBookingSystemContext context, ISieveProcessor sieveProcessor, RoomMapper roomMapper)
    : IRoomRepository
{
    public async Task<IEnumerable<Room>> GetAllRooms(SieveModel sieveModel)
    {
        var result = await sieveProcessor.Apply(sieveModel, context.Rooms)
            .ToListAsync();

        return result.Select(roomMapper.MapFromDbToDomain);
    }
}