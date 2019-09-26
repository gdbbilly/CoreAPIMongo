using MongoDB.Bson.Serialization;

namespace App.Service.Web.DataAccess
{
    public abstract class MongoDBClassMap<T>
    {
        protected MongoDBClassMap()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(T)))
                BsonClassMap.RegisterClassMap<T>(Map);
        }

        public abstract void Map(BsonClassMap<T> cm);
    }
}
