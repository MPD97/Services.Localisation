using System;

namespace Services.Localisation.Core.Exceptions
{
    public class InvalidAccuracyException : DomainException
    {
        public override string Code { get; } = "invalid_accuracy";
        
        public decimal Accuracy { get; }
        public Guid UserId { get; }

        public InvalidAccuracyException(Guid userId, decimal accuracy) 
            : base($"Location for user: {userId} has invalid accuracy: {accuracy}.")
        {
            UserId = userId;
            Accuracy = accuracy;
        }
    }
}