using System;

namespace Services.Localisation.Core.Exceptions
{
    public class InvalidLongitudeException : DomainException
    {
        public override string Code { get; } = "invalid_longitude";
        
        public decimal Longitude { get; }
        public Guid UserId { get; }

        public InvalidLongitudeException(Guid userId, decimal longitude) 
            : base($"Location for user: {userId} has invalid longitude: {longitude}.")
        {
        }
    }
}