using Lil.Search.Interfaces;
using Lil.Search.Services;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//public IConfiguration Configuration { get; }

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ICostumersService, CustomersService>();
builder.Services.AddSingleton<IProductsService, ProductsServices>();
builder.Services.AddSingleton<ISalesService, SalesService>();

builder.Services.AddHttpClient("customersService", c =>
{
    c.BaseAddress = new Uri("http://localhost:5000");//ConfigurationPath.GetParentPath("Services:CustomersService"));
}
);
builder.Services.AddHttpClient("productsService", c =>
{
    c.BaseAddress = new Uri("http://localhost:5100");//Uri(ConfigurationPath.GetParentPath("Services:ProductsServices"));
}
);
builder.Services.AddHttpClient("salesService", c =>
{
    c.BaseAddress = new Uri("http://localhost:5200");//Uri(ConfigurationPath.GetParentPath("Services:SalesService"));
}
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
