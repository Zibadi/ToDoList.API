using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IToDoRepository
    {
        Task<List<ToDo>> GetAllAsync();
        Task<ToDo> GetByIdAsync(Guid id);
        Task CreateAsync(ToDo todo);
        Task UpdateAsync(ToDo existingToDo, ToDo todo);
        Task DeleteAsync(ToDo todo);
    }
}
