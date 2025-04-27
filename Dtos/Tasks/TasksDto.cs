
using ToDoApi.Enums;

namespace ToDoApi.Dtos.Tasks
{
    public class TasksDto
    {
        public int Id { get; set; }
        public string Title { get; set;} = string.Empty;
        public string Description { get; set;} = string.Empty;
        public TasksStatus Status { get; set;}
        public TaskPriority Priority{ get; set;}
    }
}