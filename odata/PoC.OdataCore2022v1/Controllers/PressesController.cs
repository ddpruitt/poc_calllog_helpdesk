using PoC.OdataCore.Data;
using PoC.OdataCore.Data.Models;

namespace PoC.OdataCore2022v1.Controllers
{
    public class PressesController : BaseController<Press>
    {
        public PressesController(BookStoreContext context) : base(context)
        {
            
        }
    }
}