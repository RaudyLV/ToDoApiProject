using ToDoApi.Enums;

namespace ToDoApi.Models
{
    public class Tasks
    {
        public int Id { get; set;}
        public string Title { get; set;} = string.Empty;
        public string Description { get; set;} = string.Empty;
        public TasksStatus Status { get; set;}
        public TaskPriority Priority{ get; set;}
    }
}