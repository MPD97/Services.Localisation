using System;
using Services.Localisation.Core.Exceptions;

namespace Services.Localisation.Core.Entities
{
    public class Location
    {
        public Guid Id { get; private set; }  
        public Guid UserId { get; private set; }  
        public DateTime CreatedAt { get; private set; }
        public decimal Latitude { get; private set; }
        public decimal Longitude { get; private set; }

        public Location(Guid id, Guid userId, DateTime createdAt, decimal latitude, decimal longitude)
        {
            Id = id;
            UserId = userId;
            CreatedAt = createdAt;
            Latitude = IsValidLatitude(latitude) ? latitude : throw new InvalidLatitudeException(userId, latitude);
            Longitude = IsValidLongitude(longitude) ? longitude : throw new InvalidLongitudeException(userId, longitude);
        }

        public bool IsValidLatitude(decimal latitude)
        {
            return latitude is >= -90m and <= 90m;
        } 
        
        public bool IsValidLongitude(decimal longitude)
        {
            return longitude is >= -180m and <= 180m;
        } 
    }
}