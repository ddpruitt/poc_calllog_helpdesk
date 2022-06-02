using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using PoC.OdataCore.Data.Models;

namespace PoC.OdataCore2022v1;

public static class BookStoreModelBuilder
{
    public static IEdmModel GetEdmModel()
    {
        var builder = new ODataConventionModelBuilder();
        builder.EntitySet<Book>("Books");
        builder.EntitySet<Press>("Presses");
        return builder.GetEdmModel();
    }
}