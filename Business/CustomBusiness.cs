using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using App.Service.Web.DataAccess;
using MongoDB.Bson;

namespace App.Service.Web.Business
{
    public class CustomBusiness<T, U> : BaseBusiness<U>
    {
    }
}
