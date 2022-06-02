using Microsoft.AspNetCore.OData;
using PoC.OdataCore.Data;
using Microsoft.EntityFrameworkCore;

using PoC.OdataCore2022v1;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddOData(opt =>
{
    opt.Select().Expand().Filter().OrderBy().SetMaxTop(100).Count();
    opt.AddRouteComponents("odata", BookStoreModelBuilder.GetEdmModel());
});

builder.Services.AddDbContext<BookStoreContext>(opt => 
    opt.UseInMemoryDatabase("BookLists"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo {Title = "PoC.OdataCore2022v1", Version = "v1"});
    }
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();

