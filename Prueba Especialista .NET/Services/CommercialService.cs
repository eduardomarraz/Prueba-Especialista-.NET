using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Prueba_Especialista_.NET.Models;
using Prueba_Especialista_.NET.Repositories; 
using Prueba_Especialista_.NET.Services;  

namespace Prueba_Especialista_.NET.Services
{
    public class CommercialService : ICommercialService
    {
        private readonly ICommercialRepository _commercialRepository;

        public CommercialService(ICommercialRepository commercialRepository)
        {
            _commercialRepository = commercialRepository;
        }

        public async Task<List<Commercial>> GetAllCommercialsAsync()
        {

            return await _commercialRepository.GetAllAsync();
        }

        public async Task<Commercial> GetCommercialtByIdAsync(Guid id)
        {
            // Verificación extra si procede
            return await _commercialRepository.GetByIdAsync(id);
        }

        public async Task CreateCommercialAsync(Commercial commercial)
        {
            // Ejemplo de validación básica
            if (string.IsNullOrWhiteSpace(commercial.Name))
            {
                throw new Exception("El nombre del comercial no puede estar vacío");
            }
            await _commercialRepository.AddAsync(commercial);
        }

        public async Task UpdateCommercialAsync(Commercial commercial)
        {
            // Podemos verificar si existe o si hay reglas de negocio
            await _commercialRepository.UpdateAsync(commercial);
        }

        public async Task DeleteCommercialAsync(Guid id)
        {
            // Si hay restricciones (ej. no puedes borrar un comercial con visitas pendientes), aquí iría la lógica
            await _commercialRepository.DeleteAsync(id);
        }
    }
}
