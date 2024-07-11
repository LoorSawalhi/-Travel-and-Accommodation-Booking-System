using Microsoft.EntityFrameworkCore;
using TravelAndAccommodationBookingPlatform.API.Mappers;
using TravelAndAccommodationBookingPlatform.Db.Data;
using TravelAndAccommodationBookingPlatform.Db.Repositories;
using TravelAndAccommodationBookingPlatform.Domain.IRepository;
using TravelAndAccommodationBookingPlatform.Domain.IServices;
using TravelAndAccommodationBookingPlatform.Domain.Services;

namespace TravelAndAccommodationBookingPlatform.API;

public static class ServiceConfiguration
{
    public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<HotelsBookingSystemContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        return services;
    }

    public static IServiceCollection AddValidators(this IServiceCollection services)
    {

        return services;
    }
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddScoped<IHotelService, HotelService>();
        services.AddScoped<IRoomService, RoomService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IReservationService, ReservationService>();
        services.AddScoped<ICityService, CityService>();
        
        return services;
    }
    
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IHotelRepository, HotelRepository>();
        services.AddScoped<IRoomRepository, RoomRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IReservationRepository, ReservationRepository>();
        services.AddScoped<ICityRepository, CityRepository>();
        return services;
    }
    
    public static IServiceCollection AddApiMappers(this IServiceCollection services)
    {
        services.AddScoped<HotelMapper>();
        services.AddScoped<CityMapper>();
        services.AddScoped<ReservationMapper>();
        services.AddScoped<UserMapper>();
        services.AddScoped<RoomMapper>();

        return services;
    }
    
    public static IServiceCollection AddDbMappers(this IServiceCollection services)
    {
        services.AddScoped<Db.Mappers.HotelMapper>();
        services.AddScoped<Db.Mappers.CityMapper>();
        services.AddScoped<Db.Mappers.ReservationMapper>();
        services.AddScoped<Db.Mappers.RoomMapper>();
        services.AddScoped<Db.Mappers.UserMapper>();

        return services;
    }
}