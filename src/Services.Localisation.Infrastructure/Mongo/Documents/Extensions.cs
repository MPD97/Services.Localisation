using Services.Localisation.Application.DTO;
using Services.Localisation.Core.Entities;

namespace Services.Localisation.Infrastructure.Mongo.Documents
{
    public static class Extensions
    {
        public static Location AsEntity(this LocationDocument document)
            => new Location(document.Id, document.UserId, document.CreatedAt, document.Latitude, document.Longitude, document.Accuracy);

        public static LocationDocument AsDocument(this Location entity)
            => new LocationDocument
            {
                Id = entity.Id,
                UserId = entity.UserId,
                CreatedAt = entity.CreatedAt,
                Longitude = entity.Longitude,
                Latitude = entity.Latitude,
                Accuracy = entity.Accuracy
            };

        public static LocationDto AsDto(this LocationDocument document)
            => new LocationDto
            {
                Id = document.Id,
                UserId = document.UserId,
                CreatedAt = document.CreatedAt,
                Longitude = document.Longitude,
                Latitude = document.Latitude,
                Accuracy = document.Accuracy
            };

        public static User AsEntity(this UserDocument document)
            => new User(document.Id);

        public static UserDocument AsDocument(this User entity)
            => new UserDocument
            {
                Id = entity.Id
            };
    }
}