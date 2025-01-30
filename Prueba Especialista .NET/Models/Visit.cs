using System.ComponentModel.DataAnnotations;

namespace Prueba_Especialista_.NET.Models
{
    public class Visit
    {
        [Key]
        public Guid VisitId { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "La fecha de la visita es obligatoria.")]
        [DataType(DataType.Date)]
        public DateTime DateVisit { get; set; }

        // Relación con Client
        [Required(ErrorMessage = "El cliente es obligatorio.")]
        public Guid ClientId { get; set; }
        public Client Client { get; set; }

        // Relación con Commercial
        [Required(ErrorMessage = "El comercial es obligatorio.")]
        public Guid CommercialId { get; set; }
        public Commercial Commercial { get; set; }

        public string Notes { get; set; }
    }

}
