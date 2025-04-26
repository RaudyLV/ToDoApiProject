
using ToDoApi.Models;

namespace ToDoApi.Interfaces
{
    public interface ITasksRepository
    {
        Task<IEnumerable<Tasks>> GetAllAsync();
        Task<Tasks> GetByIdAsync(int id);
        Task AddTaskAsync(Tasks task);
        Task UpdateTaskAsync(Tasks task);
        Task DeleteTasksAsync(int id);
    }
}