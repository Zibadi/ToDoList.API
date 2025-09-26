using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class ToDoService(IToDoRepository todoRepository)
    {
        public async Task<List<ToDo>> FindAll()
        {
            return await todoRepository.GetAllAsync();
        }

        public async Task<ToDo?> FindById(Guid id)
        {
            return await todoRepository.GetByIdAsync(id);
        }

        public async Task Create(ToDo todo)
        {
            await todoRepository.CreateAsync(todo);
        }

        public async Task Update(ToDo existingToDo, ToDo todo)
        {
            await todoRepository.UpdateAsync(existingToDo, todo);
        }

        public async Task Delete(ToDo todo)
        {
            await todoRepository.DeleteAsync(todo);
        }
    }
}
