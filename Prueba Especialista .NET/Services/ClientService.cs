using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Prueba_Especialista_.NET.Models;
using Prueba_Especialista_.NET.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Prueba_Especialista_.NET.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<List<Client>> GetAllClientsAsync()
        {
            return await _clientRepository.GetAllAsync();
        }

        public async Task<Client> GetClientByIdAsync(Guid id)
        {
            // Podemos verificar, por ejemplo, si el ID es válido, si existe...
            return await _clientRepository.GetByIdAsync(id);
        }

        public async Task CreateClientAsync(Client client)
        {
            // Ejemplo de validación simple:
            if (string.IsNullOrWhiteSpace(client.Name))
            {
                throw new Exception("El nombre del cliente no puede ir vacío");
            }

            await _clientRepository.AddAsync(client);
        }

        public async Task UpdateClientAsync(Client client)
        {
            // Podemos verificar si el cliente existe antes de actualizar
            // O si hay alguna regla de negocio que impida ciertos cambios.
            await _clientRepository.UpdateAsync(client);
        }

        public async Task DeleteClientAsync(Guid id)
        {
            // Aquí podríamos comprobar si el cliente tiene alguna visita asociada, etc.
            await _clientRepository.DeleteAsync(id);
        }
    }
}
