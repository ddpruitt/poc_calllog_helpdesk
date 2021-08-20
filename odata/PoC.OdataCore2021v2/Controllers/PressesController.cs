using PoC.OdataCore2021v2.Models;

namespace PoC.OdataCore2021v2.Controllers
{
    public class PressesController : BaseController<Press>
    {
        public PressesController(BookStoreContext context) : base(context)
        {
            
        }
    }
}