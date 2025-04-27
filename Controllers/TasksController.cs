
using Microsoft.AspNetCore.Mvc;
using ToDoApi.Dtos.Tasks;
using ToDoApi.Interfaces;
using ToDoApi.Mappings.Task;

namespace ToDoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITasksRepository _tasksRepository;

        public TasksController(ITasksRepository tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var tasks =  _tasksRepository.GetAllAsync();

            if(!tasks.Any())
                return NotFound("No hay tareas activas.");

            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var task = await _tasksRepository.GetByIdAsync(id);
            if  (task == null)
                return NotFound("La tarea no fue encontrada.");

            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> AddTask([FromBody] CreateTasksDto createTasksDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var task = createTasksDto.ToTasksFromCreateDto();

            await _tasksRepository.AddTaskAsync(task);

            return CreatedAtAction(nameof(Get), new {Id = task.Id}, task);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask([FromRoute] int id, UpdateTasksDto updateTasksDto)
        {
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);

            var task = await _tasksRepository.GetByIdAsync(id);
            if(task == null)
                return NotFound("Tarea no encontrada.");

            task.Title = updateTasksDto.Title;
            task.Description = updateTasksDto.Description;
            task.Status = updateTasksDto.Status;
            task.Priority = updateTasksDto.Priority;

            await _tasksRepository.UpdateTaskAsync(task);

            return Ok("Tarea actualizada correctamente.");
        }
        

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask([FromRoute] int id)
        {
            var task = await _tasksRepository.GetByIdAsync(id);
            if(task == null)
                return NotFound("Tarea no encontrada.");
            
            await _tasksRepository.DeleteTasksAsync(task.Id);
            
            return NoContent();
        }
    }
}