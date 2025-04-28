
using Microsoft.AspNetCore.Mvc;
using ToDoApi.Dtos.Tasks;
using ToDoApi.Helpers;
using ToDoApi.Interfaces;

namespace ToDoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITasksService _tasksService;

        public TasksController(ITasksService tasksService)
        {
            _tasksService = tasksService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] QueryObject query)
        {
            var tasks =  await _tasksService.GetAllTasksAsync(query);

            if(!tasks.Any())
                return NotFound("No hay tareas activas.");

            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var task = await _tasksService.GetByIdAsync(id);
            if  (task == null)
                return NotFound("La tarea no fue encontrada.");

            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> AddTask([FromBody] CreateTasksDto createTasksDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            await _tasksService.AddTask(createTasksDto);

            return Ok("Tarea creada correctamente.");
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask([FromRoute] int id, UpdateTasksDto updateTasksDto)
        {
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);

            var task = await _tasksService.GetByIdAsync(id);
            if(task == null)
                return NotFound("Tarea no encontrada.");

            await _tasksService.UpdateTask(task, updateTasksDto);

            return Ok("Tarea actualizada correctamente.");
        }
        

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask([FromRoute] int id)
        {
            var task = await _tasksService.GetByIdAsync(id);
            if(task == null)
                return NotFound("Tarea no encontrada.");
            
            await _tasksService.DeleteTask(task.Id);
            
            return Ok("Tarea eliminada correctamente.");
        }
    }
}