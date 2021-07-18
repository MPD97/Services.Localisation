using System;
using Convey.CQRS.Events;

namespace Services.Localisation.Application.Events
{
    [Contract]
    public class LocationAdded: IEvent
    {
        public Guid LocationId { get; }
        
        public LocationAdded(Guid locationId)
        {
            LocationId = locationId;
        }
    }
}