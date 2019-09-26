using MongoDB.Bson.Serialization.Attributes;
using System;

namespace App.Service.Web.Model
{
    public class BookModel
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}