using EpsiTech.API.Domain;
using Microsoft.EntityFrameworkCore;

namespace EpsiTech.API.DAL.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Models.Task?> GetByIdAsync(Guid id)
        {
            return await _context.Set<Domain.Models.Task>()
                .FirstOrDefaultAsync(task => task.Id == id);
        }

        public async Task<IEnumerable<Domain.Models.Task>> GetAllAsync()
        {
            return await _context.Set<Domain.Models.Task>()
                .ToArrayAsync();
        }

        public async Task<bool> CreateAsync(Domain.Models.Task task)
        {
            task.Id = Guid.NewGuid();

            var entry = await _context.Set<Domain.Models.Task>()
                .AddAsync(task);
            await _context.SaveChangesAsync();

            return entry.State == EntityState.Unchanged;
        }

        public async Task<bool> EditAsync(Domain.Models.Task task)
        {
            var entry = _context.Set<Domain.Models.Task>()
                .Update(task);
            await _context.SaveChangesAsync();

            return entry.State == EntityState.Unchanged;
        }

        public async Task<bool> DeleteAsync(Domain.Models.Task task)
        {
            var entry = _context.Set<Domain.Models.Task>()
                .Remove(task);
            await _context.SaveChangesAsync();

            return entry.State == EntityState.Detached;
        }
    }
}
