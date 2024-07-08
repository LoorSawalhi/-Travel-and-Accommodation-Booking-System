﻿namespace TravelAndAccommodationBookingPlatform.Domain.Models;

public partial class City
{
    public string Name { get; set; }

    public string PostOffice { get; set; }

    public virtual ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();
}
