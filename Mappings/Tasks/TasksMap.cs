

using ToDoApi.Dtos.Tasks;
using ToDoApi.Models;

namespace ToDoApi.Mappings.Task
{
    public static class TasksMap
    {
        //Mapeo manual de Task a TaskDto para métodos de GetById o GetAll
        public static TasksDto ToTasksDto(this Tasks task)
        {
            return new TasksDto 
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Status = task.Status,
                Priority = task.Priority

            };
        }

        //Mapea la request de crear una nueva tarea a la entidad modelo Tarea
        public static Tasks ToTasksFromCreateDto(this CreateTasksDto createTasksDto)
        {
            return new Tasks
            {
                Title = createTasksDto.Title,
                Description = createTasksDto.Description,
                Status = createTasksDto.Status,
                Priority = createTasksDto.Priority
            };
        }
    }
}