using App.Service.Web.Entitie;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace App.Service.Web.DataAccess
{
    public class Repository<T>
    {
        protected IMongoCollection<T> _collection;

        public Repository(string collectionName)
        {
            _collection = DbClient.Database.GetCollection<T>(collectionName);
            if (_collection == null)
            {
                DbClient.Database.CreateCollection(collectionName);
                _collection = DbClient.Database.GetCollection<T>(collectionName);
            }
        }

        public T Get(ObjectId id)
        {
            return _collection.Find(Builders<T>.Filter.AnyEq("Id", id)).FirstOrDefault();
        }

        public T Get(Expression<Func<T, bool>> query)
        {
            return _collection.Find<T>(query).FirstOrDefault();
        }

        public IList<T> FindAll()
        {
            return _collection.Find(Builders<T>.Filter.Empty).ToList();
        }

        public IList<T> Find(Expression<Func<T, bool>> query)
        {
            return _collection.Find(query).ToList();
        }

        public bool Exists(ObjectId id)
        {
            return _collection.Find(Builders<T>.Filter.AnyEq("Id", id)).Count() > 0;
        }

        public bool Exists(Expression<Func<T, bool>> query)
        {
            return _collection.Find(query).Count() > 0;
        }

        public long Count()
        {
            return _collection.Count(Builders<T>.Filter.Empty);
        }

        public long Count(Expression<Func<T, bool>> query)
        {
            return _collection.Find(query).Count();
        }

        public virtual void Insert(T document)
        {
            _collection.InsertOne(document);
        }

        public virtual void Insert(T document, InsertOneOptions updateOptions)
        {
            _collection.InsertOne(document);
        }

        public void Update(ObjectId id, T obj, UpdateOptions updateOptions)
        {
            _collection.ReplaceOne(Builders<T>.Filter.AnyEq("Id", id), obj, updateOptions );
        }

        public void Delete(ObjectId id)
        {
            _collection.DeleteOne(Builders<T>.Filter.AnyEq("Id", id));
        }
    }
}
