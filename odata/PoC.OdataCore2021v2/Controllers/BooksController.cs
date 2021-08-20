using PoC.OdataCore2021v2.Models;

namespace PoC.OdataCore2021v2.Controllers
{
    public class BooksController : BaseController<Book>
    {
        public BooksController(BookStoreContext context) : base(context)
        {
            
        }
    }

}