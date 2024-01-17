using CustomerWebAPI.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/* Database Context Dependency Injection */
var dbHost = "localhost";
var dbName = "dms_customer";
var connectionString = $"Data Source={dbHost};Initial Catalog={dbName};Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";
builder.Services.AddDbContext<CustomerDBContext>(opt => opt.UseSqlServer(connectionString));


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
