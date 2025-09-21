using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ToDoRepository(ToDoDbContext context) : IToDoRepository
    {
        public async Task CreateAsync(ToDo todo)
        {
            await context.ToDos.AddAsync(todo);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ToDo todo)
        {
            if (todo is null)
                return;

            todo.IsDeleted = true;
            await context.SaveChangesAsync();
        }

        public async Task<List<ToDo>> GetAllAsync()
        {
            return await context.ToDos.Where(t => !t.IsDeleted).ToListAsync();
        }

        public async Task<ToDo?> GetByIdAsync(Guid id)
        {
            return await context.ToDos.FirstOrDefaultAsync(t => t.Id == id && !t.IsDeleted);
        }

        public async Task UpdateAsync(ToDo existingToDo, ToDo todo)
        {
            if (existingToDo is null || todo is null)
                return;

            existingToDo.Title = todo.Title;
            existingToDo.IsDeleted = todo.IsDeleted;
            await context.SaveChangesAsync();
        }
    }
}
