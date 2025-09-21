using API.Endpoints;
using Application.Services;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using MassTransit;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<ToDoDbContext>(
    options => options.UseInMemoryDatabase(builder.Configuration.GetConnectionString("ToDoListDb")!));
builder.Services.AddMassTransit(x => x.UsingRabbitMq());
builder.Services.AddScoped<IToDoRepository, ToDoRepository>();
builder.Services.AddScoped<ToDoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapToDoEndpoints();

app.Run();
