using System.ComponentModel.DataAnnotations;

namespace ProvaAzure01.DTOs
{
    public class CittaPreferitaDTO
    {
        [EmailAddress]
        public required string Email { get; set; }
        public required string Citta { get; set; }
    }
}
