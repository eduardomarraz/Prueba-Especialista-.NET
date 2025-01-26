using Microsoft.AspNetCore.Mvc;
using Prueba_Especialista_.NET.Models;
using Prueba_Especialista_.NET.Services;
using System;
using System.Threading.Tasks;

namespace Prueba_Especialista_.NET.Controllers
{
    public class VisitsController : Controller
    {
        private readonly IVisitService _visitService;

        public VisitsController(IVisitService visitService)
        {
            _visitService = visitService;
        }

        // GET: Visits
        public async Task<IActionResult> Index()
        {
            var visits = await _visitService.GetAllVisitsAsync();
            return View(visits); // Retorna la vista con la lista de visitas
        }

        // GET: Visits/Create
        public IActionResult Create()
        {
            return View(); // Muestra el formulario para crear una visita
        }

        // POST: Visits/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Visit visit)
        {
            if (ModelState.IsValid)
            {
                await _visitService.CreateVisitAsync(visit);
                return RedirectToAction(nameof(Index)); // Redirige al listado tras crear
            }

            return View(visit); // Retorna al formulario si hay errores
        }

        // GET: Visits/Edit/{id}
        public async Task<IActionResult> Edit(Guid id)
        {
            var visit = await _visitService.GetVisitByIdAsync(id);
            if (visit == null)
            {
                return NotFound();
            }

            return View(visit); // Muestra el formulario de edición
        }

        // GET: Visits/Details/{id}
        public async Task<IActionResult> Details(Guid id)
        {
            var visit = await _visitService.GetVisitByIdAsync(id);
            if (visit == null) return NotFound();

            return View(visit);
        }


        // POST: Visits/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Visit visit)
        {
            if (id != visit.VisitId)
            {
                return BadRequest(); // Asegura que el ID coincide
            }

            if (ModelState.IsValid)
            {
                await _visitService.UpdateVisitAsync(visit);
                return RedirectToAction(nameof(Index)); // Redirige al listado tras editar
            }

            return View(visit); // Retorna al formulario si hay errores
        }

        // POST: Visits/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _visitService.DeleteVisitAsync(id);
            return RedirectToAction(nameof(Index)); // Redirige al listado tras eliminar
        }
    }
}
