namespace Prueba_Especialista_.NET.Models
{
    public class Visit
    {
        public Guid VisitId { get; set; }
        public DateTime DateVisit { get; set; }
        public string Notes { get; set; }

        // Relación con Client
        public Guid ClientId { get; set; }
        public Client Client { get; set; }

        // Relación con Commercial
        public Guid CommercialId { get; set; }
        public Commercial Commercial { get; set; }
    }

}
