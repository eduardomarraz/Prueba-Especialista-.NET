using System.ComponentModel.DataAnnotations;

namespace Prueba_Especialista_.NET.Models
{
    public class Client
{
    [Key]
    public Guid ClientId { get; set; } = Guid.NewGuid();
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;
    [Required]
    [EmailAddress]
    public string Address { get; set; } = string.Empty;

    }
}