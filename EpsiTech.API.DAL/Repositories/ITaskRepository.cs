namespace EpsiTech.API.DAL.Repositories
{
    public interface ITaskRepository
    {
        Task<Domain.Models.Task?> GetByIdAsync(Guid id);
        Task<IEnumerable<Domain.Models.Task>> GetAllAsync();
        Task<bool> CreateAsync(Domain.Models.Task task);
        Task<bool> EditAsync(Domain.Models.Task task);
        Task<bool> DeleteAsync(Domain.Models.Task task);
    }
}
