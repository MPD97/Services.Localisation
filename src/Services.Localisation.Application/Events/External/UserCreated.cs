using System;
using Convey.CQRS.Events;
using Convey.MessageBrokers;

namespace Services.Localisation.Application.Events.External
{
    [Message("users")]
    public class UserCreated: IEvent
    {
        public Guid UserId { get; }

        public UserCreated(Guid userId)
        {
            UserId = userId;
        }
    }
}