using ToDoApi.Dtos.Tasks;
using ToDoApi.Helpers;
using ToDoApi.Models;
namespace ToDoApi.Interfaces
{
    public interface ITasksService
    {
        Task<List<Tasks>> GetAllTasksAsync(QueryObject query);
        Task<Tasks> GetByIdAsync(int id);
        Task AddTask(CreateTasksDto task);
        Task UpdateTask(Tasks task, UpdateTasksDto updateTasksDto);
        Task DeleteTask(int id);
    }
}