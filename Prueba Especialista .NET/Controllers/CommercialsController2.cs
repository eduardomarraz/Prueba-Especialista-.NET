using Microsoft.AspNetCore.Mvc;
using Prueba_Especialista_.NET.Models;
using Prueba_Especialista_.NET.Services;
using System;
using System.Threading.Tasks;

namespace Prueba_Especialista_.NET.Controllers
{
    public class CommercialsController2 : Controller
    {
        private readonly ICommercialService _commercialService;

        public CommercialsController2(ICommercialService commercialService)
        {
            _commercialService = commercialService;
        }

        // GET: Commercials
        public async Task<IActionResult> Index()
        {
            var commercials = await _commercialService.GetAllCommercialsAsync();
            return View(commercials); // Retorna la vista con la lista de comerciales
        }

        // GET: Commercials/Create
        public IActionResult Create()
        {
            return View(); // Muestra el formulario para crear un comercial
        }

        // POST: Commercials/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Commercial commercial)
        {
            if (ModelState.IsValid)
            {
                await _commercialService.CreateCommercialAsync(commercial);
                return RedirectToAction(nameof(Index)); // Redirige al listado tras crear
            }

            return View(commercial); // Retorna al formulario si hay errores
        }

        // GET: Commercials/Edit/{id}
        public async Task<IActionResult> Edit(Guid id)
        {
            var commercial = await _commercialService.GetCommercialByIdAsync(id);
            if (commercial == null)
            {
                return NotFound();
            }

            return View(commercial); // Muestra el formulario de edición
        }

        // POST: Commercials/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Commercial commercial)
        {
            if (id != commercial.CommercialId)
            {
                return BadRequest(); // Asegura que el ID coincide
            }

            if (ModelState.IsValid)
            {
                await _commercialService.UpdateCommercialAsync(commercial);
                return RedirectToAction(nameof(Index)); // Redirige al listado tras editar
            }

            return View(commercial); // Retorna al formulario si hay errores
        }

        // POST: Commercials/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _commercialService.DeleteCommercialAsync(id);
            return RedirectToAction(nameof(Index)); // Redirige al listado tras eliminar
        }
    }
}
