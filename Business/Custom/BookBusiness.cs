using App.Service.Web.DataAccess;
using App.Service.Web.Entitie;
using MongoDB.Bson;
using MongoDB.Driver;

namespace App.Service.Web.Business
{
    public class BookBusiness : CustomBusiness<BookBusiness, BookEntitie>
    {
        public override void Insert(BookEntitie pObject)
        {
            if (!_factory.Instance.Exists(x => x.prestador == pObject.prestador && 
                                    x.codigo == pObject.codigo))
                _factory.Instance.Insert(pObject);
        }

        public void Update(BookEntitie obj)
        {
            if(obj._id == ObjectId.Empty)
             {
                 obj._id = ObjectId.GenerateNewId();
             }
            _factory.Instance.Update(obj._id, obj, new UpdateOptions() { IsUpsert = true } );

        }
    }
}
