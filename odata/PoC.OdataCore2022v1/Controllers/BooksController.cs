using PoC.OdataCore.Data;
using PoC.OdataCore.Data.Models;

namespace PoC.OdataCore2022v1.Controllers
{
    public class BooksController : BaseController<Book>
    {
        public BooksController(BookStoreContext context) : base(context)
        {
            
        }
    }

}