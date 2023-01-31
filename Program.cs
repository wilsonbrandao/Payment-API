using Microsoft.EntityFrameworkCore;
using Payment_API.Data;
using Payment_API.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});



//database service SQL Server
builder.Services.AddDbContext<PaymentApiContext>
(
    options => options.UseLazyLoadingProxies().UseSqlServer
    (
        builder.Configuration.GetConnectionString("SqlServer")
    )
);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<SellerService, SellerService>();
builder.Services.AddScoped<ProductService, ProductService>();
builder.Services.AddScoped<SaleService, SaleService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
