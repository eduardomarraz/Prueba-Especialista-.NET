using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Prueba_Especialista_.NET.Models;
using Prueba_Especialista_.NET.Repositories;

namespace Prueba_Especialista_.NET.Services
{
    public class VisitService : IVisitService
    {
        private readonly IVisitRepository _visitRepository;

        public VisitService(IVisitRepository visitRepository)
        {
            _visitRepository = visitRepository;
        }

        public async Task<List<Visit>> GetAllVisitsAsync()
        {
            // Aquí podrías filtrar o implementar reglas
            return await _visitRepository.GetAllAsync();
        }

        public async Task<Visit> GetVisitByIdAsync(Guid id)
        {
            return await _visitRepository.GetByIdAsync(id);
        }

        public async Task CreateVisitAsync(Visit visit)
        {
            // Valida, por ejemplo, que la fecha de la visita no sea nula o esté en el futuro, etc.
            if (visit.DateVisit == default)
            {
                throw new Exception("La fecha de la visita no es válida.");
            }
            await _visitRepository.AddAsync(visit);
        }

        public async Task UpdateVisitAsync(Visit visit)
        {
            await _visitRepository.UpdateAsync(visit);
        }

        public async Task DeleteVisitAsync(Guid id)
        {
            await _visitRepository.DeleteAsync(id);
        }
    }
}
