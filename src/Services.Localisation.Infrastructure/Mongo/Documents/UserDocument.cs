using System;
using Convey.Types;
using Services.Localisation.Core.Entities;

namespace Services.Localisation.Infrastructure.Mongo.Documents
{
    public class UserDocument: IIdentifiable<Guid>
    {
        public Guid Id { get; set; }  
        
        public State State { get; set; }
    }
}