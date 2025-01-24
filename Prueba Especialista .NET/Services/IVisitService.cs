using Prueba_Especialista_.NET.Models;

namespace Prueba_Especialista_.NET.Services
{
    public interface IVisitService
    {
        Task<List<Visit>> GetAllVisitsAsync();
        Task<Visit> GetVisitByIdAsync(Guid id);
        Task CreateVisitAsync(Visit visit);
        Task UpdateVisitAsync(Visit visit);
        Task DeleteVisitAsync(Guid id);
    }
}
