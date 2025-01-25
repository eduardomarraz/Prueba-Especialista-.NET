using Prueba_Especialista_.NET.Models;

namespace Prueba_Especialista_.NET.Services
{
    public interface ICommercialService
    {
        Task<List<Commercial>> GetAllCommercialsAsync();
        Task<Commercial> GetCommercialByIdAsync(Guid id);
        Task CreateCommercialAsync(Commercial visit);
        Task UpdateCommercialAsync(Commercial visit);
        Task DeleteCommercialAsync(Guid id);
    }
}
