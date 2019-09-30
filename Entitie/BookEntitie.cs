using System;

namespace App.Service.Web.Entitie
{
    public class BookEntitie : BaseEntitie
    {
        public BookEntitie()
        {
            Active = true;
        }

        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool Active {get;set;}
    }
}