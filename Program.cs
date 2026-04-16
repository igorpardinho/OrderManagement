using Mapster;
using OrderManagement.Data;
using OrderManagement.Domain.Interfaces;
using OrderManagement.Infrastructure.Repository;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddMapster();

var app = builder.Build();
app.MapControllers();
app.Run();