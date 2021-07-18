using System;
using Convey.CQRS.Queries;
using Services.Localisation.Application.DTO;

namespace Services.Localisation.Application.Queries
{
    public class GetLocation : IQuery<LocationDto>
    {
        public Guid LocationId { get; set; }
    }
}