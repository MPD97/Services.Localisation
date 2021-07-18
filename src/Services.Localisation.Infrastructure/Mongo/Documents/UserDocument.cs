using System;
using Convey.Types;

namespace Services.Localisation.Infrastructure.Mongo.Documents
{
    public class UserDocument: IIdentifiable<Guid>
    {
        public Guid Id { get; set; }  
    }
}