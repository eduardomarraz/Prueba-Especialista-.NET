using System.ComponentModel.DataAnnotations;

namespace Prueba_Especialista_.NET.Models
{
    public class Commercial
    {
        public Guid CommercialId { get; set; }

        [Required(ErrorMessage = "El nombre del comercial es obligatorio.")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string Name { get; set; }

    }
}
