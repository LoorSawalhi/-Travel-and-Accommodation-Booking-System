using Sieve.Attributes;

namespace TravelAndAccommodationBookingPlatform.Db.Models;

public partial class City
{
    public int Id { get; set; }

    [Sieve(CanFilter = true, CanSort = true)]
    public string Name { get; set; }
    
    public string PostOffice { get; set; }

    public ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();
}
