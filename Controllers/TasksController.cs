
using Microsoft.AspNetCore.Mvc;
using ToDoApi.Interfaces;

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
    }
}