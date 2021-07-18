using System;
using System.Collections.Generic;
using Convey.Logging.CQRS;
using Services.Localisation.Application.Commands;
using Services.Localisation.Application.Events.External;
using Services.Localisation.Application.Exceptions;

namespace Services.Localisation.Infrastructure.Logging
{
    internal sealed class MessageToLogTemplateMapper : IMessageToLogTemplateMapper
    {
        private static IReadOnlyDictionary<Type, HandlerLogTemplate> MessageTemplates 
            => new Dictionary<Type, HandlerLogTemplate>
            {
                {
                    typeof(AddLocation),     
                    new HandlerLogTemplate
                    {
                        After = "Added a location with id: {LocationId} the users: {UserId}"
                    }
                },
                {
                    typeof(UserCreated),     
                    new HandlerLogTemplate
                    {
                        After = "Added a user with id: {UserId}.",
                        OnError = new Dictionary<Type, string>
                        {
                            {
                                typeof(UserAlreadyExistsException), "User with id: {UserId} already exists."
                            }
                        }
                    }
                }
            };
        
        public HandlerLogTemplate Map<TMessage>(TMessage message) where TMessage : class
        {
            var key = message.GetType();
            return MessageTemplates.TryGetValue(key, out var template) ? template : null;
        }
    }
}