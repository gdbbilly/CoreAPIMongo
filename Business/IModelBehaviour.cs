using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MongoDB.Bson;
using MongoDB.Driver;

namespace App.Service.Web.Business
{
    public interface IEntitieBehaviour<Data>
    {
        IList<Data> GetAll();
        IList<Data> GetAll(Expression<Func<Data, bool>> query);

        Data Get(ObjectId id);
        Data Get(Expression<Func<Data, bool>> query);

        void Insert(Data obj);

        void Insert(Data document, InsertOneOptions updateOptions);

        void Update(ObjectId id, Data obj);

        void Update(ObjectId id, Data obj, UpdateOptions opt);

        void Delete(ObjectId id);

        bool Exists(ObjectId id);

        bool Exists(Expression<Func<Data, bool>> query);
        long Count();
        long Count(Expression<Func<Data, bool>> query);
    }
}
