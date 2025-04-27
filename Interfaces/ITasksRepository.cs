
using ToDoApi.Dtos.Tasks;
using ToDoApi.Models;

namespace ToDoApi.Interfaces
{
    public interface ITasksRepository
    {
        IEnumerable<TasksDto> GetAllAsync();
        Task<Tasks> GetByIdAsync(int id);
        Task AddTaskAsync(Tasks task);
        Task UpdateTaskAsync(Tasks task);
        Task DeleteTasksAsync(int id);
    }
}