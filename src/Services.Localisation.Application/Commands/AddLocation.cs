using System;
using Convey.CQRS.Commands;

namespace Services.Localisation.Application.Commands
{
    [Contract]
    public class AddLocation : ICommand
    {
        public Guid LocationId { get; }  
        public Guid UserId { get; }  
        public decimal Latitude { get; }
        public decimal Longitude { get; }
        public int  Accuracy { get; }

        public AddLocation(Guid locationId, Guid userId, decimal latitude, decimal longitude, int accuracy)
        {
            LocationId = locationId == Guid.Empty ? Guid.NewGuid() : locationId;
            UserId = userId;
            Latitude = latitude;
            Longitude = longitude;
            Accuracy = accuracy;
        }
    }
}