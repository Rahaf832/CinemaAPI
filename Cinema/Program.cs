using Microsoft.EntityFrameworkCore;
using CinemaAPI.Data;
using AutoMapper;
using CinemaAPI.MiddleWire;
using FluentValidation.AspNetCore;
using CinemaAPI.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program)); 

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers().AddFluentValidation(fv => { fv.RegisterValidatorsFromAssemblyContaining<Program>(); });
builder.Services.AddScoped<IMovieSrevice,MovieSrevice>();

var app = builder.Build();

app.UseMiddleware<HandlingErrors>();
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
