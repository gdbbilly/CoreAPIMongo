using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace App.Service.Web.Entitie
{
    public abstract class BaseEntitie
    {
        [BsonId]
        internal ObjectId _id { get; set; }

    }
}