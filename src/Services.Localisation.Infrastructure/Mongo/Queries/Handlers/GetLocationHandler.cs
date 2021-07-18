using System;
using System.Threading.Tasks;
using Convey.CQRS.Queries;
using Convey.Persistence.MongoDB;
using MongoDB.Driver.Linq;
using Services.Localisation.Application;
using Services.Localisation.Application.DTO;
using Services.Localisation.Application.Queries;
using Services.Localisation.Infrastructure.Mongo.Documents;

namespace Services.Localisation.Infrastructure.Mongo.Queries.Handlers
{
    public class GetLocationHandler: IQueryHandler<GetLocation, LocationDto>
    {
        private readonly IMongoRepository<LocationDocument, Guid> _locationRepository;

        public GetLocationHandler(IMongoRepository<LocationDocument, Guid> locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<LocationDto> HandleAsync(GetLocation query)
        {
            var document = await _locationRepository.GetAsync(p => p.Id == query.LocationId);

            return document?.AsDto();
        }
    }
}