using Microsoft.EntityFrameworkCore;
using ToDoApi.Data;
using ToDoApi.Dtos.Tasks;
using ToDoApi.Interfaces;
using ToDoApi.Mappings.Task;
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

        public async Task AddTaskAsync(Tasks task)
        {
           await _appDbContext.Tasks.AddAsync(task);
           await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteTasksAsync(int id)
        {
            var task = await _appDbContext.Tasks.FirstOrDefaultAsync(t => t.Id == id);

            if (task != null)
                _appDbContext.Tasks.Remove(task);
                await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateTaskAsync(Tasks task)
        {
             if (task != null)
                _appDbContext.Tasks.Update(task);
                await _appDbContext.SaveChangesAsync();
        }
        public IEnumerable<TasksDto> GetAllAsync() => _appDbContext.Tasks.ToList().Select(t => t.ToTasksDto());
        
        public async Task<Tasks> GetByIdAsync(int id)
        {
            var task = await _appDbContext.Tasks.FindAsync(id);

            if(task == null)
                return null!;

            return task;
        }
    }
}