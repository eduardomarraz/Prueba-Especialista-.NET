using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Prueba_Especialista_.NET.Models;

namespace Prueba_Especialista_.NET.Services
{
    public interface IClientService
    {
        Task<List<Client>> GetAllClientsAsync();
        Task<Client> GetClientByIdAsync(Guid id);
        Task CreateClientAsync(Client client);
        Task UpdateClientAsync(Client client);
        Task DeleteClientAsync(Guid id);
    }
}

//Esta interfaz define los métodos de negocio que tu aplicación necesita para gestionar clientes.
//“Service” => “¿Qué le puedo pedir a mi negocio que haga con los clientes?” (listar, obtener, crear, editar, borrar).