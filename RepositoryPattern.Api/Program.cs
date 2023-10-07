using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Api.Core.UOW;
using RepositoryPattern.Api.Data;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var config = builder.Configuration;
// Add services to the container.
#region SERVICES

services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

//db
services.AddDbContext<ApiDbContext>(optionsAction: options =>
options.UseSqlite(config.GetConnectionString("DefaultConnection")));

//unit of work
services.AddScoped<IUnitOfWork, UnitOfWork>();

#endregion

var app = builder.Build();

#region APP

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

#endregion

