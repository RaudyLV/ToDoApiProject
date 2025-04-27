using System.ComponentModel.DataAnnotations;
using ToDoApi.Enums;

namespace ToDoApi.Dtos.Tasks
{
    public class UpdateTasksDto
    {
     
        [Required(ErrorMessage = "El titulo es requerido.")]
        [Length(5, 50, ErrorMessage = "La longitud debe estar entre 5 y 50 cáracteres")]
        public string Title { get; set;} = string.Empty;
        [Required(ErrorMessage = "La descripcion es requerida.")]
        [Length(5, 200, ErrorMessage = "La longitud debe estar entre 5 y 200 cáracteres")]
        public string Description { get; set;} = string.Empty;
        [Required(ErrorMessage = "El estado es requerido.")]
        public TasksStatus Status { get; set;}
        [Required(ErrorMessage = "El nivel de prioridad es requerido.")]
        public TaskPriority Priority{ get; set;}
    }
}