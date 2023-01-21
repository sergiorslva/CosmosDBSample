using AzureCosmosDotNet.Services;
using AzureCosmosDotNet.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ICosmoDBService, CosmoDbService>();
builder.Services.AddScoped<ICustomerDbService, CustomerDbService>();
builder.Services.AddScoped<IProductCategoryDbService, ProductCategoryDbService>();
builder.Services.AddScoped<IOrderDbService, OrderDbService>();

builder.Services.AddControllers();
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
