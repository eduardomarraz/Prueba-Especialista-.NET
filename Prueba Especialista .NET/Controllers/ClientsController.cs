using Microsoft.AspNetCore.Mvc;
using Prueba_Especialista_.NET.Models;
using Prueba_Especialista_.NET.Services;
using System;
using System.Threading.Tasks;

namespace Prueba_Especialista_.NET.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        // GET: Clients
        public async Task<IActionResult> Index()
        {
            var clients = await _clientService.GetAllClientsAsync();
            return View(clients); // Retorna la vista con la lista de clientes
        }

        // GET: Clients/Create
        public IActionResult Create()
        {
            return View(); // Muestra el formulario para crear un cliente
        }

        // POST: Clients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Client client)
        {
            if (ModelState.IsValid)
            {
                await _clientService.CreateClientAsync(client);
                return RedirectToAction(nameof(Index)); // Redirige al listado tras crear
            }

            return View(client); // Retorna al formulario si hay errores
        }

        // GET: Clients/Edit/{id}
        public async Task<IActionResult> Edit(Guid id)
        {
            var client = await _clientService.GetClientByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client); // Muestra el formulario de edición
        }

        // POST: Clients/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Client client)
        {
            if (id != client.ClientId)
            {
                return BadRequest(); // Asegura que el ID coincide
            }

            if (ModelState.IsValid)
            {
                await _clientService.UpdateClientAsync(client);
                return RedirectToAction(nameof(Index)); // Redirige al listado tras editar
            }

            return View(client); // Retorna al formulario si hay errores
        }

        // POST: Clients/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _clientService.DeleteClientAsync(id);
            return RedirectToAction(nameof(Index)); // Redirige al listado tras eliminar
        }
    }
}
