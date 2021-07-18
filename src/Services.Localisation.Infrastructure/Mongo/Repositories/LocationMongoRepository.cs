using System;
using System.Threading.Tasks;
using Convey.Persistence.MongoDB;
using Services.Localisation.Core.Entities;
using Services.Localisation.Core.Repositories;
using Services.Localisation.Infrastructure.Mongo.Documents;

namespace Services.Localisation.Infrastructure.Mongo.Repositories
{
    public class LocationMongoRepository : ILocationRepository
    {
        private readonly IMongoRepository<LocationDocument, Guid> _repository;

        public LocationMongoRepository(IMongoRepository<LocationDocument, Guid> repository)
        {
            _repository = repository;
        }
        
        public async Task<Location> GetAsync(Guid id)
        {
            var document = await _repository.GetAsync(l => l.Id == id);

            return document?.AsEntity();
        }
        
        public async Task<Location> GetByUserAsync(Guid userId)
        {
            var document = await _repository.GetAsync(l => l.UserId == userId);

            return document?.AsEntity();
        }
        
        public Task AddAsync(Location location) =>
            _repository.AddAsync(location.AsDocument());
    }
}