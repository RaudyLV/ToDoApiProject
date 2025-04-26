using ToDoApi.Data;
using ToDoApi.Interfaces;
using ToDoApi.Models;

namespace ToDoApi.Repositories
{
    public class TasksRepository : ITasksRepository
    {
        private readonly AppDbContext _appDbContext;

        public TasksRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task AddTaskAsync(Tasks task)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTasksAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Tasks>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Tasks> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTaskAsync(Tasks task)
        {
            throw new NotImplementedException();
        }
    }
}