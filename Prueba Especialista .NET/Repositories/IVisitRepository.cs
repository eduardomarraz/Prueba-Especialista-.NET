using Prueba_Especialista_.NET.Models;

namespace Prueba_Especialista_.NET.Repositories
{
    public interface IVisitRepository
    {
        Task<List<Visit>> GetAllAsync();
        Task<Visit> GetByIdAsync(Guid id);
        Task AddAsync(Visit visit);
        Task UpdateAsync(Visit visit);
        Task DeleteAsync(Guid id);
    }
}
