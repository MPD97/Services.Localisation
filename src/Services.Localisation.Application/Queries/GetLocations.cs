using System;
using System.Collections.Generic;
using Convey.CQRS.Queries;
using Services.Localisation.Application.DTO;

namespace Services.Localisation.Application.Queries
{
    public class GetLocations : IQuery<IEnumerable<LocationDto>>
    {
        public Guid? UserId { get; set; }
    }
}