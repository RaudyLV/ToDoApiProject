using ToDoApi.Dtos.Tasks;
using ToDoApi.Models;
namespace ToDoApi.Interfaces
{
    public interface ITasksService
    {
        IEnumerable<TasksDto> GetAllTasks();
        Task<Tasks> GetByIdAsync(int id);
        Task AddTask(CreateTasksDto task);
        Task UpdateTask(Tasks task, UpdateTasksDto updateTasksDto);
        Task DeleteTask(int id);
    }
}