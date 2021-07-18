using System;
using Convey.Types;

namespace Services.Localisation.Infrastructure.Mongo.Documents
{
    public class LocationDocument: IIdentifiable<Guid>
    {
        public Guid Id { get; set; }  
        public Guid UserId { get; set; }  
        public DateTime CreatedAt { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int  Accuracy { get; set; }
    }
}