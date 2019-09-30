using Microsoft.AspNetCore.Mvc;
using App.Service.Web.Model;
using System;
using App.Service.Web.DataAccess;
using App.Service.Web.Entitie;
using Newtonsoft.Json;

namespace App.Service.Web.Controllers
{
    /// <summary>
    /// Login API
    /// </summary>
    public class BookController : ControllerBase
    {
        /// <summary>
        /// Create Book
        /// </summary>
        [HttpPost("/Book/Create")]
        public IActionResult Post([FromBody]BookModel model)
        {
            try
            {
                Facade.Instance.Factory<BookEntitie>().Insert(new BookEntitie(){
                    Active = true,
                    ISBN = model.ISBN,
                    Author = model.Author,
                    ReleaseDate = model.ReleaseDate,
                    Title = model.Title
                });

                return Ok(new { success = true, message = string.Empty });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, data = new { }, message = ex.Message });
            }
        }

        /// <summary>
        /// Get Book
        /// </summary>
        [HttpGet("/Book/GetBook")]
        public IActionResult Get(string isbn)
        {
            try
            {
                var book = Facade.Instance.Factory<BookEntitie>().Get(x=> x.ISBN.Equals(isbn));

                if (book == null){
                    throw new Exception("No Books Found!");
                }

                return Ok(new { success = true, data = book, message = string.Empty });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, data = new { }, message = ex.Message });
            }
        }

        /// <summary>
        /// Get Book
        /// </summary>
        [HttpGet("/Book/GetBooks")]
        public IActionResult GetAll()
        {
            try
            {
                var books = Facade.Instance.Factory<BookEntitie>().GetAll();

                if (books == null){
                    throw new Exception("No Books Found!");
                }

                return Ok(new { success = true, data = books, message = string.Empty });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, data = new { }, message = ex.Message });
            }
        }
    }
}
