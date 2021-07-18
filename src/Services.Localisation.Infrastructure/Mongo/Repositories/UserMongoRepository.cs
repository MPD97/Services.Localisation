using System;
using System.Threading.Tasks;
using Convey.Persistence.MongoDB;
using Services.Localisation.Core.Entities;
using Services.Localisation.Core.Repositories;
using Services.Localisation.Infrastructure.Mongo.Documents;

namespace Services.Localisation.Infrastructure.Mongo.Repositories
{
    public class UserMongoRepository : IUserRepository
    {
        private readonly IMongoRepository<UserDocument, Guid> _repository;

        public UserMongoRepository(IMongoRepository<UserDocument, Guid> repository)
        {
            _repository = repository;
        }

        public Task<bool> ExistsAsync(Guid id)
            => _repository.ExistsAsync(c => c.Id == id);

        public Task AddAsync(User user) 
            => _repository.AddAsync(user.AsDocument());
    }
}