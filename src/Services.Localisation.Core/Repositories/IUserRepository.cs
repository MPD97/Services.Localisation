using System;
using System.Threading.Tasks;
using Services.Localisation.Core.Entities;

namespace Services.Localisation.Core.Repositories
{
    public interface IUserRepository
    {
        Task<bool> ExistsAsync(Guid id);
        Task AddAsync(User user);
    }
}