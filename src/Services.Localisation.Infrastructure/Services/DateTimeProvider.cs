using System;
using Services.Localisation.Application.Services;

namespace Services.Localisation.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Now  => DateTime.UtcNow;
    }
}