using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prueba_Especialista_.NET.DbContexts;
using Prueba_Especialista_.NET.Models;
using Prueba_Especialista_.NET.Services;
using Prueba_Especialista_.NET.ViewModels;
using System;
using System.Threading.Tasks;

namespace Prueba_Especialista_.NET.Controllers
{
    public class VisitsController : Controller
    {
        private readonly IVisitService _visitService;
        private readonly IClientService _clientService;
        private readonly ICommercialService _commercialService;

        public VisitsController(IVisitService visitService,
        IClientService clientService,
        ICommercialService commercialService)
        {
            _visitService = visitService;
            _clientService = clientService;
            _commercialService = commercialService;
        }

        // GET: Visits
        public async Task<IActionResult> Index()
        {
            var visits = await _visitService.GetAllVisitsAsync();
            return View(visits); // Retorna la vista con la lista de visitas
        }

        // GET: Visits/Create
        public async Task<IActionResult> Create()
        {
            var clients = await _clientService.GetAllClientsAsync();
            var commercials = await _commercialService.GetAllCommercialsAsync();

            var viewModel = new VisitsCreateEditViewModel
            {
                Visit = new Visit(),
                ClientsSelectList = clients
                    .Select(c => new SelectListItem
                    {
                        Value = c.ClientId.ToString(),
                        Text = c.Name
                    })
                    .ToList(),
                CommercialsSelectList = commercials
                    .Select(com => new SelectListItem
                    {
                        Value = com.CommercialId.ToString(),
                        Text = com.Name
                    })
                    .ToList()
            };

            return View(viewModel);
        }

        // POST: Visits/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VisitsCreateEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                // Si hay error de validación, recargamos las listas y volvemos a la vista
                var clients = await _clientService.GetAllClientsAsync();
                var commercials = await _commercialService.GetAllCommercialsAsync();

                viewModel.ClientsSelectList = clients
                    .Select(c => new SelectListItem
                    {
                        Value = c.ClientId.ToString(),
                        Text = c.Name
                    })
                    .ToList();
                viewModel.CommercialsSelectList = commercials
                    .Select(com => new SelectListItem
                    {
                        Value = com.CommercialId.ToString(),
                        Text = com.Name
                    })
                    .ToList();

                return View(viewModel);
            }

            // Guardamos la visita en la BD a través del servicio
            await _visitService.CreateVisitAsync(viewModel.Visit);
            return RedirectToAction(nameof(Index));
        }


        // GET: Visits/Edit/{id}
        public async Task<IActionResult> Edit(Guid id)
        {
            var visit = await _visitService.GetVisitByIdAsync(id);
            if (visit == null)
                return NotFound();

            var clients = await _clientService.GetAllClientsAsync();
            var commercials = await _commercialService.GetAllCommercialsAsync();

            var viewModel = new VisitsCreateEditViewModel
            {
                Visit = visit,
                ClientsSelectList = clients
                    .Select(c => new SelectListItem
                    {
                        Value = c.ClientId.ToString(),
                        Text = c.Name,
                        Selected = (c.ClientId == visit.ClientId)
                    })
                    .ToList(),
                CommercialsSelectList = commercials
                    .Select(com => new SelectListItem
                    {
                        Value = com.CommercialId.ToString(),
                        Text = com.Name,
                        Selected = (com.CommercialId == visit.CommercialId)
                    })
                    .ToList()
            };

            return View(viewModel);
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
        public async Task<IActionResult> Edit(Guid id, VisitsCreateEditViewModel viewModel)
        {
            if (id != viewModel.Visit.VisitId)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                // Recargamos listas para mostrarlas en la vista si hay validación fallida
                var clients = await _clientService.GetAllClientsAsync();
                var commercials = await _commercialService.GetAllCommercialsAsync();

                viewModel.ClientsSelectList = clients
                    .Select(c => new SelectListItem
                    {
                        Value = c.ClientId.ToString(),
                        Text = c.Name,
                        Selected = (c.ClientId == viewModel.Visit.ClientId)
                    })
                    .ToList();

                viewModel.CommercialsSelectList = commercials
                    .Select(com => new SelectListItem
                    {
                        Value = com.CommercialId.ToString(),
                        Text = com.Name,
                        Selected = (com.CommercialId == viewModel.Visit.CommercialId)
                    })
                    .ToList();

                return View(viewModel);
            }

            // Llamamos al servicio para que actualice la visita
            await _visitService.UpdateVisitAsync(viewModel.Visit);
            return RedirectToAction(nameof(Index));
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
