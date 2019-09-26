using Microsoft.AspNetCore.Mvc;
using App.Service.Web.Model;
using System;
using App.Service.Web.DataAccess;
using App.Service.Web.Entitie;

namespace App.Service.Web.Controllers
{
    /// <summary>
    /// Login API
    /// </summary>
    public class BookController : Controller
    {
       

        /// <summary>
        /// Create Book
        /// </summary>
        [HttpPost("/Book/Create")]
        public IActionResult Post([FromBody]BookModel model)
        {
            var user = Facade.Instance.Factory<BookEntitie>()
            .Get(x=> x.prestador.Equals(model.loginUser) && x.senha == model.password);

            if (user == null){
                throw new Exception("Usuário/Senha incorretos!");
            }

            return Json(user);
        }

        /// <summary>
        /// Get Book
        /// </summary>
        [HttpGet("/Login/GetBook")]
        public IActionResult Get(string isbn)
        {
            try
            {
                var book = Facade.Instance.Factory<BookEntitie>().Get(x=> x.ISBN.Equals(isbn));

                if (book == null){
                    throw new Exception("Nenhum clinica para o prestador!");
                }

                return JsonResult(book);
            }
            catch(Exception ex)
            {

            }
        }

        /// <summary>
        /// Get Book
        /// </summary>
        [HttpGet("/Login/GetBooks")]
        public IActionResult Get()
        {
            var books = Facade.Instance.Factory<BookEntitie>().Get();

            if (books.Count == 0){
                throw new Exception("Nenhuma clinica para o prestador!");
            }

            return Json(books);
        }
    }
}
