using System;
using System.Drawing;
using System.Threading.Tasks;
using Convey.CQRS.Commands;
using Services.Localisation.Application.Events;
using Services.Localisation.Application.Services;
using Services.Localisation.Core.Entities;
using Services.Localisation.Core.Exceptions;
using Services.Localisation.Core.Repositories;

namespace Services.Localisation.Application.Commands.Handlers
{
    public class AddLocationHandler: ICommandHandler<AddLocation>
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMessageBroker _messageBroker;
        private readonly IDateTimeProvider _dateTimeProvider;

        public AddLocationHandler(ILocationRepository locationRepository, IUserRepository userRepository,
            IMessageBroker messageBroker, IDateTimeProvider dateTimeProvider)
        {
            _locationRepository = locationRepository;
            _userRepository = userRepository;
            _messageBroker = messageBroker;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task HandleAsync(AddLocation command)
        {
            if (!(await _userRepository.ExistsAsync(command.UserId)))
            {
                throw new UserNotFoundException(command.UserId);
            }

            var location = new Location(command.LocationId, command.UserId, _dateTimeProvider.Now, command.Latitude,
                command.Longitude, command.Accuracy);
            
            await _locationRepository.AddAsync(location);
            await _messageBroker.PublishAsync(new LocationAdded(location.Id, location.UserId,
                location.CreatedAt, location.Latitude, location.Longitude, location.Accuracy));
        }
    }
}