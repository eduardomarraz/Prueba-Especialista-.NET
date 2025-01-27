using Microsoft.AspNetCore.Mvc.Rendering;
using Prueba_Especialista_.NET.Models;
using System.Collections.Generic;

namespace Prueba_Especialista_.NET.ViewModels
{
    public class VisitsCreateEditViewModel
    {
        public Visit Visit { get; set; } = new Visit(); 
        public List<SelectListItem> ClientsSelectList { get; set; } = new List<SelectListItem>(); // Lista de Clientes
        public List<SelectListItem> CommercialsSelectList { get; set; } = new List<SelectListItem>(); // Lista de Comerciales
    }
}
