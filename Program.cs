using SportSpaceDataAccessLayer.Models;
using SportSpaceBussinesLayer.Repository;
using SportSpaceDataAccessLayer.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddScoped<OwnerModel>();
builder.Services.AddOpenApi();
builder.Services.AddScoped<FieldRepository>();
builder.Services.AddScoped<OwnerRepository>();
builder.Services.AddScoped<Field_ServicesRepository>();
builder.Services.AddScoped<ServiceRepository>();
builder.Services.AddScoped<OffersRepository>();


//builder.Services.AddScoped<OwnerModel>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
  
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
