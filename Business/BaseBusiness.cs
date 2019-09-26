using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using App.Service.Web.DataAccess;
using MongoDB.Bson;
using MongoDB.Driver;

namespace App.Service.Web.Business
{
    public class BaseBusiness<U> : IEntitieBehaviour<U>
    {
        internal FactoryDatabase<U> _factory { get; set; }

        public BaseBusiness()
        {
            _factory = new FactoryDatabase<U>();
        }

        public virtual long Count()
        {
             return _factory.Instance.Count();
        }

        public virtual long Count(Expression<Func<U, bool>> query)
        {
            return _factory.Instance.Count(query);
        }

        public virtual void Delete(ObjectId id)
        {
            _factory.Instance.Delete(id);
        }

        public virtual bool Exists(ObjectId id)
        {
            return _factory.Instance.Exists(id);
        }

        public virtual bool Exists(Expression<Func<U, bool>> query)
        {
            return _factory.Instance.Exists(query);
        }

        public virtual U Get(ObjectId id)
        {
            return _factory.Instance.Get(id);
        }

        public virtual U Get(Expression<Func<U, bool>> query)
        {
           return _factory.Instance.Get(query);
        }

        public virtual IList<U> GetAll()
        {
           return _factory.Instance.FindAll();
        }

        public virtual IList<U> GetAll(Expression<Func<U, bool>> query)
        {
            return _factory.Instance.Find(query);
        }

        public virtual void Insert(U obj)
        {
            _factory.Instance.Insert(obj);
        }

        public void Insert(U obj, InsertOneOptions updateOptions)
        {
            _factory.Instance.Insert(obj, updateOptions);
        }

        public virtual void Update(ObjectId id, U obj)
        {
           this.Update(id, obj, new UpdateOptions() { IsUpsert = true });
        }

        public virtual void Update(ObjectId id, U obj, UpdateOptions opt)
        {
           _factory.Instance.Update(id, obj, opt);
        }

       
    }
}
