using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using PoC.OdataCore2021v2.Models;
using System.Linq;

namespace PoC.OdataCore2021v2.Controllers
{
    public class BaseController<T> : ODataController where T: class, IEntity
    {
        private BookStoreContext _db;

        public BaseController(BookStoreContext context)
        {
            _db = context;

            // Fake up some data if not any.
            if (!context.Books.Any())
            {
                foreach (var b in DataSource.GetBooks())
                {
                    context.Books.Add(b);
                    context.Presses.Add(b.Press);
                }

                context.SaveChanges();
            }
        }

        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_db.Set<T>());
        }

        [EnableQuery]
        public IActionResult Get(int key)
        {
            return Ok(_db.Set<T>().FirstOrDefault(c => c.Id == key));
        }

        [EnableQuery]
        public IActionResult Post( T entity)
        {
            _db.Set<T>().Add(entity);
            _db.SaveChanges();
            return Created(entity);
        }
    }

    
}