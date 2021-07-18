using System;
using Services.Localisation.Core.Entities;

namespace Services.Localisation.Application.DTO
{
    public class LocationDto
    {
        public Guid Id { get; set; }  
        public Guid UserId { get; set; }  
        public DateTime CreatedAt { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int  Accuracy { get; set; }

        public LocationDto()
        {
            
        }

        public LocationDto(Location location)
        {
            Id = location.Id;
            UserId = location.UserId;
            CreatedAt = location.CreatedAt;
            Latitude = location.Latitude;
            Longitude = location.Longitude;
            Accuracy = location.Accuracy;
        }
    }
}