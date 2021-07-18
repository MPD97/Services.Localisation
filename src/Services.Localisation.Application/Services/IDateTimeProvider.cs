using System;

namespace Services.Localisation.Application.Services
{
    public interface IDateTimeProvider
    {
        DateTime Now { get; }
    }
}