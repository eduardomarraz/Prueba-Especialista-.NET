using Prueba_Especialista_.NET.Models;

namespace Prueba_Especialista_.NET.Repositories
{
    public interface ICommercialRepository
    {
        Task<List<Commercial>> GetAllAsync();
        Task<Commercial> GetByIdAsync(Guid id);
        Task AddAsync(Commercial commercial);
        Task UpdateAsync(Commercial commercial);
        Task DeleteAsync(Guid id);
    }
}
