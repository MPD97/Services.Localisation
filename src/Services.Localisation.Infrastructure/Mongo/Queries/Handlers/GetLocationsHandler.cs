using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Convey.CQRS.Queries;
using Convey.Persistence.MongoDB;
using MongoDB.Driver;
using Services.Localisation.Application.DTO;
using Services.Localisation.Application.Queries;
using Services.Localisation.Infrastructure.Mongo.Documents;

namespace Services.Localisation.Infrastructure.Mongo.Queries.Handlers
{
    public class GetLocationsHandler : IQueryHandler<GetLocations, IEnumerable<LocationDto>>
    {
        private readonly IMongoRepository<LocationDocument, Guid> _locationRepository;

        public GetLocationsHandler(IMongoRepository<LocationDocument, Guid> locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<IEnumerable<LocationDto>> HandleAsync(GetLocations query)
        {
            var documents = _locationRepository.Collection.AsQueryable();
   
            var locations = await documents.ToListAsync();

            return locations.Select(p => Documents.Extensions.AsDto((LocationDocument) p));        
        }
    }
}