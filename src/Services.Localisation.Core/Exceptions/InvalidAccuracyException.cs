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
        }
    }
    public class UserNotFoundException : DomainException
    {
        public override string Code { get; } = "user_not_found";
        public Guid UserId { get; }
        public UserNotFoundException(Guid userId) : base($"User with id: {userId} was not found.")
        {
            UserId = userId;
        }
    }
}