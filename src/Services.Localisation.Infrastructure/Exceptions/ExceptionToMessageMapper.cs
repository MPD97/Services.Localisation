using System;
using Convey.MessageBrokers.RabbitMQ;
using Services.Localisation.Application.Events.Rejected;
using Services.Localisation.Core.Exceptions;

namespace Services.Localisation.Infrastructure.Exceptions
{
    public class ExceptionToMessageMapper : IExceptionToMessageMapper
    {
        public object Map(Exception exception, object message)
            => exception switch
            {
                UserNotFoundException ex => new AddLocationRejected(ex.Message, ex.Code),
                InvalidAccuracyException ex => new AddLocationRejected(ex.Message, ex.Code),
                InvalidLatitudeException ex => new AddLocationRejected(ex.Message, ex.Code),
                InvalidLongitudeException ex => new AddLocationRejected(ex.Message, ex.Code),
            };
    }
}