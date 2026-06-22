using Microsoft.EntityFrameworkCore;
using testapirest.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContaxt>(op =>
    op.UseSqlServer(builder.Configuration.GetConnectionString("mycon")));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
