using System;
using System.Threading.Tasks;
using Services.Localisation.Core.Entities;

namespace Services.Localisation.Core.Repositories
{
    public interface ILocationRepository
    {
        Task<Location> GetAsync(Guid id);
        Task<Location> GetByUserAsync(Guid userId);
        Task AddAsync(Location location);
        Task UpdateAsync(Location location);
        Task DeleteAsync(Guid id);
    }
}