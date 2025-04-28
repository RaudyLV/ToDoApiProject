
using ToDoApi.Dtos.Tasks;
using ToDoApi.Helpers;
using ToDoApi.Models;

namespace ToDoApi.Interfaces
{
    public interface ITasksRepository
    {
        Task<List<Tasks>> GetAllTasks(QueryObject query);
        Task<Tasks> GetByIdAsync(int id);
        Task AddTaskAsync(Tasks task);
        Task UpdateTaskAsync(Tasks task);
        Task DeleteTasksAsync(int id);
    }
}