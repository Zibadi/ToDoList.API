using Application.Services;
using Domain.Entities;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints
{
    public static class ToDoEndpoints
    {
        public static void MapToDoEndpoints(this WebApplication app)
        {
            app.MapGet("/api/ToDos", FindAll);
            app.MapGet("/api/ToDos/{id:guid}", FindById);
            app.MapPost("/api/ToDos", Create);
            app.MapPut("/api/ToDos/{id:guid}", Update);
            app.MapDelete("/api/ToDos/{id:guid}", Delete);
        }

        public static async Task<IResult> FindAll(ToDoService service)
        {
            return Results.Ok(await service.FindAll());
        }

        public static async Task<IResult> FindById(ToDoService service, Guid id)
        {
            var todo = await service.FindById(id);
            if (todo is null)
                return Results.NotFound();

            return Results.Ok(todo);
        }

        public static async Task<IResult> Create(ToDoService service, IPublishEndpoint publishEndpoint, [FromBody] ToDo todo)
        {
            await service.Create(todo);
            await publishEndpoint.Publish(todo);
            return Results.Created($"api/ToDos/{todo.Id}", todo);
        }

        public static async Task<IResult> Update(ToDoService service, Guid id, [FromBody] ToDo todo)
        {
            var existingToDo = await service.FindById(id);
            if (existingToDo is null)
                return Results.NotFound();

            await service.Update(existingToDo, todo);
            return Results.NoContent();
        }

        public static async Task<IResult> Delete(ToDoService service, Guid id)
        {
            var todo = await service.FindById(id);
            if (todo is null)
                return Results.NotFound();

            await service.Delete(todo);
            return Results.NoContent();
        }
    }
}
