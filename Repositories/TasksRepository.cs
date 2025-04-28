using Microsoft.EntityFrameworkCore;
using ToDoApi.Data;
using ToDoApi.Dtos.Tasks;
using ToDoApi.Helpers;
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
        public async Task<List<Tasks>> GetAllTasks(QueryObject query)
        {
             var tasks = _appDbContext.Tasks.AsQueryable();

             if(!string.IsNullOrEmpty(query.Title))
             {
                tasks = tasks.Where(t => t.Title.Contains(query.Title));
             }

             if(!string.IsNullOrEmpty(query.Description))
             {
                tasks = tasks.Where(t => t.Description.Contains(query.Description));    
             }
            
            var skipNumber = (query.PageNumber - 1) * query.PageSize;

             return await tasks.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }
        
        public async Task<Tasks> GetByIdAsync(int id) => await _appDbContext.Tasks.FindAsync(id);
    }
}