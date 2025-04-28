using ToDoApi.Dtos.Tasks;
using ToDoApi.Enums;
using ToDoApi.Interfaces;
using ToDoApi.Mappings.Task;
using ToDoApi.Models;

namespace ToDoApi.Services
{
    public class TasksServices : ITasksService
    {
        private readonly ITasksRepository _tasksRepository;
        public TasksServices(ITasksRepository tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }

        public IEnumerable<TasksDto> GetAllTasks() => _tasksRepository.GetAllTasks();

        public async Task<Tasks> GetByIdAsync(int id) 
        {
            var task = await _tasksRepository.GetByIdAsync(id);
            if (task == null)
                return null!;
            
            return task;
        }

        public async Task AddTask(CreateTasksDto tasksDto)
        {
            ValidateEnums(tasksDto.Priority, tasksDto.Status);

            var task = tasksDto.ToTasksFromCreateDto();

            await _tasksRepository.AddTaskAsync(task);
        }

        public async Task UpdateTask(Tasks task, UpdateTasksDto tasksDto)
        {
            ValidateEnums(tasksDto.Priority, tasksDto.Status);

            task = tasksDto.ToTaskFromUpdateDto();

            await _tasksRepository.UpdateTaskAsync(task);
        }

        public async Task DeleteTask(int id)
        {
            await _tasksRepository.DeleteTasksAsync(id);
        }

            
        #region Metodos Aux
        //Esta funcion verifica que el usuario no introduzca un valor que no exista en los Enums
        //Esto permite que asigne un valor valido como prioridad y estado de la tarea.
        private void ValidateEnums(TaskPriority taskPriority, TasksStatus taskStatus)
        {
            if(((int)taskStatus) > 2 || ((int)taskStatus) < 0 )
            {
                throw new ArgumentOutOfRangeException(nameof(taskStatus), "El estado debe ser un numero entre 0 y 2");
            }
                if(((int)taskPriority) > 2 || ((int)taskPriority) < 0 )
            {
                throw new ArgumentOutOfRangeException(nameof(taskPriority), "La prioridad debe ser un numero entre 0 y 2");
            }
        }
        #endregion
    }
}
