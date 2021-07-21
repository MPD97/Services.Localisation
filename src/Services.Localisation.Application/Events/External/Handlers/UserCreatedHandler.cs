using System.Threading.Tasks;
using Convey.CQRS.Events;
using Services.Localisation.Application.Exceptions;
using Services.Localisation.Core.Entities;
using Services.Localisation.Core.Repositories;

namespace Services.Localisation.Application.Events.External.Handlers
{
    public class UserCreatedHandler: IEventHandler<UserCreated>
    {
        private readonly IUserRepository _userRepository;

        public UserCreatedHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task HandleAsync(UserCreated @event)
        {
            if (await _userRepository.ExistsAsync(@event.UserId))
            {
                throw new UserAlreadyExistsException(@event.UserId);
            }

            await _userRepository.AddAsync(new User(@event.UserId, @event.State));
        }
    }
}