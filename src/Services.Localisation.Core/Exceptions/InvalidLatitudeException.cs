using System;

namespace Services.Localisation.Core.Exceptions
{
    public class InvalidLatitudeException : DomainException
    {
        public override string Code { get; } = "invalid_latitude";
        
        public decimal Latitude { get; }
        public Guid UserId { get; }

        public InvalidLatitudeException(Guid userId, decimal latitude) 
            : base($"Location for user: {userId} has invalid latitude: {latitude}.")
        {
        }
    }
}